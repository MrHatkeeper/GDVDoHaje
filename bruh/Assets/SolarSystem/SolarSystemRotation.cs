using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemRotation : MonoBehaviour
{

    public int rotation;
    private Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        axis = new Vector3(0, 0, 1);
        rotation = Random.Range(30, 70);

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, axis, Time.deltaTime * rotation);
    }
}
