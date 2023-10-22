using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_for_options : MonoBehaviour
{
    public GameObject settingsWin;
    //public GameObject rewardedAdUI;
    public Slider sensitivitySlider;

    public static script_for_options instance;


    private void Start()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("sens_value");
    }

    public void Contact()
    {
        Application.OpenURL("https://www.instagram.com/vickyy_productionss?utm_medium=copy_link");
    }
    public void openSettingsWin()
    {
        settingsWin.SetActive(true);
    }

    public void closeSettingsWin()
    {
        settingsWin.SetActive(false);
    }

    public void EarnReward()
    {
        //enhance_script.instance.ShowRewardedAd();
    }

    public void sliderControl()
    {
        PlayerPrefs.SetFloat("sens_value", sensitivitySlider.value);
    }

    public void MessageDev()
    {
        Application.OpenURL("https://www.instagram.com/vickyy_productionss?utm_medium=copy_link");
    }

    public void checkUpdates()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.vicky_productions.infinityrunner");
    }

    public void collectReward()
    {
        PlayerPrefs.SetInt("diamondsAmount", PlayerPrefs.GetInt("diamondsAmount") + 20);
    }
}
