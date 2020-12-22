using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int xSpawn;
    private int ySpawn;

    private int value = 10;


    private float speed = 0.5f;


    private Vector2 position;

    private void Start()
    {
        xSpawn = Random.Range(Random.Range(-80, -60), Random.Range(60, 80));
        ySpawn = Random.Range(Random.Range(-80, -60), Random.Range(60, 80));
        position = new Vector2(transform.position.x + Random.Range(-xSpawn, xSpawn), transform.position.y + Random.Range(-ySpawn, ySpawn));
    }


    void FixedUpdate()
    {
        if(transform.position.x != position.x && transform.position.y != position.y)
        {
            if(transform.position.x <= position.x)
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y);
            }
            if (transform.position.x >= position.x)
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y);
            }
            if(transform.position.y <= position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed);
            }
            if (transform.position.y >= position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed);
            }
            speed = speed / 1.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Credits credits = collision.GetComponent<Credits>();

        if(credits != null)
        {
            credits.credits += value;
            Destroy(gameObject);
        }
    }
}
