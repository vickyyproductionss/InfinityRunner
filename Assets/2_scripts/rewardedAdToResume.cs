using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;
using System;

public class rewardedAdToResume : MonoBehaviour
{
    //private RewardedAd rewardedAd;
    //private string RewardedAdID = "ca-app-pub-9881340902776059/4860712034";

    public static rewardedAdToResume instance;

    public highScore highscoreScript;

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

    //public void choosingADid()
    //{
    //    int prob = UnityEngine.Random.Range(1, 11);
    //    if(prob == 1)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/4860712034";
    //    }
    //    else if(prob == 2)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/8265411058";
    //    }
    //    else if (prob == 3)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/2234548692";
    //    }
    //    else if (prob == 4)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/4326166046";
    //    }
    //    else if (prob == 5)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/9386921036";
    //    }
    //    else if (prob == 6)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/6760757699";
    //    }
    //    else if (prob == 7)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/5447676024";
    //    }
    //    else if (prob == 8)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/3356058674";
    //    }
    //    else if (prob == 9)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/9195349340";
    //    }
    //    else if (prob == 10)
    //    {
    //        RewardedAdID = "ca-app-pub-9881340902776059/1643042824";
    //    }

    //}
    //void Start()
    //{
    //    this.rewardedAd = new RewardedAd(RewardedAdID);
    //    RequestRewardedAd();

    //    // Called when an ad request has successfully loaded.
    //    this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
    //    // Called when an ad request failed to load.
    //    this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
    //    // Called when an ad is shown.
    //    this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
    //    // Called when an ad request failed to show.
    //    this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
    //    // Called when the user should be rewarded for interacting with the ad.
    //    this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    //    // Called when the ad is closed.
    //    this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    //}

    //void RequestRewardedAd()
    //{
    //    AdRequest request = new AdRequest.Builder().Build();

    //    rewardedAd.LoadAd(request);
    //}

    //public void showRewardedAd()
    //{
    //    if(rewardedAd.IsLoaded())
    //    {
    //        rewardedAd.Show();
    //    }

    //    else
    //    {
    //        RequestRewardedAd();
    //        Debug.Log("ad not loaded");
    //    }
    //}

    //public void HandleRewardedAdLoaded(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardedAdLoaded event received");
    //}

    //public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MonoBehaviour.print(
    //        "HandleRewardedAdFailedToLoad event received with message: "
    //                         );
    //}

    //public void HandleRewardedAdOpening(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardedAdOpening event received");
    //}

    //public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    //{
    //    MonoBehaviour.print(
    //        "HandleRewardedAdFailedToShow event received with message");

    //}

    //public void HandleRewardedAdClosed(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardedAdClosed event received");
    //    RequestRewardedAd();
    //}

    //public void HandleUserEarnedReward(object sender, Reward args)
    //{

    //    ResumeGameAsReward();
    //    //rewardedAdUI.SetActive(true);
    //    string type = args.Type;
    //    double amount = args.Amount;
    //    MonoBehaviour.print(
    //        "HandleRewardedAdRewarded event received for "
    //                    + amount.ToString() + " " + type);
    //}

    //void ResumeGameAsReward()
    //{
    //    GameManager.instance.AdWatched();
    //    GameManager.instance.EndGame();
    //    menu.instance.OnResume();
    //    RequestRewardedAd();

    //}
}
