using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Player playerScript;
    public GameObject PlayerObject;

    public float lifeTime;

    private void Awake()
    {
        PlayerObject = GameObject.FindWithTag("player");
        playerScript = PlayerObject.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyToDamage = collision.gameObject.GetComponent<Enemy>();
            if (gameObject.CompareTag("ParryBullet"))
            {
                enemyToDamage.TakeDamage(playerScript.parryDamage);
            }
            else if (gameObject.CompareTag("Bullet"))
            {
                enemyToDamage.TakeDamage(playerScript.damage / 2);
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
