using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Player playerScript;
    public GameObject PlayerObject;


    private void Awake()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        playerScript = PlayerObject.GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.Equals("Enemy"))
        {
            Enemy enemyToDamage = collision.gameObject.GetComponent<Enemy>();
            enemyToDamage.TakeDamage(playerScript.damage);
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
}
