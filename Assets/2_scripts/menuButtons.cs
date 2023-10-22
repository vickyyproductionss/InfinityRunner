using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playerProfile;

    public void OpenPlayerProfile()
    {
        mainMenu.SetActive(false);
        playerProfile.SetActive(true);
    }
    public void backToMainMenu()
    {
        mainMenu.SetActive(true);
        playerProfile.SetActive(false);
    }
}
