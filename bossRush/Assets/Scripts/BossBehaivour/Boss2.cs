using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public int bossID;

    private GameObject PlayerObject;

    public int speed;
    public int frames;

    public int currPhase;
    public float movetimer;
    public float timebetweenmoves;


    public Transform[] bulletTransform;
    private Vector3[] TeleportVectors = new Vector3[8];
    private Vector3 currVec;
    private Vector3 moveTowards;

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

    public GameObject Cage;
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

            // DOESNT WORK FOR NOW
            time += Time.fixedDeltaTime;
            if (time % 2f <= 0.03)
            {
                TeleportVectors[0] = PlayerObject.transform.position + new Vector3(8, 0, 0);
                TeleportVectors[1] = PlayerObject.transform.position + new Vector3(4, -4, 0);
                TeleportVectors[2] = PlayerObject.transform.position + new Vector3(0, -8, 0);
                TeleportVectors[3] = PlayerObject.transform.position + new Vector3(-4, -4, 0);
                TeleportVectors[4] = PlayerObject.transform.position + new Vector3(-8, 0, 0);
                TeleportVectors[5] = PlayerObject.transform.position + new Vector3(-4, 4, 0);
                TeleportVectors[6] = PlayerObject.transform.position + new Vector3(0, 8, 0);
                TeleportVectors[7] = PlayerObject.transform.position + new Vector3(4, 4, 0);
                currVec = TeleportVectors[Random.Range(0, 8)];
                gameObject.transform.position = currVec;
                moveTowards = PlayerObject.transform.position - gameObject.transform.position;
                moveTowards.Normalize();

            }

           
            gameObject.transform.position += (moveTowards * 0.15f);


            if (time >= 13f)
            {
                GameObject currCage = GameObject.FindWithTag("Cage");
                if (currCage != null)
                {
                    Destroy(currCage);
                }
                time = 0;
                attack1active = false;
            }
        }
        else if (attack2active)
        {
            time += Time.fixedDeltaTime;
            if (time % 1.5f <= 0.03f)
            {
                TeleportVectors[0] = PlayerObject.transform.position + new Vector3(10, 0, 0);
                TeleportVectors[1] = PlayerObject.transform.position + new Vector3(5, -5, 0);
                TeleportVectors[2] = PlayerObject.transform.position + new Vector3(0, -10, 0);
                TeleportVectors[3] = PlayerObject.transform.position + new Vector3(-5, -5, 0);
                TeleportVectors[4] = PlayerObject.transform.position + new Vector3(-10, 0, 0);
                TeleportVectors[5] = PlayerObject.transform.position + new Vector3(-5, 5, 0);
                TeleportVectors[6] = PlayerObject.transform.position + new Vector3(0, 10, 0);
                TeleportVectors[7] = PlayerObject.transform.position + new Vector3(5, 5, 0);
                currVec = TeleportVectors[Random.Range(0, 8)];
                gameObject.transform.position = currVec;
                Vector2 direction = PlayerObject.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                GameObject[] bullets = new GameObject[7];
                gameObject.transform.Rotate(0, 0, -108);
                for (int i = 0; i < 6; i++)
                {
                    bullets[i] = Instantiate(bulletPrefab, bulletTransform[1].position, gameObject.transform.rotation);
                    bullets[i].GetComponent<Rigidbody2D>().AddForce(bullets[i].transform.up * bulletFireForce * 2, ForceMode2D.Impulse);
                    gameObject.transform.Rotate(0, 0, 6);
                }

            }
            if (time >= 9)
            {
                GameObject currCage = GameObject.FindWithTag("Cage");
                if (currCage != null)
                {
                    Destroy(currCage);
                }
                time = 0;
                attack2active = false;
            }

        }
        else if (attack3active)
        {
            time += Time.deltaTime;

            if (time > 3)
            {
                GameObject currCage = Instantiate(Cage, PlayerPos, Quaternion.identity);
                time = 0;
                attack3active = false;
            }


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
                        Debug.Log("move to do: " + moveToDo);
                        time += Time.fixedDeltaTime;
                        switch (moveToDo)
                        {
                            case 0:
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
        if (!attack1active && !attack2active)
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
            // Debug.Log("xpostomove: " + xpostomove);
            // Debug.Log("currxpos: " + this.transform.position.x);
            // Debug.Log("Added: " + xpos);
            ypos = (float)ypostomove + this.transform.position.y;
            Vector2 moveGoal = new Vector2(xpos, ypos);
            gameObject.transform.position = Vector2.MoveTowards(this.transform.position, moveGoal, speed * Time.fixedDeltaTime);


        }

    }


}
