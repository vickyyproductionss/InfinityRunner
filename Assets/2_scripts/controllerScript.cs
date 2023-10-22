using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerScript : MonoBehaviour
{
    public static controllerScript instance;
    public Slider sensitivitySlider;
    public float slidervalue; 
    void Start()
    {
        sensitivitySlider = GetComponent<Slider>();
        if(!PlayerPrefs.HasKey("sensitivity_value"))
        {
            sensitivitySlider.value = 0.8f;
            PlayerPrefs.SetFloat("sens_value", 0.8f);
            
        }
        else
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity_value");
            PlayerPrefs.SetFloat("sens_value", PlayerPrefs.GetFloat("sensitivity_value"));
        }
        Load();
    }

    public void controlSensitivity()
    {
        PlayerPrefs.SetFloat("sens_value", sensitivitySlider.value);
        Save();
    }

    public void Load()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity_value");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("sensitivity_value", sensitivitySlider.value);
    }
}
