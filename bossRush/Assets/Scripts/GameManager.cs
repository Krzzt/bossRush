
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<int> bossIDsToFight = new List<int>(2);
    public GameObject[] allBosses = new GameObject[2];
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
        
        SpawnBoss();
        

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
        GameObject FightScene = GameObject.FindWithTag("FightScene");
        SpawnBoss.transform.SetParent(FightScene.transform, false);
        SpawnBoss.transform.position = new Vector3(10,10,0);
    }


    public void NextRound()
    {
        GameObject BossDefeatedScreen = GameObject.FindWithTag("BossDefeated");
        Destroy(BossDefeatedScreen);
        currBoss++;
        if (currBoss > bossIDsToFight.Count)
        {
            //you won
        }
        else
        {
            GameObject Player = GameObject.FindWithTag("player");
            Player.transform.position = new Vector3(0, 0, 0);
            SpawnBoss();
            
        }
    }
}
