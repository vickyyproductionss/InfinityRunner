using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highScore : MonoBehaviour
{
    public GameManager GamemanagerScript;
    public Text score;
    public Text coins;
    public GameObject player;
    public Text highscore;
    public GameObject newHighscore;
    int i = 0;
    int j;
    public bool highscoreBreaked = false;
    public static highScore instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        j = 0;
        
        highscore.text = GameManager.instance.convertToKiloSystem(PlayerPrefs.GetFloat("highscore", 0));
        //highscore.text = PlayerPrefs.GetFloat("highscore", 0).ToString("#");
    }
    public void setHighScore()
    {
        if(GamemanagerScript.isGameOver == false)
        {
            //PlayerPrefs.SetFloat("highscore", curScore);
            if (ballMotion.instance.currentScore >= PlayerPrefs.GetFloat("highscore", 0))
            {
                PlayerPrefs.SetFloat("highscore", ballMotion.instance.currentScore);
            }
            if (j == 0)
            {
                if (ballMotion.instance.currentScore >= PlayerPrefs.GetFloat("highscore", 0))
                {
                    j = 1;
                    highscoreBreaked = true;
                }
            }
        }
        

    }
    void NewHighScore()
    {
        newHighscore.SetActive(true);
        Invoke("HideNewScoreText", 1.5f);
    }
    void HideNewScoreText()
    {
        newHighscore.SetActive(false);
    }
    void Update()
    {
        if(ballMotion.instance.player.transform.position.z <= 0)
        {
            score.text = "0";
        }
        else
        {
            score.text = GameManager.instance.convertToKiloSystem((ballMotion.instance.currentScore));
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        coins.text = GameManager.instance.convertToKiloSystem((PlayerPrefs.GetInt("coins_amount")));
        if(GamemanagerScript.isGameOver == false)
        {
            if (ballMotion.instance.currentScore > PlayerPrefs.GetFloat("highscore", 0) && i == 0)
            {
                Invoke("NewHighScore", 0f);
                i++;
            }
            setHighScore();
        }
    }
}
