using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pause;
    public GameObject play;
    public GameObject mute;
    public GameObject unmute;
    public AudioSource bgMusic;

    bool GamePaused;


    // Start is called before the first frame update
    void Start()
    {
        
        GamePaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        bgMusic.Pause();
        GamePaused = true;
        play.SetActive(true);
        pause.SetActive(false);
        
    }

    public void ResumeGame()
    {
        bgMusic.Play();
        GamePaused = false;
        pause.SetActive(true);
        play.SetActive(false);       
    }

    public void toMute()
    {
        bgMusic.Stop();
        unmute.SetActive(true);
        mute.SetActive(false);

    }
    public void toUnmute()
    {
        bgMusic.Play();
        mute.SetActive(true);
        unmute.SetActive(false);
    }
}
