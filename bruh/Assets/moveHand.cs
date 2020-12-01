using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHand : MonoBehaviour
{
    public float offset;


    private float timeBtwShots;
    public float startTimeBtwShots;



    private void Update()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset + 90f);

        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
          //      GameObject bulletClone = Instantiate(projectile, shootPoint.position, transform.rotation);
          //      timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
