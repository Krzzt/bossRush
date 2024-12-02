
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

    public GameObject Store;
    public GameObject FightScene;
    public Player PlayerScript;

    private void Awake()
    {
        Store.SetActive(false);
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
        Time.timeScale = 1.0f;
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
            PlayerScript.playerHealth._currentHealth = PlayerScript.playerHealth._currentMaxHealth;
            PlayerScript.SetHearts();
            SpawnBoss();
            
        }
    }

    public void IncreaseHealth()
    {
        PlayerScript.playerHealth.addmaxHealth(1);
    }

    public void IncreaseDamage()
    {
        PlayerScript.damage += 2;
    }

    public void IncreaseDashTimer()
    {
        PlayerScript.TotalParryTime += 0.15f;
    }
}
