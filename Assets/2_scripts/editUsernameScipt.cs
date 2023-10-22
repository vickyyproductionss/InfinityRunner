using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editUsernameScipt : MonoBehaviour
{

    public GameObject UsernameUpdateWin;
    public GameObject confirmationWindow;
    public GameObject currentWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool windowShown = false;
    public void ShowConfirmationWin()
    {
        
        if (windowShown == false)
        {
            confirmationWindow.SetActive(true);
            windowShown = true;
        }
        else
        {            
            confirmationWindow.SetActive(false);
            windowShown = false;
        }

        
    }
    public void CloseConfirmationWin()
    {
        confirmationWindow.SetActive(false);
        windowShown = false;
    }
    public void ShowUsernameUpdateWin()
    {
        UsernameUpdateWin.SetActive(true);
        confirmationWindow.SetActive(false);
        currentWindow.SetActive(false);
        windowShown = false;
    }
}
