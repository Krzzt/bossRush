using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject PlayerObject;
    Player PlayerScript;

    public float time;

    bool damage;

    private void Awake()
    {
        PlayerObject = GameObject.FindWithTag("player");
        PlayerScript = PlayerObject.GetComponent<Player>();
        damage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerObject)
        {
            damage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerObject)
        {
            damage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerObject)
        {
            damage = false;
        }
    }


    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;



        if (time > 2f)
        {
             if (damage)
            {
                PlayerScript.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
