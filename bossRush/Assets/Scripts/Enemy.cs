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

    public GameObject ContinueScreen;

    private void Awake()
    {
        EnemyHealth._currentMaxHealth += healthIncrease;
        EnemyHealth._currentHealth += healthIncrease;
        HealthBar = gameObject.GetComponent<HPBar>();

        PlayerObject = GameObject.FindWithTag("player");
        PlayerTransform = PlayerObject.transform;
    }
    public void TakeDamage(int amount)
    {
        EnemyHealth.DamageUnit(amount);
        HealthBar.ChangeValue();
        Debug.Log("remaining health: " + EnemyHealth._currentHealth);
        if (EnemyHealth._currentHealth <= 0)
        {
            GameObject Continue = Instantiate(ContinueScreen, PlayerTransform.position, Quaternion.identity);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }


  



    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }



}
