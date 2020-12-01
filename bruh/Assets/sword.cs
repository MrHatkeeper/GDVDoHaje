using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player;

    private float RotateSpeed = 2.5f;
    private float Radius = 1f;
    public float speed = 15f;
    private Vector2 _centre;
    public float _angle;
    private bool isGliding = true;
    private bool swordIsBlocking = false;
    Vector3 swordPos;


    //projectile prefab name -> Projectile_Player_1



    GameObject bullet;

    public Transform objectToFollow;
    public Vector3 offset;

    public float angle { get; private set; }

    void Start()
    {
        swordPos = new Vector3(-2.5f, 3f);


    }





    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGliding == true)
        {
            if (GameObject.FindWithTag("bullet"))
            {
                bullet = GameObject.FindWithTag("bullet");
                blockBullet(bullet);


            }

        }

        if (isGliding == true)
        {

            //Toto dela to ze mec rotuje v urcitem radiusu
            _angle += RotateSpeed * Time.deltaTime;
            _centre = player.transform.position + swordPos;
            Vector3 center = new Vector3(_centre.x, _centre.y);
            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;


            //Jestlize je vzdalenost mezi mecem a pozici kde mec gliduje mensi nez 2 -> mec zacne glidovat.
            if (Vector3.Distance(transform.position, _centre) < 2)
            {

                transform.position = _centre + offset;
                //Jestlize se podminka nesplni -> mec doleti zpatky na misto kde ma glidovat.
            }
            else
            {

                Vector2 moveDir = (_centre).normalized * speed;

                transform.position = Vector2.MoveTowards(transform.position, _centre, speed * Time.deltaTime);
            }


        }




    }


    public void resetSword()
    {
        angle += RotateSpeed * Time.deltaTime;
        _centre = player.transform.position + swordPos;
        Vector3 center = new Vector3(_centre.x, _centre.y);
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }

    public void blockBullet(GameObject bullet)
    {
        isGliding = false;
        swordIsBlocking = true;


        Vector2 moveDir = (bullet.transform.position - transform.position).normalized * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveDir.x, moveDir.y);

        transform.position = Vector2.MoveTowards(transform.position, bullet.transform.position, speed * Time.deltaTime);


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            isGliding = true;
        }
    }

}
