using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDefence : MonoBehaviour
{

    private Transform defaultPos;
    public bool isBlocking;
    private float speed;
    private MovementPlayer mP;
    private int blockedProjectiles;
    public int maxBlock;
    public float fllwSpeed;
    public float cooldown;
    private float timer;

    private GameObject[] enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        isBlocking = false;
        defaultPos = GameObject.FindGameObjectWithTag("swordDefault").GetComponent<Transform>();
        mP = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        speed = mP.moveSpeed + 10;


        if (maxBlock == blockedProjectiles)
        {
            isBlocking = false;
            blockedProjectiles = 0;
        }

     
        if (isBlocking == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, defaultPos.position, speed * Time.deltaTime);
            speed -= fllwSpeed;
        }

        if (Input.GetButtonDown("blockBySword") && !isBlocking && timer <= 0)
        {
            isBlocking = true;
        }

        if (isBlocking)
        {
            enemyProjectile = GameObject.FindGameObjectsWithTag("enemyBullet");

            if (enemyProjectile.Length > 0)
            {
                speed += fllwSpeed;


                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float closestDist = Mathf.Infinity;
                GameObject bestTarget = null;
                
                for(int i = 0; i < enemyProjectile.Length; i++)
                {
                    Vector3 directionToTarget = enemyProjectile[i].transform.position - worldPosition;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;

                    if (dSqrToTarget < closestDist){
                        closestDist = dSqrToTarget;
                        bestTarget = enemyProjectile[i];
                    }
                }


                transform.position = Vector2.MoveTowards(transform.position, bestTarget.transform.position, speed * Time.deltaTime);
            }
            else
            {
                isBlocking = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBlocking == true)
        {
            if (collision.CompareTag("enemyBullet"))
            {
                blockedProjectiles += 1;
                timer = cooldown;
            }
        }
    }

    public void moveDefaultPos()
    {
        transform.position = defaultPos.transform.position;
    }
}
