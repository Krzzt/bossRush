using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID;
    public UnitHealth EnemyHealth = new UnitHealth(5, 5);

    private HPBar HealthBar;

    public int healthIncrease;

    private void Awake()
    {
        EnemyHealth._currentMaxHealth += healthIncrease;
        EnemyHealth._currentHealth += healthIncrease;
        HealthBar = gameObject.GetComponent<HPBar>();
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

    }



}
