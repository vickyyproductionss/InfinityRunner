using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    
 
    // Update is called once per frame
    void Update()
    {
        ScoreInModern();
        if (FindObjectOfType<GameManager>().isGameOver == true)
        {
            scoreText.text = "GAME OVER!!!";
        }
    }

    void ScoreInModern()
    {
        if (player.position.z < 10000)
        {
            scoreText.text = player.position.z.ToString("0");
        }
        else if(player.position.z >= 10000 && player.position.z < 100000)
        {
            scoreText.text = ((player.position.z) / (1000)).ToString("F1") + "k";
        }
        else if (player.position.z >= 100000 && player.position.z < 1000000)
        {
            scoreText.text = ((player.position.z) / (1000)).ToString("F0") + "k";
        }
        else if (player.position.z >= 1000000 && player.position.z < 100000000)
        {
            scoreText.text = ((player.position.z) / (1000)).ToString("F0") + "M";
        }
        else
        {
            scoreText.text = player.position.z.ToString("0");
        }
    }
}
