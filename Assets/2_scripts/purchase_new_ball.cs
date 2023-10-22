using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class purchase_new_ball : MonoBehaviour
{
    public GameObject mainPrefab;
    public int itemID;
    public TMP_Text rate;
    public string name_temp;
    float r1 = 0;
    float g1 = 255;
    float b1 = 250;
    public int totalMats = 9;
    public static purchase_new_ball instance;
    private int[] itemVal;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        itemVal = new int[9];
        itemVal[0] = 0;
        itemVal[1] = 50;
        itemVal[2] = 75;
        itemVal[3] = 100;
        itemVal[4] = 125;
        itemVal[5] = 150;
        itemVal[6] = 200;
        itemVal[7] = 250;
        itemVal[8] = 300;
        name_temp = "itemVal_" + itemID.ToString();

        updatePrice();
        
        
    }
    void updatePrice()
    {
        if (!PlayerPrefs.HasKey(name_temp))
        {
            if (itemID == 0)
            {
                if(rate)
                {
                    rate.text = "Default";
                    rate.color = Color.white;
                }
                
            }
            else
            {
                if (rate)
                {
                    rate.text = itemVal[itemID].ToString() + " crystals";
                    rate.color = Color.white;
                }
                    
            }

        }
        else
        {
            if(rate)
            {
                rate.text = "Owned";
                rate.color = Color.green;
            }
            
        }
        
    }

    public void Purchase(int ID)
    {
        ID = itemID;
        name_temp = "itemVal_" + ID.ToString();
        if(PlayerPrefs.HasKey(name_temp))
        {
            highlightItem();
            PlayerPrefs.SetInt("selectedMat", ID);
        }
        else
        {
            if (PlayerPrefs.GetInt("diamondsAmount") >= itemVal[ID])
            {
                PlayerPrefs.SetInt("selectedMat", ID);
                PlayerPrefs.SetString(name_temp, "purchased");
                int temp = PlayerPrefs.GetInt("diamondsAmount");
                PlayerPrefs.SetInt("diamondsAmount", temp - itemVal[ID]);
                highlightItem();
                updatePrice();
            }
            else
            {
                lessCrystalsWin.instance.Warningwin.SetActive(true);
                Invoke("closeWarningWin", 1.5f);
            }
        }
        GameManager.instance.UpdateDiamondsVal();
        updatePrice();

    }
    public void highlightItem()
    {
        unHighlightAll.instance.UnhighlighAll(0);
        mainPrefab.GetComponent<Image>().color = Color.white;
        gameObject.GetComponent<Image>().color = new Color(r1, g1, b1);
    }
    public void closeWarningWin()
    {
        lessCrystalsWin.instance.Warningwin.SetActive(false);
    }
}
