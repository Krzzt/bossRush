using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID;
    public UnitHealth EnemyHealth = new UnitHealth(5, 5);

    private HPBar HealthBar;
    private GameObject PlayerObject;
    Transform PlayerTransform;

    public int healthIncrease;

    Vector3 screenPos;
    Vector2 onScreenPos;
    float max;
    Camera camera;
    GameObject cursor;
    private void Awake()
    {
        EnemyHealth._currentMaxHealth += healthIncrease;
        EnemyHealth._currentHealth += healthIncrease;
        HealthBar = gameObject.GetComponent<HPBar>();
        camera = Camera.main;
        cursor = GameObject.FindWithTag("Cursor");

        PlayerObject = GameObject.FindWithTag("player");
        PlayerTransform = PlayerObject.transform;
    }
    public void TakeDamage(int amount)
    {
        EnemyHealth.DamageUnit(amount);
        HealthBar.ChangeValue();
        Debug.Log("remaining health: " + EnemyHealth._currentHealth);
        //his healthbar need to go down
    }


  
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        screenPos = camera.WorldToViewportPoint(transform.position);
        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            Debug.Log("already on screen, don't bother with the rest!");
            cursor.SetActive(false);
        }
        else
        {
            cursor.SetActive(true);
        }
        onScreenPos = new Vector2(screenPos.x - 0.5f, screenPos.y - 0.5f) * 2; //2D version, new mapping
        max = Mathf.Max(Mathf.Abs(onScreenPos.x), Mathf.Abs(onScreenPos.y)); //get largest offset
        onScreenPos = (onScreenPos / (max * 2)) + new Vector2(0.5f, 0.5f); //undo mapping
        onScreenPos -= new Vector2(0.1f, 0.1f);
        cursor.transform.position = camera.ViewportToWorldPoint(onScreenPos);
        Vector3 direction = gameObject.transform.position - PlayerObject.transform.position;
        cursor.transform.rotation = new Quaternion(direction.x, direction.y, direction.z, 0);
        Debug.Log(onScreenPos);

    }



}
