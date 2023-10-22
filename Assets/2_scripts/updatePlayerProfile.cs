using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatePlayerProfile : MonoBehaviour
{
    public Text playerName;
    public Text highscore;
    public Text crystals;
    public Text Coins;
    public Text matchesPlayed;
    public Text easySpeed;
    public Text redeemNote;
    public InputField referalCode;

    public static updatePlayerProfile instance;

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

    // Start is called before the first frame update


    void Start()
    {
        refreshInsights();
    }

    // Update is called once per frame
    public void instaUserNameLink()
    {
        Application.OpenURL("https://www.instagram.com/vickyy_productionss");
    }
    public void twitterUserNameLink()
    {
        Application.OpenURL("https://twitter.com/vickyprductions");
    }
    public void youtubeUserNameLink()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC9Czqq7w6gj-YRYNHTDZuSg");
    }
    public void refreshInsights()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName.text = PlayerPrefs.GetString("PlayerName");
        }
        else if (!PlayerPrefs.HasKey("PlayerName"))
        {
            playerName.text = "Player";
        }
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore.text = PlayerPrefs.GetFloat("highscore", 0).ToString("#");
        }
        else if (!PlayerPrefs.HasKey("highscore"))
        {
            highscore.text = "0";
        }
        crystals.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        matchesPlayed.text = PlayerPrefs.GetInt("matches_played", 0).ToString("#");

        if (PlayerPrefs.HasKey("easySpeed"))
        {
            easySpeed.text = PlayerPrefs.GetFloat("easySpeed", 0).ToString("#") + "km/h";
        }
        else if (!PlayerPrefs.HasKey("easySpeed"))
        {
            easySpeed.text = "0";
        }
        if (PlayerPrefs.HasKey("coins_amount"))
        {
            Coins.text = PlayerPrefs.GetInt("coins_amount").ToString();
        }
        else if (!PlayerPrefs.HasKey("coins_amount"))
        {
            Coins.text = "0";
        }
    }

    public void redeemReferal()
    {
        if(referalCode.text == "639741")
        {
            int prevDiamondsValue = PlayerPrefs.GetInt("diamondsAmount");
            int prevcoinsValue = PlayerPrefs.GetInt("coins_amount");

            PlayerPrefs.SetInt("diamondsAmount", prevDiamondsValue + 25);
            PlayerPrefs.SetInt("coins_amount", prevcoinsValue + 25);
        }
        else if(!PlayerPrefs.HasKey("redeem_vicky50"))
        {
            if(referalCode.text == "vicky50")
            {
                int prevDiamondsValue = PlayerPrefs.GetInt("diamondsAmount");
                PlayerPrefs.SetInt("diamondsAmount", prevDiamondsValue + 50);
                PlayerPrefs.SetString("redeem_vicky50", "redeemed");
            }
            else if(referalCode.text != "vicky50")
            {
                ShowNotificationRedeemed("No such referal code...");
            }
        }

        else if (PlayerPrefs.HasKey("redeem_vicky50"))
        {
            if (referalCode.text == "vicky50")
            {
                ShowNotificationRedeemed("Already Redeemed");
            }
            else if (referalCode.text != "vicky50")
            {
                ShowNotificationRedeemed("No such referal code...");
            }
        }

        refreshInsights();
    }

    void ShowNotificationRedeemed(string note)
    {
        redeemNote.text = note;
        Invoke("HideNotificationRedeemed", 2f);
    }
    void HideNotificationRedeemed()
    {
        redeemNote.text = "";
    }


}
