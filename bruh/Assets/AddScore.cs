using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{

    public GameObject player;
    public TextMeshProUGUI scoreText;
    private Credits c;

    private void Start()
    {
        c = player.GetComponent<Credits>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + c.credits;
    }
}
