using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

public class Boss0 : MonoBehaviour
{
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

            if (time >= 0.067f)
            {
                if (direction)
                {
                    gameObject.transform.Rotate(0, 0, 4);
                }
                else
                {
                    gameObject.transform.Rotate(0, 0, -4);
                }
                amountBullets++;
                GameObject[] bullets = new GameObject[8];
                for (int i = 0; i < bullets.Length; i++)
                {
                    bullets[i] = Instantiate(bulletPrefab, bulletTransform[i].position, bulletTransform[i].rotation);
                    bullets[i].GetComponent<Rigidbody2D>().AddForce(bulletTransform[i].up * bulletFireForce, ForceMode2D.Impulse);
                }
                time = 0;
                if (amountBullets >= 30)
                {
                    attack1active = false;
                    amountBullets = 0;

                }
            }


        }
        else if (attack2active)
        {


            attack2active = false;
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
                                attack2active = true;
                                break;

                            case 2:
                                //move3
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
        if (!attack1active)
        {
            Vector2 direction = PlayerObject.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        float xpos = 0;
        float ypos = 0;
        if (frames % Random.Range(20, 60) == 0)
        {
            xpostomove = Random.Range(-100, 101);
            ypostomove = Random.Range(-100, 101);

        }
        xpos = (float)xpostomove + this.transform.position.x;
       // Debug.Log("xpostomove: " + xpostomove);
       // Debug.Log("currxpos: " + this.transform.position.x);
       // Debug.Log("Added: " + xpos);
        ypos = (float)ypostomove + this.transform.position.y;
        Vector2 moveGoal = new Vector2(xpos, ypos);
        gameObject.transform.position = Vector2.MoveTowards(this.transform.position, moveGoal, speed * Time.deltaTime);
    
       
    }

    public static Vector2 CatmullRomTangent(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t)
    {
        return 0.5f * ((-p1 + p3) + 2f * (2f * p1 - 5f * p2 + 4f * p3 - p4) * t + 3f *
                  (-p1 + 3f * p2 - 3f * p3 + p4) * Mathf.Pow(t, 2f));
    }

}