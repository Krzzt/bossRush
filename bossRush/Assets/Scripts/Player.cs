using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UnitHealth playerHealth = new UnitHealth(100, 100);
    public bool invincible;

    public int damage;

    private void Awake()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if (!invincible)
        {
            playerHealth.DamageUnit(amount);
            //play dmg animation 
        }
        else
        {
     
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {

    }
}
