using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPurchase : MonoBehaviour
{
    public int ItemNo;
    

    public void startPurchase()
    {
        //PlayerPrefs.SetInt("diamondsAmount", 100);
        PlayerPrefs.SetInt("itemNum", ItemNo);
        purchasingScript.instance.initialisePurchase();
    }

    public void Purchasing()
    {
        if (PlayerPrefs.GetString("dealingWith") == "routes")
        {
            PlayerPrefs.SetString("prefix", "purchased_r");
        }
        else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
        {
            PlayerPrefs.SetString("prefix", "purchased_o");
        }
        string name = PlayerPrefs.GetString("prefix") + PlayerPrefs.GetInt("itemNum").ToString();
        if (PlayerPrefs.HasKey(name))
        {
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                PlayerPrefs.SetInt("route", PlayerPrefs.GetInt("itemNum"));
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                PlayerPrefs.SetInt("obstacles", PlayerPrefs.GetInt("itemNum"));
            }
            Invoke("closeConfirmationWin", 0.5f);

            purchasingScript.instance.closePriceTags(PlayerPrefs.GetInt("itemNum"));
        }
        else
        {
            
            int diamonds = PlayerPrefs.GetInt("diamondsAmount");
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                PlayerPrefs.SetInt("diamondsAmount", (diamonds - purchasingScript.instance.priceRoutes[PlayerPrefs.GetInt("itemNum") - 1]));
            }
            if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                PlayerPrefs.SetInt("diamondsAmount", (diamonds - purchasingScript.instance.priceObs[PlayerPrefs.GetInt("itemNum") - 1]));
            }

            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                PlayerPrefs.SetInt("route", PlayerPrefs.GetInt("itemNum"));
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                PlayerPrefs.SetInt("obstacles", PlayerPrefs.GetInt("itemNum"));
            }
            PlayerPrefs.SetInt(name, 1);
            Invoke("closeConfirmationWin", 0.5f);
            purchasingScript.instance.closePriceTags(PlayerPrefs.GetInt("itemNum"));
        }

    }
    
    public void CancelPurchase()
    {
        Invoke("closeConfirmationWin", 0.5f);
    }

    public void closeErrorWin()
    {
        if (PlayerPrefs.GetString("dealingWith") == "routes")
        {
            purchasingScript.instance.errorWinRoute.SetActive(false);
        }
        else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
        {
            purchasingScript.instance.errorWinObs.SetActive(false);
        }
    }
    void closeConfirmationWin()
    {
        if (PlayerPrefs.GetString("dealingWith") == "routes")
        {
            purchasingScript.instance.confirmationWinRoute.SetActive(false);
        }
        else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
        {
            purchasingScript.instance.confirmationWinObs.SetActive(false);
        }
    }
}
