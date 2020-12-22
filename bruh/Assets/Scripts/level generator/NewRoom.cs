using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{

    private int rand;
    public GameObject player;
    public GameObject[] mistnost;
    private GameObject[] enemy;
    public int doorNumber;
    private AstarPath aStar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        aStar = GameObject.FindGameObjectWithTag("aStarGraph").GetComponent<AstarPath>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length == 0)
        {
            if (collision.collider.CompareTag("Player"))
            {
                if (doorNumber == 1)
                {
                    player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 145);
                }
                else if (doorNumber == 2)
                {
                    player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 145);
                }
                else if (doorNumber == 3)
                {
                    player.transform.position = new Vector2(player.transform.position.x - 145, player.transform.position.y);
                }
                else if (doorNumber == 4)
                {
                    player.transform.position = new Vector2(player.transform.position.x + 145, player.transform.position.y);
                }
                rand = Random.Range(0, mistnost.Length);
                Destroy(transform.parent.gameObject);
                Instantiate(mistnost[rand], gameObject.transform.parent.position, mistnost[rand].transform.rotation);

                aStar.Scan();
            }
        }
    }
}
