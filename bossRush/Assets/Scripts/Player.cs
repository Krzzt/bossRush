using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UnitHealth playerHealth = new UnitHealth(3, 3);
    public bool invincible;

    public int damage;

    public float damageinvistimer;
    public bool dmginvincibility;
    public bool ParryActive;

    public float ParryTime;

    public SpriteRenderer spriteRenderer;

    public GameObject bulletParryPrefab;
    public int parryForce;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (!invincible)
        {
            playerHealth.DamageUnit(amount);
            damageinvistimer = 2;
            dmginvincibility = true;
            invincible = true;
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
        if (Input.GetMouseButtonDown(1) && !ParryActive)
        {
            ParryActive = true;
            ParryTime = 0.5f;

        }
        if (ParryActive && ParryTime > 0)
        {
            ParryTime -= Time.deltaTime;

        }
        else if (ParryActive && ParryTime <= 0)
        {
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" && ParryActive)
        {

            GameObject parryBullet = Instantiate(bulletParryPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation );
            parryBullet.transform.Rotate(0, 0, 180);
            parryBullet.GetComponent<Rigidbody2D>().AddForce(parryBullet.transform.up * parryForce, ForceMode2D.Impulse);
                 Destroy(collision.gameObject);
        }
    }

    public void Shoot()
    {

    }
}
