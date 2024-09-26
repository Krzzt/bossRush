
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<int> bossIDsToFight = new List<int>(5);
    public GameObject[] allBosses = new GameObject[5];
    public GameObject BossToSpawn;
    public int currBoss;

    private void Awake()
    {
        for (int i = 0; i < bossIDsToFight.Count; i++)
        {
            bossIDsToFight[i] = -1;
        }
        for (int i = 0; i < bossIDsToFight.Count; i++)
        {
            int tempID = Random.Range(0, allBosses.Length);


               while (bossIDsToFight.Contains(tempID))
            {
                tempID = Random.Range(0, allBosses.Length);
            }
            bossIDsToFight[i] = tempID;
            


        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnBoss()
    {
        BossToSpawn = allBosses[bossIDsToFight[currBoss]];
        GameObject SpawnBoss = Instantiate(BossToSpawn, new Vector3(10,10,0), Quaternion.identity);
    }
}
