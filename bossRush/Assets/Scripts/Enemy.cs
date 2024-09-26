using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID;
    public UnitHealth EnemyHealth = new UnitHealth(5, 5);



    public int healthIncrease;

    private void Awake()
    {
        EnemyHealth._currentMaxHealth += healthIncrease;
        EnemyHealth._currentHealth += healthIncrease;
    }
    public void TakeDamage(int amount)
    {
        EnemyHealth.DamageUnit(amount);
        //his healthbar need to go down
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }



}
