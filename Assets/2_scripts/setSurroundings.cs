using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSurroundings : MonoBehaviour
{

    public GameObject ErrorWindow;
    public GameObject confirmationWindow1;
    public GameObject confirmationWindow2;
    public GameObject confirmationWindow3;
    public GameObject confirmationWindow4;
    public GameObject confirmationWindow5;
    public GameObject MenuWin;
    public GameObject thisWin;
    public GameObject pricetag1;
    public GameObject pricetag2;
    public GameObject pricetag3;
    public GameObject pricetag4;
    public GameObject pricetag5;



    public insightsRefresh insightsScript;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("purchased_r2"))
        {
            pricetag1.SetActive(false);
        }

        if (PlayerPrefs.HasKey("purchased_r3"))
        {
            pricetag2.SetActive(false);
        }

        if (PlayerPrefs.HasKey("purchased_r4"))
        {
            pricetag3.SetActive(false);
        }

        if (PlayerPrefs.HasKey("purchased_r5"))
        {
            pricetag4.SetActive(false);
        }

        if (PlayerPrefs.HasKey("purchased_r6"))
        {
            pricetag5.SetActive(false);
        }

        PlayerPrefs.SetInt("default", 0);
        //PlayerPrefs.SetInt("diamondsAmount", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void route1()
    {
        PlayerPrefs.SetInt("route", 0);
    }
    public void route2()
    {
        if (PlayerPrefs.GetInt("diamondsAmount") >= 25 && !PlayerPrefs.HasKey("purchased_r2"))
        {
            confirmationWindow1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("diamondsAmount") < 25 && !PlayerPrefs.HasKey("purchased_r2"))
        {
            ErrorWindow.SetActive(true);
        }
        else if(PlayerPrefs.HasKey("purchased_r2"))
        {
            PlayerPrefs.SetInt("route", 1);
            
        }
    }
    public void route3()
    {
        if (PlayerPrefs.GetInt("diamondsAmount") >= 50 && !PlayerPrefs.HasKey("purchased_r3"))
        {
            confirmationWindow2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("diamondsAmount") < 50 && !PlayerPrefs.HasKey("purchased_r3"))
        {
            ErrorWindow.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("purchased_r3"))
        {
            PlayerPrefs.SetInt("route", 2);
        }
    }
    public void route4()
    {
        if (PlayerPrefs.GetInt("diamondsAmount") >= 75 && !PlayerPrefs.HasKey("purchased_r4"))
        {
            confirmationWindow3.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("diamondsAmount") < 75 && !PlayerPrefs.HasKey("purchased_r4"))
        {
            ErrorWindow.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("purchased_r4"))
        {
            PlayerPrefs.SetInt("route", 3);
        }
    }
    public void route5()
    {
        if (PlayerPrefs.GetInt("diamondsAmount") >= 100 && !PlayerPrefs.HasKey("purchased_r5"))
        {
            confirmationWindow4.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("diamondsAmount") < 100 && !PlayerPrefs.HasKey("purchased_r5"))
        {
            ErrorWindow.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("purchased_r5"))
        {
            PlayerPrefs.SetInt("route", 4);
        }
    }
    public void route6()
    {
        if (PlayerPrefs.GetInt("diamondsAmount") >= 150 && !PlayerPrefs.HasKey("purchased_r6"))
        {
            confirmationWindow5.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("diamondsAmount") < 150 && !PlayerPrefs.HasKey("purchased_r6"))
        {
            ErrorWindow.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("purchased_r6"))
        {
            PlayerPrefs.SetInt("route", 5);
        }
    }
    public void hideErrorWin()
    {
        ErrorWindow.SetActive(false);
    }
    public void Purchase1()
    {
        Debug.Log("p1 cmplt");
        int diamonds = PlayerPrefs.GetInt("diamondsAmount");
        PlayerPrefs.SetInt("diamondsAmount", (diamonds - 25));
        PlayerPrefs.SetInt("route", 1);
        PlayerPrefs.SetInt("purchased_r2", 1);
        confirmationWindow1.SetActive(false);
        pricetag1.SetActive(false);

    }
    public void Purchase2()
    {
        int diamonds = PlayerPrefs.GetInt("diamondsAmount");
        PlayerPrefs.SetInt("diamondsAmount", (diamonds - 50));
        PlayerPrefs.SetInt("route", 2);
        PlayerPrefs.SetInt("purchased_r3", 1);
        confirmationWindow2.SetActive(false);
        
    }
    public void Purchase3()
    {
        int diamonds = PlayerPrefs.GetInt("diamondsAmount");
        PlayerPrefs.SetInt("diamondsAmount", (diamonds - 75));
        PlayerPrefs.SetInt("route", 3);
        PlayerPrefs.SetInt("purchased_r4", 1);
        confirmationWindow3.SetActive(false);

    }
    public void Purchase4()
    {
        int diamonds = PlayerPrefs.GetInt("diamondsAmount");
        PlayerPrefs.SetInt("diamondsAmount", (diamonds - 100));
        PlayerPrefs.SetInt("route", 4);
        PlayerPrefs.SetInt("purchased_r5", 1);
        confirmationWindow4.SetActive(false);

    }
    public void Purchase5()
    {
        int diamonds = PlayerPrefs.GetInt("diamondsAmount");
        PlayerPrefs.SetInt("diamondsAmount", (diamonds - 150));
        PlayerPrefs.SetInt("route", 5);
        PlayerPrefs.SetInt("purchased_r6", 1);
        confirmationWindow5.SetActive(false);

    }
    public void cancelPurchase1()
    {
        confirmationWindow1.SetActive(false);
    }
    public void cancelPurchase2()
    {
        confirmationWindow2.SetActive(false);
    }
    public void cancelPurchase3()
    {
        confirmationWindow3.SetActive(false);
    }
    public void cancelPurchase4()
    {
        confirmationWindow4.SetActive(false);
    }
    public void cancelPurchase5()
    {
        confirmationWindow5.SetActive(false);
    }
    public void BackButtonFromThis()
    {
        thisWin.SetActive(false);
        MenuWin.SetActive(true);
        insightsScript.UpdateInsights();
    }
}
