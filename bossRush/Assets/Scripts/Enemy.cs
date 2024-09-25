using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitHealth EnemyHealth = new UnitHealth(5, 5);
    public int bossID;
    public int currPhase;
    // Start is called before the first frame update

    public void TakeDamage(int amount)
    {
        EnemyHealth.DamageUnit(amount);
        //his healthbar need to go down
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (bossID)
        {
            //Boss1
            case 0:
                switch (currPhase)
                {
                    case 1:

                        break;

                    case 2:

                        break;
                }
                break;
        }
    }
}
