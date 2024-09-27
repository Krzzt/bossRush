using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UnitHealth playerHealth = new UnitHealth(3, 3);
    public bool invincible;

    public int damage;
    public int parryDamage;

    public float damageinvistimer;
    public bool dmginvincibility;
    public bool ParryActive;
    public float ParryCooldown;
    public float ParryTime;

    public SpriteRenderer spriteRenderer;

    public GameObject bulletParryPrefab;
    public int parryForce;

    public GameObject[] HeartObjects = new GameObject[3];

    public GameObject GameOverScreen;

    public GameObject PlayerSprite;
    private void Awake()
    {
        

        spriteRenderer = PlayerSprite.GetComponent<SpriteRenderer>();
        SetHearts();
        Time.timeScale = 1.0f;

    }

    public void TakeDamage(int amount)
    {
        if (!invincible)
        {
            playerHealth.DamageUnit(amount);
            damageinvistimer = 2;
            dmginvincibility = true;
            invincible = true;
            SetHearts();
            if (playerHealth._currentHealth <= 0)
            {
                GameObject gameOver = Instantiate(GameOverScreen);
                Time.timeScale = 0;
            }
            //play dmg animation 
        }
        else
        {
     
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //MY RIGHT CLICK DOESNT INPUT???
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            Debug.Log("Right Click");
            Debug.Log("current ParryActive state: " + ParryActive);
            Debug.Log("current Parry Cooldown: " + ParryCooldown);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !ParryActive && ParryCooldown <= 0)
        {
            ParryActive = true;
            ParryTime = 0.5f;
            ParryCooldown = 2f;

        }
        if (ParryActive && ParryTime > 0)
        {
            ParryTime -= Time.fixedDeltaTime;
            spriteRenderer.color = new Color(0.576f, 0.709f, 0.8f);

        }
        else if (ParryActive && ParryTime <= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1f);
            ParryActive = false;
        }

        if (damageinvistimer > 0 && dmginvincibility)
        {
            damageinvistimer -= Time.fixedDeltaTime;
        }
        if (damageinvistimer <= 0 && dmginvincibility)
        {
            invincible = false;
            dmginvincibility = false;
        }
        if (ParryCooldown > 0)
        {
            ParryCooldown -= Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" && ParryActive)
        {
            Quaternion oldRotation = collision.gameObject.transform.rotation;
            GameObject parryBullet = Instantiate(bulletParryPrefab, collision.gameObject.transform.position, gameObject.transform.rotation);
            parryBullet.GetComponent<Rigidbody2D>().AddForce(parryBullet.transform.up * parryForce, ForceMode2D.Impulse);
            if (Mathf.Abs(oldRotation.z) - Mathf.Abs(gameObject.transform.rotation.z) > 90)
            {
                parryBullet.transform.rotation = oldRotation;
            }
            Destroy(collision.gameObject);
        }
    }

    public void Shoot()
    {

    }


    public void SetHearts()
    {
        for (int i = 0; i < playerHealth._currentMaxHealth; i++)
        {
            if (playerHealth._currentHealth > i)
            {
                HeartObjects[i].SetActive(true);
            }
            else
            {
                HeartObjects[i].SetActive(false);
            }
        }
    }
}
