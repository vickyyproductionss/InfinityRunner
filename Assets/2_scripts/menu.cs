using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    //bool GamePaused;
    bool PlayingBGM = true;
    public static menu instance;
    
    public GameObject PauseButton;
    public GameObject muteButton;
    public GameObject PauseMenuWin;
    public GameObject unmuteButton;
    public GameObject musicButton;
    public GameObject musicmuteButton;
    public AudioSource BackgroundMusic;
    public AudioSource MusicOnEndGame;
    public AudioListener audioListener;
    public GameObject controls;

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

    void Start()
    {
        
        //GamePaused = false;

    }

    void Update()
    {
        /*if (GamePaused)
        {
            Time.timeScale = 0f;
            BackgroundMusic.Pause();
        }
        else
        {
            Time.timeScale = 1f;
        }*/
            
    }


    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void goToGame1()
    {
        Debug.Log("sucessfully started");
        SceneManager.LoadScene("1_game");
        
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("0_menu");
    }

    public void OnExit()
    {
        SceneManager.LoadScene("0_menu");
    }

    public void OnPause()
    {
        //Time.timeScale = 0f;
        ballMotion.instance.rb.constraints = RigidbodyConstraints.FreezePosition;
        BackgroundMusic.Pause();
        MusicOnEndGame.Pause();
        controls.SetActive(false);
        //GamePaused = true;
        PauseButton.SetActive(false);
        PauseMenuWin.SetActive(true);
        mission_manager.instance.UpdateMissionPurchasingPrice();
    }

    public void OnResume()
    {
        PauseMenuWin.SetActive(false);
        //GamePaused = false;
        Time.timeScale = 1;
        resumingTextScript.instance.ShowResumingtexts();
        Invoke("FunctionsResume", 3);

    }

    public void FunctionsResume()
    {
        
        PauseButton.SetActive(true);
        controls.SetActive(true);
        BackgroundMusic.UnPause();
        MusicOnEndGame.UnPause();
        if (PlayingBGM == true)
        {
            BackgroundMusic.volume = 0.17f;
        }
        else if (PlayingBGM == false)
        {
            BackgroundMusic.volume = 0;
            MusicOnEndGame.Pause();
        }
    }

    public void OnMusicStop()
    {
        PlayingBGM = false;
        musicmuteButton.SetActive(true);
        musicButton.SetActive(false);
        
    }

    public void OnMusicPlay()
    {
        PlayingBGM = true;
        musicmuteButton.SetActive(false);
        musicButton.SetActive(true);
    }

    public void OnMute()
    {
        audioListener.enabled = false;
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);

    }

    public void OnUnmute()
    {
        audioListener.enabled = true;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }




    public void OnRestart()
    {
        SceneManager.LoadScene("1_game");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
