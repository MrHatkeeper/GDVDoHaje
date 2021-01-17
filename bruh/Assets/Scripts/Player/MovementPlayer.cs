using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

    public float moveSpeed;
    public float timeBtwDash;
    private float timeDash;
    private float dashCd;
    private bool dashAsctive;
    public Rigidbody2D rb;
    public Transform sparkle;

    public bool rotate = true; 

    Vector2 movement;

    float movementRotate;

    private SpawnPoint spawnPoint;


    private void Start()
    {
        timeDash = timeBtwDash;
    }

    // Use this for initialization
    void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movementRotate = Input.GetAxis("Horizontal");

        timeDash -= Time.deltaTime;

        //dash funkce
        if(timeDash <= 0 && Input.GetKeyDown("space") && !dashAsctive)
        {
            moveSpeed += 50;

            dashCd = 0.2f;
            dashAsctive = true;
        }
        if (dashCd > 0)
        {
            dashCd -= Time.deltaTime;
        }
        if (dashCd <= 0 && dashAsctive)
        {
            moveSpeed -= 50;

            dashAsctive = false;
            timeDash = timeBtwDash;
        }

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movementRotate < 0 && rotate) Flip();
        if (movementRotate > 0 && !rotate) Flip();
    }


    void Flip()
    {
        rotate = !rotate;
        transform.Rotate(Vector3.up * 180);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemyBullet") || collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(sparkle, transform.position, sparkle.transform.rotation);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBullet") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(sparkle, transform.position, sparkle.transform.rotation);
        }
    }


}
