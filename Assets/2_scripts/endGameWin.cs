using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameWin : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManagerScript;
    public highScore highscoreScript;
    public GameObject endGameScreen;
    public GameObject breakingscoreTxt;
    public Text scoretxt;
    public Text highScoretxt;
    public Text infoaboutHowFarTobreakHighScore;
    public AudioSource endGameSound;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.timeToShowEndScreen == true)
        {
            endGameSound.Stop();
            endGameScreen.SetActive(true);
            scoretxt.text = "Your score in this game was: " + gameManagerScript.ScoreWhenGameEnded;
            highScoretxt.text = "Your own highscore is currently: " + PlayerPrefs.GetFloat("highscore", 0).ToString("#");

            if(highscoreScript.highscoreBreaked == false)
            {
                float difference = (PlayerPrefs.GetFloat("highscore", 0) - (float)int.Parse(gameManagerScript.ScoreWhenGameEnded));
                infoaboutHowFarTobreakHighScore.text = "You were only " + difference.ToString("#") +"m far from breaking your own highscore.";
            }
            else if(highscoreScript.highscoreBreaked == true)
            {
                breakingscoreTxt.SetActive(true);
                infoaboutHowFarTobreakHighScore.text = "";
            }
        }
    }
}
