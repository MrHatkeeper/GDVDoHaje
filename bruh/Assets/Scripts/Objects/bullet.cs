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
        if (collision.CompareTag("sword") && collision.CompareTag("Projectile"))
        {
            sD = GameObject.FindGameObjectWithTag("sword").GetComponent<swordDefence>();
            if (sD.isBlocking)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

