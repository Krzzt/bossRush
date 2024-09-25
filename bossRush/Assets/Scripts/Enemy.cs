using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitHealth EnemyHealth = new UnitHealth(5, 5);
    public int bossID;
    public int currPhase;

    public int healthIncrease;

    public float movetimer;
    public float timebetweenmoves;

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
        switch (bossID)
        {
            //Boss1
            case 0:
                   if (timebetweenmoves < movetimer)
                {
                    timebetweenmoves += Time.deltaTime;
                }
                   else
                {
                    BossBehaivour0();
                    
                }
                   
                
                break;
        }
    }


public void BossBehaivour0()
    {
        switch (currPhase) {
            
            case 1:
                int moveToDo = Random.Range(0, 3);
                switch (moveToDo)
                {
                    case 0:


                        //move1
                        timebetweenmoves = 0;
                        break;

                    case 1:
                        //move2
                        timebetweenmoves = 0;
                        break;

                    case 2:
                        //move3
                        timebetweenmoves = 0;
                        break;
                }
              break;
    }

}
