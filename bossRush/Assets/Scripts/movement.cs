using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public GameObject Camera;

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    public Camera sceneCamera;

    public float dashcooldown;
    public float dashcooldownTime;

    public float timeDashing;
    public float timeDashingTime;

    public bool isDashing;

    public bool once;


    public SpriteRenderer spriteRenderer;
    // Update is called once per frame

    private void Awake()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        sceneCamera = Camera.GetComponent<Camera>();
        isDashing = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


    }
    void Update()
    {
       
        if (!isDashing)
        {
            ProcessInputs();
         
        }

        move();

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcooldown <= 0)
        {
            isDashing = true;
            once = false;
            dashcooldown = dashcooldownTime;
        }

            if (isDashing)
        {
            spriteRenderer.color = new Color(0.776f, 0.909f, 1f);
            if (!once)
            {
                moveSpeed *= 3;
                timeDashing = 0;
                once = true;
            }
            timeDashing += Time.deltaTime;
            if (timeDashing >= timeDashingTime)
            {
                spriteRenderer.color = new Color(0.376f, 0.753f, 1f);
                isDashing = false;
                moveSpeed /= 3;
            }
        }
            if (dashcooldown > 0)
        {
            dashcooldown -= Time.deltaTime;
        }




    }





    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;


    }
    void move()
    {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);


    }


}

