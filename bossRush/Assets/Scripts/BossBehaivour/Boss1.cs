using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public int bossID;

    private GameObject PlayerObject;

    public int speed;
    public int frames;

    public int currPhase;
    public float movetimer;
    public float timebetweenmoves;

    public Transform BulletTransform;

    public GameObject bulletPrefab;

    public GameObject empty;

    public int bulletFireForce;

    public float time;

    public bool attack1active;
    public bool attack2active;
    public bool attack3active;
    public int amountBullets = 0;
    public bool direction;

    private int xpostomove = 0;
    private int ypostomove = 0;

    private Vector3 PlayerPos;

    private GameObject circle;
    public bool once;
    private void Awake()
    {
        PlayerObject = GameObject.FindWithTag("player");
        currPhase = 1;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        move();
        if (attack1active)
        {
            time += Time.fixedDeltaTime;
            if (time > 0.66f)
            {
               
                if (amountBullets % 2 == 0)
                {
                    GameObject[] bulletsToFire = new GameObject[4];
                    bulletsToFire[0] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(0, 5, 0), new Quaternion(0, 0, 180, 0));
                    bulletsToFire[1] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(5, 0, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[2] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(-5, 0, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[3] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(0, -5, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[1].transform.Rotate(0, 0, 90);
                    bulletsToFire[2].transform.Rotate(0, 0, -90);
                    for (int i = 0; i < bulletsToFire.Length; i++)
                    {
                        bulletsToFire[i].GetComponent<Rigidbody2D>().AddForce(bulletsToFire[i].transform.up * bulletFireForce, ForceMode2D.Impulse);
                    }
                }
                else if (amountBullets % 2 != 0)
                {
                    GameObject[] bulletsToFire = new GameObject[4];
                    bulletsToFire[0] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(2.5f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[1] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(-2.5f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[2] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(-2.5f, -2.5f, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[3] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(2.5f, -2.5f, 0), new Quaternion(0, 0, 0, 0));
                    bulletsToFire[0].transform.Rotate(0, 0, 135);
                    bulletsToFire[1].transform.Rotate(0, 0, -135);
                    bulletsToFire[2].transform.Rotate(0, 0, -45);
                    bulletsToFire[3].transform.Rotate(0, 0, 45);
                    for (int i = 0; i < bulletsToFire.Length; i++)
                    {
                        bulletsToFire[i].GetComponent<Rigidbody2D>().AddForce(bulletsToFire[i].transform.up * bulletFireForce, ForceMode2D.Impulse);
                    
                    }
                }

                amountBullets++;
                time = 0;
            }

            
            if (amountBullets >= 4)
            {
                amountBullets = 0;
                time = 0;
                attack1active = false;
            }
          


        }
        else if (attack2active)
        {

            time += Time.fixedDeltaTime;
            PlayerPos = PlayerObject.transform.position;
            circle.transform.position = PlayerPos;
            Vector2 direction = circle.transform.position - gameObject.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            if (Vector3.Distance(PlayerPos, gameObject.transform.position) > Vector3.Distance(PlayerPos, circle.transform.GetChild(0).transform.position) && !once)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, circle.transform.GetChild(0).transform.position, Time.fixedDeltaTime * speed * 9);
                if (time % 0.1f <= 0.05f && time > 1.5f)
                {
                  
                    GameObject bulletFire = Instantiate(bulletPrefab, BulletTransform.position, BulletTransform.rotation);
                    bulletFire.GetComponent<Rigidbody2D>().AddForce(BulletTransform.up * bulletFireForce * 6, ForceMode2D.Impulse);
                }
                if (time >= 5)
                {
                    attack2active = false;
                }

            }
            else
            {
                once = true;
                circle.transform.Rotate(0, 0, 2);
                gameObject.transform.position = circle.transform.GetChild(0).transform.position;
                if (time >= Random.Range(0.1f, 0.9f))
                {
                    GameObject bulletFire = Instantiate(bulletPrefab, BulletTransform.position, BulletTransform.rotation);
                    bulletFire.GetComponent<Rigidbody2D>().AddForce(BulletTransform.up * bulletFireForce, ForceMode2D.Impulse);
                    amountBullets++;
                    time = 0;
                }

            }
           
            if (amountBullets >= 15)
            {
                time = 0;
                amountBullets = 0;
                once = false;
                attack2active = false;
            }

        }
        else if (attack3active)
        {
            attack3active = false;
            
        }
        else
        {

            if (timebetweenmoves < movetimer)
            {
                timebetweenmoves += Time.deltaTime;
            }
            else
            {

                switch (currPhase)
                {

                    case 1:
                        int moveToDo = Random.Range(0, 3);
                        time += Time.fixedDeltaTime;
                        switch (moveToDo)
                        {
                            case 0:
                                if (Random.Range(0, 2) == 0)
                                {
                                    direction = true;
                                }
                                else
                                {
                                    direction = false;
                                }
                                attack1active = true;
                                break;

                            case 1:
                                //move2
                                circle = Instantiate(empty, PlayerPos, Quaternion.identity);
                                attack2active = true;
                                break;

                            case 2:
                                //move3
                                PlayerPos = PlayerObject.transform.position;
                                attack3active = true;
                                break;
                        }
                        break;


                }
                timebetweenmoves = 0;
            }


        }



    }

    public void move()
    {
        if (!attack2active)
        {
            Vector2 direction = PlayerObject.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
       
            float xpos = 0;
            float ypos = 0;
            if (frames % Random.Range(20, 60) == 0)
            {
                xpostomove = Random.Range(-100, 101);
                ypostomove = Random.Range(-100, 101);

            }

            xpos = (float)xpostomove + this.transform.position.x;
            ypos = (float)ypostomove + this.transform.position.y;
            Vector2 moveGoal = new Vector2(xpos, ypos);
            gameObject.transform.position = Vector2.MoveTowards(this.transform.position, moveGoal, speed * Time.fixedDeltaTime);
        }

    }


}
