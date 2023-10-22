using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manageLeaderboardLogin : MonoBehaviour
{
    public GameObject onLoginSuccess;
    public GameObject onLoginfailed;
    public TMP_Text onLoginSuccess_text;

    // Start is called before the first frame update
    void Start()
    {
        LoginUpdates();
    }

    public void LoginUpdates()
    {
        if ( loginWithPlayFab.instance.loggedIn == true)
        {
            if (PlayerPrefs.GetString("PlayerName") != "")
            {
                onLoginSuccess_text.text = "Logged in successfully as " + PlayerPrefs.GetString("PlayerName");
            }
            if (PlayerPrefs.GetString("PlayerName") == "")
            {
                onLoginSuccess_text.text = "Logged in successfully kindly update your name/username.";
            }
            onLoginfailed.SetActive(false);
            onLoginSuccess.SetActive(true);

        }
        if ( loginWithPlayFab.instance.loggedIn == false)
        {
            onLoginSuccess.SetActive(false);
            onLoginfailed.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
