using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public float startTimeBtwShots;
    private float timeBtwShots;
    public Transform[] shootPoint;
    public GameObject player;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwShots -= Time.deltaTime;

        if (timeBtwShots <= 0)
        {
            if(player.transform.position.x > gameObject.transform.position.x)
            {
                Shoot(1);
            }
            else if (player.transform.position.x < gameObject.transform.position.x)
            {
                Shoot(3);
            }
            else if (player.transform.position.y > gameObject.transform.position.y)
            {
                Shoot(0);
            }
            else if (player.transform.position.y < gameObject.transform.position.y)
            {
                Shoot(4);
            }
        }
    }

    void Shoot(int x)
    {

        Instantiate(projectile, shootPoint[x].transform.position, Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }

}
