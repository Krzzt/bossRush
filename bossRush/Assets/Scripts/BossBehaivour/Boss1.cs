using System.Collections;
using System.Collections.Generic;
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

    public Transform[] bulletTransform;

    public GameObject bulletPrefab;

    public int bulletFireForce;

    public float time;

    public bool attack1active;
    public bool attack2active;
    public bool attack3active;
    public int amountBullets = 0;
    public bool direction;

    private int xpostomove = 0;
    private int ypostomove = 0;

    public Vector3 PlayerPos;
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
            GameObject[] bulletsToFire = new GameObject[4];
            bulletsToFire[0] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(0, 5, 0), new Quaternion(0, 0, 180, 0));
            bulletsToFire[1] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(5, 0, 0), new Quaternion(0, 0, 90, 0));
            bulletsToFire[2] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(-5, 0, 0), new Quaternion(0, 0, -90, 0));
            bulletsToFire[3] = Instantiate(bulletPrefab, PlayerObject.transform.position + new Vector3(0, -5, 0), new Quaternion(0, 0, 0, 0));
            for (int i = 0; i < bulletsToFire.Length; i++)
            {
               // bulletsToFire[i].GetComponent<Rigidbody2D>().AddForce();
            }


        }
        else if (attack2active)
        {

          
        }
        else if (attack3active)
        {

            
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
