using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class database : MonoBehaviour
{
    bool openedFirstTime = false;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    [SerializeField] TMP_InputField instagramUsername;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void saveUserData()
    {

        if (instagramUsername.text != "")
        {
            PlayerPrefs.SetFloat("highscore", 0);
            if (openedFirstTime == true)
            {
                screen2.SetActive(true);
                screen1.SetActive(false);
                openedFirstTime = false;
            }
            else
            {
                screen1.SetActive(false);
                screen3.SetActive(true);
            }
            PlayerPrefs.SetString("PlayerName", instagramUsername.text);
        }
        else
        {
            showToast("Please enter instagram username or your name.....", 2);
        } 
    }
    public Text txt;
    void showToast(string text, int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = txt.color;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);

        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }

}
   
    
    

