using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParticle : MonoBehaviour
{

    private float delete;
    // Start is called before the first frame update
    void Start()
    {
        delete = 2;
    }

    // Update is called once per frame
    void Update()
    {
        delete -= Time.deltaTime;

        if (delete <= 0)
        {
            Destroy(gameObject);
        }
    }
}
