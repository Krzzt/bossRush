using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float lifetime;
    public int secondsToLive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifetime += Time.fixedDeltaTime;
        if (lifetime >= secondsToLive)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Player playerToHit = collision.gameObject.GetComponent<Player>();
            if (!playerToHit.ParryActive)
            {
                playerToHit.TakeDamage(1);
                Destroy(gameObject);
            }

        }
    }
}