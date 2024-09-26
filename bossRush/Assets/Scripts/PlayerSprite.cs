using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject Player;
    private Rigidbody2D playerrb;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("player");
        playerrb = Player.GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = 0;
    }
}
