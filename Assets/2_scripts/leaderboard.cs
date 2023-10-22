using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour
{

    public GameObject gamescreen;
    public GameObject leaderboardscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showLeaderBoard()
    {
        leaderboardscreen.SetActive(true);
        gamescreen.SetActive(false);
    }
    public void backButtonToGameScreen()
    {
        gamescreen.SetActive(true);
        leaderboardscreen.SetActive(false);       
    }
}
