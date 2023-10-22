using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    
    public bool isGameOver = false;
    public bool isAdWatched = false;
    public bool timeToShowEndScreen = false;
    public AudioSource whilePlayingBGM;
    public AudioSource onGameOverBGM;
    public string ScoreWhenGameEnded;
    public highScore highscoreScript;
    public GameObject routeChoosingWin;
    public GameObject obstaclesChoosingWin;
    
    public Text fpsText;
    public TMP_Text diamondsVal_playerWin;
    public TMP_Text diamondsVal_routeWin;
    public TMP_Text diamondsVal_glowWin;
    public float hudRefreshRate = 1;
    private float timer;

    public GameObject screenWithRouteChoosingButton;
    public GameObject PauseButton;
    public static GameManager instance;
    public GameObject endGameScreen;
    public int watchAdChances = 1;
    public GameObject buttonToShowAd;
    public Text chancesLeft;
    public Text level_label;
    public GameObject chancesoverWarning;
    public bool clearPlayerPrefs = false;
    public Toggle useButtonsToControl;
    public GameObject buttonController;
    public GameObject sensitivityController;
    public string output;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            
            if (PlayerPrefs.HasKey("GameLevel"))
            {
                level_label.text = PlayerPrefs.GetInt("GameLevel").ToString();
            }
            else
            {
                level_label.text = 1.ToString();
            }
            
        }
        UpdateDiamondsVal();
        Application.targetFrameRate = 100;
        Time.timeScale = 1;
        enhance_script.instance.RequestBanner();
    }

    public void UpdateDiamondsVal()
    {
        if (diamondsVal_routeWin && SceneManager.GetActiveScene().buildIndex == 0)
        {
            diamondsVal_routeWin.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        }
        if (diamondsVal_playerWin && SceneManager.GetActiveScene().buildIndex == 0)
        {
            diamondsVal_playerWin.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        }
        if (diamondsVal_glowWin && SceneManager.GetActiveScene().buildIndex == 0)
        {
            diamondsVal_glowWin.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        }
    }
    public string convertToKiloSystem(float val)
    {
        if (val < 10000)
        {
            output = val.ToString("0");
        }
        else if (val >= 10000 && val < 1000000)
        {
            output = (val / 1000).ToString("F1") + "K";
        }
        else if (val >= 1000000 && val < 1000000000)
        {
            output = (val / 1000000).ToString("F1") + "M";
        }
        else if (val >= 1000000000)
        {
            output = (val / 1000000000).ToString("F1") + "B";
        }
        return output; 

    }

    public void OncontrollerChange()
    {
        if (useButtonsToControl.isOn)
        {
            buttonController.SetActive(true);
            sensitivityController.SetActive(true);
            PlayerPrefs.SetInt("useButtonsControl", 1);
        }
        if (!useButtonsToControl.isOn)
        {
            buttonController.SetActive(false);
            sensitivityController.SetActive(false);
            PlayerPrefs.SetInt("useButtonsControl", 0);
        }
        if (PlayerPrefs.GetInt("useButtonsControl", 0) == 1)
        {
            buttonController.SetActive(true);
            sensitivityController.SetActive(true);
        }

        if (PlayerPrefs.GetInt("useButtonsControl", 0) == 0)
        {
            buttonController.SetActive(false);
            sensitivityController.SetActive(false);
        }
    }
    public void AdWatched()
    {
        isAdWatched = true;
    }
    private void Update()
    {
        if (clearPlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
            clearPlayerPrefs = false;
        }
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Time.unscaledTime > timer)
            {
                int fps = (int)(1f / Time.unscaledDeltaTime);
                fpsText.text = fps.ToString();
                timer = Time.unscaledTime + hudRefreshRate;
            }
        }
        

    }

    public void EndGame()
    {
        chancesLeft.text ="(" + watchAdChances.ToString() + ")";
        if (isGameOver == false && isAdWatched == false)
        {
            
            PauseButton.SetActive(false);
            whilePlayingBGM.Pause();
            onGameOverBGM.Play();
            isGameOver = true;
            Invoke("callingEndGameScreen", 3f);
            
            if(PlayerPrefs.HasKey("matches_played"))
            {
                PlayerPrefs.SetInt("matches_played", PlayerPrefs.GetInt("matches_played") + 1);
            }
            else if(!PlayerPrefs.HasKey("matches_played"))
            {
                PlayerPrefs.SetInt("matches_played", 1);
            } 
        }
        else if(isAdWatched == true)
        {
            ballMotion.instance.transform.position = new Vector3(0, ballMotion.instance.groundTile.transform.position.y + 0.7f, highscoreScript.player.transform.position.z - 10);
            endGameScreen.SetActive(false);
            timeToShowEndScreen = false;
            PauseButton.SetActive(true);
            whilePlayingBGM.UnPause();
            onGameOverBGM.Stop();
            ballMotion.instance.gameIsStarted = true;
            ballMotion.instance.gameIsEnded = false;
            collision.instance.enableScript();
            isAdWatched = false;
            isGameOver = false;        
            watchAdChances--;
        }
        if(watchAdChances == 0 || watchAdChances < 0)
        {
            buttonToShowAd.SetActive(false);
            chancesoverWarning.SetActive(true);
        }
        
    }

    void callingEndGameScreen()
    {
        Time.timeScale = 0f;
        timeToShowEndScreen = true;
        highScore.instance.setHighScore();
        PlayerPrefs.DeleteKey("firstTimeGame");
        PlayerPrefs.DeleteKey("boostGap");
        PlayerPrefs.DeleteKey("activateBoosters");
        ScoreWhenGameEnded = (ballMotion.instance.currentScore).ToString("#");
    }
    public void ReStart()
    {
        PlayerPrefs.DeleteKey("firstTimeGame");
        PlayerPrefs.DeleteKey("boostGap");
        PlayerPrefs.DeleteKey("activateBoosters");
        Time.timeScale = 1;
        Invoke("restarting", 1);
        
    }
    void restarting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void chooseRoutes()
    {
        screenWithRouteChoosingButton.SetActive(false);
        routeChoosingWin.SetActive(true);
    }

    public void closeChooseRoutes()
    {
        SceneManager.LoadScene(1);
    }

    public void chooseObstacle()
    {
        screenWithRouteChoosingButton.SetActive(false);
        obstaclesChoosingWin.SetActive(true);
    }
}
