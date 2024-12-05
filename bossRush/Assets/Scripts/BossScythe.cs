using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScythe : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(1);
        }
    }
}
