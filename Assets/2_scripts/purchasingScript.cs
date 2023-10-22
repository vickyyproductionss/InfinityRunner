using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class purchasingScript : MonoBehaviour
{
    public GameObject errorWinRoute;
    public GameObject errorWinObs;
    public GameObject confirmationWinRoute;
    public GameObject confirmationWinObs;

    public int[] priceRoutes;
    public int[] priceObs;
    public GameObject[] priceTagsRoutes;
    public GameObject[] priceTagsObs;
    public Text priceTagLineRoutes;
    public Text priceTagLineObs;
    public int itemsNum;
    public static purchasingScript instance;
    string matName;
    public int totalItems = 6;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for(int i = 0; i < totalItems; i++)
        {
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                PlayerPrefs.SetString("prefix", "purchased_r");
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                PlayerPrefs.SetString("prefix", "purchased_o");
            }
            matName = PlayerPrefs.GetString("prefix") + (i+1).ToString();
            if(PlayerPrefs.HasKey(matName))
            {
                if(PlayerPrefs.GetString("dealingWith") == "routes")
                {
                    priceTagsRoutes[i].SetActive(false);
                }
                else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                {
                    priceTagsObs[i].SetActive(false);
                }

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialisePurchase()
    {
        Debug.Log(PlayerPrefs.GetInt("itemNum"));
        if(PlayerPrefs.GetString("dealingWith") == "routes")
        {
            PlayerPrefs.SetString("prefix", "purchased_r");
        }
        else if(PlayerPrefs.GetString("dealingWith") == "obstacles")
        {
            PlayerPrefs.SetString("prefix", "purchased_o");
        }
        string name = PlayerPrefs.GetString("prefix") + PlayerPrefs.GetInt("itemNum").ToString();
        if (!PlayerPrefs.HasKey(name))
        {
            int price = 0;
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                price = priceRoutes[PlayerPrefs.GetInt("itemNum") - 1];
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                price = priceObs[PlayerPrefs.GetInt("itemNum") - 1];
            }
             
            if (PlayerPrefs.GetInt("diamondsAmount") >= price)
            {
                if(PlayerPrefs.GetString("dealingWith") == "routes")
                {
                    priceTagLineRoutes.text = (priceRoutes[PlayerPrefs.GetInt("itemNum") - 1]).ToString() + " crystals will be deducted from your crystals";
                }

                else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                {
                    priceTagLineObs.text = (priceObs[PlayerPrefs.GetInt("itemNum") - 1]).ToString() + " crystals will be deducted from your crystals";
                }

                if (PlayerPrefs.GetInt("itemNum") != 1)
                {
                    if (PlayerPrefs.GetString("dealingWith") == "routes")
                    {
                        confirmationWinRoute.SetActive(true);
                    }
                    else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                    {
                        confirmationWinObs.SetActive(true);
                    }

                }
                else if(PlayerPrefs.GetInt("itemNum") == 1)
                {
                    if (PlayerPrefs.GetString("dealingWith") == "routes")
                    {
                        PlayerPrefs.SetInt("route", PlayerPrefs.GetInt("itemNum"));
                    }
                    else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                    {
                        PlayerPrefs.SetInt("obstacles", PlayerPrefs.GetInt("itemNum"));
                    }
                    if (PlayerPrefs.GetString("dealingWith") == "routes")
                    {
                        confirmationWinRoute.SetActive(false);
                    }
                    else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                    {
                        confirmationWinObs.SetActive(false);
                    }
                }
                
            }
            else
            {
                if (PlayerPrefs.GetString("dealingWith") == "routes")
                {
                    errorWinRoute.SetActive(true);
                }
                else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
                {
                    errorWinObs.SetActive(true);
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                PlayerPrefs.SetInt("route", PlayerPrefs.GetInt("itemNum"));
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                PlayerPrefs.SetInt("obstacles", PlayerPrefs.GetInt("itemNum"));
            }
            if (PlayerPrefs.GetString("dealingWith") == "routes")
            {
                confirmationWinRoute.SetActive(false);
            }
            else if (PlayerPrefs.GetString("dealingWith") == "obstacles")
            {
                confirmationWinObs.SetActive(false);
            }
        }

        
    }
    
    public void closePriceTags(int num)
    {
        if (PlayerPrefs.GetString("dealingWith") == "routes")
        {
            priceTagsRoutes[num - 1].SetActive(false);
        }
        else if(PlayerPrefs.GetString("dealingWith") == "obstacles")
        {
            priceTagsObs[num - 1].SetActive(false);
        }
            
    }
}
