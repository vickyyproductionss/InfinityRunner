using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButtonFromPresentScreen : MonoBehaviour
{
    public GameObject presentScreen;
    public GameObject backScreen;

    public void back()
    {
        presentScreen.SetActive(false);
        backScreen.SetActive(true);
    }
}
