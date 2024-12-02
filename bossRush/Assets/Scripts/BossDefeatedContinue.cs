using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatedContinue : MonoBehaviour
{

    public GameObject GameManager;
    public GameManager Game;
    public GameObject Store;
    public GameObject FightScene;


    private void Awake()
    {
        GameManager = GameObject.FindWithTag("GameManager");
        Game = GameManager.GetComponent<GameManager>();
        Store = Game.Store;
        FightScene = GameObject.FindWithTag("FightScene");
    }


    public void SetStoreActive()
    {
        Store.SetActive(true);
    }

    public void SetStoreInActive()
    {
        Store.SetActive(false);
    }

    public void FightSceneInactive()
    {
        FightScene.SetActive(false);
    }
    public void FightSceneActive()
    {
        FightScene.SetActive(true);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }


    }

