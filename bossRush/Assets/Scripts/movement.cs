using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    private Vector2 mousePosition;

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

    public GameObject playerSprite;
    public SpriteRenderer spriteRenderer;


    private Player PlayerScript;
    // Update is called once per frame

    private void Awake()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        sceneCamera = Camera.GetComponent<Camera>();
        isDashing = false;
        playerSprite = GameObject.FindWithTag("PlayerSprite");
        spriteRenderer = playerSprite.GetComponent<SpriteRenderer>();
        PlayerScript = gameObject.GetComponent<Player>();

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
            PlayerScript.invincible = true;
        }

            if (isDashing)
        {
            spriteRenderer.color = new Color(0.576f, 0.709f, 0.8f);

            if (!once)
            {
                moveSpeed *= 2;
                timeDashing = 0;
                once = true;
            }
            timeDashing += Time.deltaTime;
            if (timeDashing >= timeDashingTime)
            {
                spriteRenderer.color = new Color(1, 1, 1);
                PlayerScript.invincible = false;
                isDashing = false;
                moveSpeed /= 2;
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
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);


    }
    void move()
    {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;


    }


}

