using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    swordDefence sD;
    private float timer = 10;

    // Use this for initialization
    void Start() {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Door") || collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
        
        if (collision.CompareTag("sword"))
        {
            sD = GameObject.FindGameObjectWithTag("sword").GetComponent<swordDefence>();
            
            if (sD.isBlocking)
            {
                Destroy(gameObject);
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Door") || collision.collider.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}

