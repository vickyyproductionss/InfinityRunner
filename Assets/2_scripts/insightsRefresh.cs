using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insightsRefresh : MonoBehaviour
{
    public Text highscore;
    public Text diamonds;
    public Text matchesPlayed;
    public Text easySpeed;
    public Text mediumSpeed;
    public Text hardSpeed;
    public Text difficultyLevel;

    public static insightsRefresh instance;
    public void Start()
    {
        UpdateInsights();
    }

    public void UpdateInsights()
    {
        highscore.text = PlayerPrefs.GetFloat("highscore", 0).ToString("#");
        if (PlayerPrefs.HasKey("diamondsAmount"))
        {
            diamonds.text = PlayerPrefs.GetInt("diamondsAmount").ToString("#");
        }
        else if (!PlayerPrefs.HasKey("diamondsAmount"))
        {
            diamonds.text = "0";
        }
        if (PlayerPrefs.HasKey("matches_played"))
        {
            matchesPlayed.text = PlayerPrefs.GetInt("matches_played").ToString("#");
        }
        else if (!PlayerPrefs.HasKey("matches_played"))
        {
            matchesPlayed.text = "0";
        }
        if(PlayerPrefs.HasKey("easySpeed"))
        {
            easySpeed.text = PlayerPrefs.GetFloat("easySpeed").ToString("#") + "km/h";
            
        }
        else if(!PlayerPrefs.HasKey("easySpeed"))
        {
            easySpeed.text = "0km/h";
        }
        if (PlayerPrefs.HasKey("mediumSpeed"))
        {
            mediumSpeed.text = PlayerPrefs.GetFloat("mediumSpeed").ToString("#") + "km/h";
            
        }
        else if (!PlayerPrefs.HasKey("mediumSpeed"))
        {
            mediumSpeed.text = "0km/h";
        }
        if (PlayerPrefs.HasKey("hardSpeed"))
        {
            hardSpeed.text = PlayerPrefs.GetFloat("hardSpeed").ToString("#") + "km/h";
            
        }
        else if (!PlayerPrefs.HasKey("hardSpeed"))
        {
            hardSpeed.text = "0km/h";
        }
        if (PlayerPrefs.HasKey("difficultyLevel"))
        {
            if(PlayerPrefs.GetInt("difficultyLevel") == 0)
            {
                difficultyLevel.text = "Easy";
            }
            if (PlayerPrefs.GetInt("difficultyLevel") == 1)
            {
                difficultyLevel.text = "Medium";
            }
            if (PlayerPrefs.GetInt("difficultyLevel") == 2)
            {
                difficultyLevel.text = "Hard";
            }
        }
        if (!PlayerPrefs.HasKey("difficultyLevel"))
        {
            difficultyLevel.text = "Easy";
        }
        else if (!PlayerPrefs.HasKey("hardSpeed"))
        {
            hardSpeed.text = "0km/h";
        }
    }
}
