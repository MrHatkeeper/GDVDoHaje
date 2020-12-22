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
        Debug.Log(timer);
        speed = mP.moveSpeed + 5;


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

            speed += fllwSpeed;
            transform.position = Vector2.MoveTowards(transform.position, enemyProjectile[0].transform.position, speed * Time.deltaTime);
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
}
