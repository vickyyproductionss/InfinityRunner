using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfoAboutUpdates : MonoBehaviour
{
    public GameObject infoBar;
    bool infoBarShown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void showHide()
    {
        if(infoBarShown == false)
        {
            infoBar.SetActive(true);
            infoBarShown = true;
        }
        else
        {
            infoBar.SetActive(false);
            infoBarShown = false;
        }
    }
}
