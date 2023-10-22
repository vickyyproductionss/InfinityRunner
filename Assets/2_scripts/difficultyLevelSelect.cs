using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyLevelSelect : MonoBehaviour
{
    public Toggle easy;
    public Toggle medium;
    public Toggle hard;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("difficultyLevel"))
        {
            PlayerPrefs.SetInt("difficultyLevel", 0);
        }
        if(PlayerPrefs.GetInt("difficultyLevel") == 0)
        {
            easy.isOn = true;
            medium.isOn = false;
            hard.isOn = false;
        }
        else if(PlayerPrefs.GetInt("difficultyLevel") == 1)
        {
            easy.isOn = false;
            medium.isOn = true;
            hard.isOn = false;
        }
        else if (PlayerPrefs.GetInt("difficultyLevel") == 2)
        {
            easy.isOn = false;
            medium.isOn = false;
            hard.isOn = true;
        }
    }

    // Update is called once per frame
   
    public void chooseLevel()
    {
        
    }

    public void easyLevel()
    {
        PlayerPrefs.SetInt("difficultyLevel", 0);
    }
    public void mediumLevel()
    {
        PlayerPrefs.SetInt("difficultyLevel", 1);
    }
    public void hardLevel()
    {
        PlayerPrefs.SetInt("difficultyLevel", 2);
    }

}
