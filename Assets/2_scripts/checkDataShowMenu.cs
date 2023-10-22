using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDataShowMenu : MonoBehaviour
{
    public GameObject screenWithDatabase;
    public GameObject screenToPlayDirect;

    void Start()
    {
        PlayerPrefs.GetFloat("highscore", 0).ToString("#");
        if(!PlayerPrefs.HasKey("highscore"))
        {
            screenWithDatabase.SetActive(true);
            screenToPlayDirect.SetActive(false);
            
        }
        else
        {
            screenWithDatabase.SetActive(false);
            screenToPlayDirect.SetActive(true);
        }

    }
    void Update()
    {
        
    }
}
