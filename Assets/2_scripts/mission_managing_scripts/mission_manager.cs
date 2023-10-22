using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class mission_manager : MonoBehaviour
{
    public Text m1;
    public Text m2;
    public Text m3;
    public Text levelCount;
    public GameObject done1;
    public GameObject done2;
    public GameObject done3;
    public GameObject missionCompleteNotification;
    int m1Index;
    int m2Index;
    int m3Index;
    int[] missionVal;
    public bool missionsAssigned ;
    string name1;
    string name2;
    string name3;
    int totalMissionsCreated;
    int selection1 ;
    int selection2 ;
    int selection3 ;
    int gapingMission ;
    int randomSpeedBoostNum;
    int randomSpeedSlowNum;
    public TMP_Text priceforMission1;
    public TMP_Text priceforMission2;
    public TMP_Text priceforMission3;
    public TMP_Text crystalVal;
    public TMP_Text coinValue;
    public GameObject lessCoinsWarningWin;

    public static mission_manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        totalMissionsCreated = 9;
        missionVal = new int[totalMissionsCreated];
        if(!PlayerPrefs.HasKey("GameLevel"))
        {
            PlayerPrefs.SetInt("GameLevel", 1);
            GetMissions(1);
            
        }
        else
        {
            GetMissions(PlayerPrefs.GetInt("GameLevel"));
        }
        
        
        if(PlayerPrefs.HasKey(name1))
        {
            done1.SetActive(true);
        }
        if (PlayerPrefs.HasKey(name2))
        {
            done2.SetActive(true);
        }
        if (PlayerPrefs.HasKey(name3))
        {
            done3.SetActive(true);
        }

    }

    void GetMissions(int level)
    {
        if(level <= 5)
        {
            string[] M = new string[totalMissionsCreated];
            name1 = "Level_" + level.ToString() + "_mission_1";
            name2 = "Level_" + level.ToString() + "_mission_2";
            name3 = "Level_" + level.ToString() + "_mission_3";
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                randomSpeedBoostNum = Random.Range(2, 5);
                randomSpeedSlowNum = Random.Range(2, 5);
                do
                {
                    selection1 = Random.Range(0, totalMissionsCreated);
                    selection2 = Random.Range(0, totalMissionsCreated);
                    selection3 = Random.Range(0, totalMissionsCreated);
                    while (selection2 == selection1)
                    {
                        selection2 = Random.Range(0, totalMissionsCreated);
                    }
                    while (selection3 == selection1 || selection3 == selection2)
                    {
                        selection3 = Random.Range(0, totalMissionsCreated);
                    }
                }
                while (selection1 == PlayerPrefs.GetInt("prevSelect1") || selection2 == PlayerPrefs.GetInt("prevSelect2") || selection3 == PlayerPrefs.GetInt("prevSelect3") || selection1 == 7 || selection2 == 7 ||  selection3 == 7);
                
                
                PlayerPrefs.SetInt("prevSelect1", selection1);
                PlayerPrefs.SetInt("prevSelect2", selection2);
                PlayerPrefs.SetInt("prevSelect3", selection3);
                missionVal[0] = level * 1000 * Random.Range(1, 6);
                missionVal[1] = level * 1 * Random.Range(1, 3);
                missionVal[2] = level * 10 * Random.Range(1, 3);
                missionVal[3] = level * 1 * Random.Range(1, 3);
                missionVal[4] = PlayerPrefs.GetInt("coins_amount") + 400;
                missionVal[5] = randomSpeedBoostNum;
                missionVal[6] = randomSpeedSlowNum;
                missionVal[7] = 0;
                missionVal[8] = 0;
            }
            else if(PlayerPrefs.HasKey("levelAssigned" + level))
            {
                selection1 = PlayerPrefs.GetInt("selection1");
                selection2 = PlayerPrefs.GetInt("selection2");
                selection3 = PlayerPrefs.GetInt("selection3");
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    missionVal[i] = PlayerPrefs.GetInt("missionVal" + i);
                }
            }            

            M[0] = "Score " + (missionVal[0]).ToString() + " in one run";
            M[1] = "Collect " + (missionVal[1]).ToString() + " diamonds in one run";
            M[2] = "Collect " + (missionVal[2]).ToString() + " coins in one run";
            M[3] = "Drop Down " + (missionVal[3]).ToString() + " wooden boxes in one run";
            M[4] = "Collect " + (missionVal[4]).ToString() + " coins in total";
            
            PlayerPrefs.SetInt("randomSpeedBoostNum", randomSpeedBoostNum);
            PlayerPrefs.SetInt("randomSpeedSlowNum", randomSpeedSlowNum);
            M[5] = "Use " + (missionVal[5]).ToString() + " speed boosters in one run";
            M[6] = "Use " + (missionVal[6]).ToString() + " speed loser in one run";
            M[7] = "Break your own highscore.";
            M[8] = "Push a wooden box over the incline";

            
            m1.text = "1. " + M[selection1];
            m2.text = "2. " + M[selection2];
            m3.text = "3. " + M[selection3];
            m1Index = selection1;
            m2Index = selection2;
            m3Index = selection3;
            
            levelCount.text = PlayerPrefs.GetInt("GameLevel").ToString();
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                PlayerPrefs.SetInt("levelAssigned" + level, 1);
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    PlayerPrefs.SetInt("missionVal" + i, missionVal[i]);
                }
                PlayerPrefs.SetInt("selection1", selection1);
                PlayerPrefs.SetInt("selection2", selection2);
                PlayerPrefs.SetInt("selection3", selection3);
            }
            checkMissionStatus(m1Index, m2Index, m3Index);
            missionAssignedTrue();
        }
        else if (level > 5 && level <= 10)
        {
            string[] M = new string[totalMissionsCreated];
            name1 = "Level_" + level.ToString() + "_mission_1";
            name2 = "Level_" + level.ToString() + "_mission_2";
            name3 = "Level_" + level.ToString() + "_mission_3";
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                randomSpeedBoostNum = Random.Range(3, 7);
                randomSpeedSlowNum = Random.Range(3, 7);
                do
                {
                    selection1 = Random.Range(0, totalMissionsCreated);
                    selection2 = Random.Range(0, totalMissionsCreated);
                    selection3 = Random.Range(0, totalMissionsCreated);
                    while (selection2 == selection1)
                    {
                        selection2 = Random.Range(0, totalMissionsCreated);
                    }
                    while (selection3 == selection1 || selection3 == selection2)
                    {
                        selection3 = Random.Range(0, totalMissionsCreated);
                    }
                }
                while (selection1 == PlayerPrefs.GetInt("prevSelect1") || selection2 == PlayerPrefs.GetInt("prevSelect2") || selection3 == PlayerPrefs.GetInt("prevSelect3"));


                PlayerPrefs.SetInt("prevSelect1", selection1);
                PlayerPrefs.SetInt("prevSelect2", selection2);
                PlayerPrefs.SetInt("prevSelect3", selection3);
                missionVal[0] = level * 2000 * Random.Range(1, 6);
                missionVal[1] = Random.Range(10, 16);
                missionVal[2] = level * 20 * Random.Range(1, 3);
                missionVal[3] = Random.Range(6, 10);
                missionVal[4] = PlayerPrefs.GetInt("coins_amount") + Random.Range(400, 800);
                missionVal[5] = randomSpeedBoostNum;
                missionVal[6] = randomSpeedSlowNum;
                missionVal[7] = 0;
                missionVal[8] = 0;
            }
            else if (PlayerPrefs.HasKey("levelAssigned" + level))
            {
                selection1 = PlayerPrefs.GetInt("selection1");
                selection2 = PlayerPrefs.GetInt("selection2");
                selection3 = PlayerPrefs.GetInt("selection3");
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    missionVal[i] = PlayerPrefs.GetInt("missionVal" + i);
                }
            }

            M[0] = "Score " + (missionVal[0]).ToString() + " in one run";
            M[1] = "Collect " + (missionVal[1]).ToString() + " diamonds in one run";
            M[2] = "Collect " + (missionVal[2]).ToString() + " coins in one run";
            M[3] = "Drop Down " + (missionVal[3]).ToString() + " wooden boxes in one run";
            M[4] = "Collect " + (missionVal[4]).ToString() + " coins in total";

            PlayerPrefs.SetInt("randomSpeedBoostNum", randomSpeedBoostNum);
            PlayerPrefs.SetInt("randomSpeedSlowNum", randomSpeedSlowNum);
            M[5] = "Use " + (missionVal[5]).ToString() + " speed boosters in one run";
            M[6] = "Use " + (missionVal[6]).ToString() + " speed loser in one run";
            M[7] = "Break your own highscore.";
            M[8] = "Push a wooden box over the incline";


            m1.text = M[selection1];
            m2.text = M[selection2];
            m3.text = M[selection3];
            m1Index = selection1;
            m2Index = selection2;
            m3Index = selection3;

            levelCount.text = PlayerPrefs.GetInt("GameLevel").ToString();
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                PlayerPrefs.SetInt("levelAssigned" + level, 1);
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    PlayerPrefs.SetInt("missionVal" + i, missionVal[i]);
                }
                PlayerPrefs.SetInt("selection1", selection1);
                PlayerPrefs.SetInt("selection2", selection2);
                PlayerPrefs.SetInt("selection3", selection3);
            }
            checkMissionStatus(m1Index, m2Index, m3Index);
            missionAssignedTrue();
        }
        else if (level > 10 && level <= 20)
        {
            string[] M = new string[totalMissionsCreated];
            name1 = "Level_" + level.ToString() + "_mission_1";
            name2 = "Level_" + level.ToString() + "_mission_2";
            name3 = "Level_" + level.ToString() + "_mission_3";
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                randomSpeedBoostNum = Random.Range(5, 10);
                randomSpeedSlowNum = Random.Range(5, 10);
                do
                {
                    selection1 = Random.Range(0, totalMissionsCreated);
                    selection2 = Random.Range(0, totalMissionsCreated);
                    selection3 = Random.Range(0, totalMissionsCreated);
                    while (selection2 == selection1)
                    {
                        selection2 = Random.Range(0, totalMissionsCreated);
                    }
                    while (selection3 == selection1 || selection3 == selection2)
                    {
                        selection3 = Random.Range(0, totalMissionsCreated);
                    }
                }
                while (selection1 == PlayerPrefs.GetInt("prevSelect1") || selection2 == PlayerPrefs.GetInt("prevSelect2") || selection3 == PlayerPrefs.GetInt("prevSelect3"));


                PlayerPrefs.SetInt("prevSelect1", selection1);
                PlayerPrefs.SetInt("prevSelect2", selection2);
                PlayerPrefs.SetInt("prevSelect3", selection3);
                missionVal[0] = level * 2000 * Random.Range(1, 6);
                missionVal[1] = Random.Range(10, 21);
                missionVal[2] = Random.Range(150, 301);
                missionVal[3] = Random.Range(8, 16);
                missionVal[4] = PlayerPrefs.GetInt("coins_amount") + Random.Range(800, 1200);
                missionVal[5] = randomSpeedBoostNum;
                missionVal[6] = randomSpeedSlowNum;
                missionVal[7] = 0;
                missionVal[8] = 0;
            }
            else if (PlayerPrefs.HasKey("levelAssigned" + level))
            {
                selection1 = PlayerPrefs.GetInt("selection1");
                selection2 = PlayerPrefs.GetInt("selection2");
                selection3 = PlayerPrefs.GetInt("selection3");
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    missionVal[i] = PlayerPrefs.GetInt("missionVal" + i);
                }
            }

            M[0] = "Score " + (missionVal[0]).ToString() + " in one run";
            M[1] = "Collect " + (missionVal[1]).ToString() + " diamonds in one run";
            M[2] = "Collect " + (missionVal[2]).ToString() + " coins in one run";
            M[3] = "Drop Down " + (missionVal[3]).ToString() + " wooden boxes in one run";
            M[4] = "Collect " + (missionVal[4]).ToString() + " coins in total";

            PlayerPrefs.SetInt("randomSpeedBoostNum", randomSpeedBoostNum);
            PlayerPrefs.SetInt("randomSpeedSlowNum", randomSpeedSlowNum);
            M[5] = "Use " + (missionVal[5]).ToString() + " speed boosters in one run";
            M[6] = "Use " + (missionVal[6]).ToString() + " speed loser in one run";
            M[7] = "Break your own highscore.";
            M[8] = "Push a wooden box over the incline";


            m1.text = M[selection1];
            m2.text = M[selection2];
            m3.text = M[selection3];
            m1Index = selection1;
            m2Index = selection2;
            m3Index = selection3;

            levelCount.text = PlayerPrefs.GetInt("GameLevel").ToString();
            if (!PlayerPrefs.HasKey("levelAssigned" + level))
            {
                PlayerPrefs.SetInt("levelAssigned" + level, 1);
                for (int i = 0; i < totalMissionsCreated; i++)
                {
                    PlayerPrefs.SetInt("missionVal" + i, missionVal[i]);
                }
                PlayerPrefs.SetInt("selection1", selection1);
                PlayerPrefs.SetInt("selection2", selection2);
                PlayerPrefs.SetInt("selection3", selection3);
            }
            checkMissionStatus(m1Index, m2Index, m3Index);
            missionAssignedTrue();
        }
        else
        {
            m1.text = "Kindly update the game from play store";
            m2.text = "to get more missions if still see this window";
            m3.text = "message developer at Gmail: Vickychaudhary8955@gmail.com";
            levelCount.text = "unavailable";
        }
    }
    void missionAssignedTrue()
    {
        missionsAssigned = true;
    }
    void checkMissionStatus(int mission1, int mission2, int mission3)
    {
        if(ballMotion.instance.player.transform.position.z >= missionVal[0])
        {
            if(mission1 == 0)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if(mission2 == 0)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if(mission3 == 0)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if(ballMotion.instance.diamondsAmountInThisGame >= missionVal[1])
        {
            if (mission1 == 1)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 1)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 1)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if (ballMotion.instance.coinAmountThisGame >= missionVal[2])
        {
            if (mission1 == 2)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);

            }
            else if (mission2 == 2)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 2)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if (ballMotion.instance.fallenWoodenBoxes >= missionVal[3])
        {
            if (mission1 == 3)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 3)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 3)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if (PlayerPrefs.GetInt("coins_amount") >= missionVal[4])
        {
            if (mission1 == 4)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 4)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 4)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if (ballMotion.instance.speedBoostThisGame >= missionVal[5])
        {
            if (mission1 == 5)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 5)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 5)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }

        if (ballMotion.instance.speedLostThisGame >= missionVal[6])
        {
            if (mission1 == 6)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 6)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 6)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if (ballMotion.instance.player.transform.position.z > PlayerPrefs.GetFloat("highscore", 0))
        {
            if (mission1 == 7)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 7)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 7)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
        if(PlayerPrefs.GetString("onRamp") == "true")
        {
            if (mission1 == 8)
            {
                done1.SetActive(true);
                string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
                CompleteMission(Name1);
            }
            else if (mission2 == 8)
            {
                done2.SetActive(true);
                string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
                CompleteMission(Name2);
            }
            else if (mission3 == 8)
            {
                done3.SetActive(true);
                string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
                CompleteMission(Name3);
            }
        }
    }
    void CompleteMission(string name)
    {
        PlayerPrefs.SetInt(name, 1);
    }
    void Update()
    {
        if (missionsAssigned)
        {       
            checkMissionStatus(m1Index, m2Index, m3Index);
        }  
        if(PlayerPrefs.HasKey(name1) && PlayerPrefs.HasKey(name2) && PlayerPrefs.HasKey(name3) )
        {
            missionCompleteNotification.SetActive(true);
            Invoke("CloseNotification", 3f);
            done1.SetActive(false);
            done2.SetActive(false);
            done3.SetActive(false);
            int temp = PlayerPrefs.GetInt("GameLevel");
            PlayerPrefs.SetInt("GameLevel", temp + 1);
            GameManager.instance.level_label.text = PlayerPrefs.GetInt("GameLevel").ToString();
            missionsAssigned = false;
            GetMissions(temp + 1);
            PlayerPrefs.DeleteKey(name1);
            PlayerPrefs.DeleteKey(name2);
            PlayerPrefs.DeleteKey(name3);
            ballMotion.instance.diamondsAmountInThisGame = 0;
            ballMotion.instance.coinAmountThisGame = 0;
            ballMotion.instance.fallenWoodenBoxes = 0;
            ballMotion.instance.speedBoostThisGame = 0;
            ballMotion.instance.speedLostThisGame = 0;
            UpdateMissionPurchasingPrice();
        }
    }
    void CloseNotification()
    {
        missionCompleteNotification.SetActive(false);
    }
    void completeMission1()
    {
        string name = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
        PlayerPrefs.SetInt(name, 1);
    }
    void completeMission2()
    {
        string name = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
        PlayerPrefs.SetInt(name, 1);
    }
    void completeMission3()
    {
        string name = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
        PlayerPrefs.SetInt(name, 1);
    }
    public void showWarningWin()
    {
        
        Invoke("closeWarningWinLessCoin", 1.5f);
        lessCoinsWarningWin.SetActive(true);
        Debug.Log("openingErrorwin");
    }
    void closeWarningWinLessCoin()
    {
        lessCoinsWarningWin.SetActive(false);
        Debug.Log("closingErrorwin");
    }

    public void UpdateMissionPurchasingPrice()
    {
        string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
        string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
        string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
        int price = 0;
        int level = PlayerPrefs.GetInt("GameLevel");
        if (level <= 5)
        {
            price = level * 100 + 1000;
        }
        else if (level > 5 && level <= 10)
        {
            price = level * 100 + 2500;
        }
        else if (level > 10 && level <= 20)
        {
            price = level * 100 + 5000;
        }
        else if (level > 20)
        {
            price = level * 300 + 5000;
        }
        if(priceforMission1)
        {
            if(PlayerPrefs.HasKey(Name1))
            {
                priceforMission1.text = "Completed";
                priceforMission1.color = Color.grey;
            }
            else
            {
                priceforMission3.color = Color.green;
                priceforMission1.text = price.ToString();
            }
            
        }
        if (priceforMission2)
        {
            if (PlayerPrefs.HasKey(Name2))
            {
                priceforMission2.text = "Completed";
                priceforMission2.color = Color.grey;
            }
            else
            {
                priceforMission3.color = Color.green;
                priceforMission2.text = price.ToString();
            }
        }
        if (priceforMission3)
        {
            if (PlayerPrefs.HasKey(Name3))
            {
                priceforMission3.text = "Completed";
                priceforMission3.color = Color.grey;
            }
            else
            {
                priceforMission3.color = Color.green;
                priceforMission3.text = price.ToString();
            }
        }
        if(coinValue)
        {
            coinValue.text = PlayerPrefs.GetInt("coins_amount").ToString();
        }
        if(crystalVal)
        {
            crystalVal.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        }
    }
    public void CompleteThisMission(int a)
    {
        string Name1 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_1";
        string Name2 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_2";
        string Name3 = "Level_" + PlayerPrefs.GetInt("GameLevel").ToString() + "_mission_3";
        if (a == 1)
        {
            int price = 0;
            int level = PlayerPrefs.GetInt("GameLevel");
            if(level <= 5)
            {
                price = level * 100 + 500;
            }
            else if(level > 5 && level <= 10)
            {
                price = level * 100 + 2500;
            }
            else if(level > 10 && level <= 20)
            {
                price = level * 100 + 5000;
            }
            else if (level > 20 )
            {
                price = level * 300 + 5000;
            }
            if(PlayerPrefs.GetInt("coins_amount") >= price)
            {
                int temp = PlayerPrefs.GetInt("coins_amount");
                PlayerPrefs.SetInt("coins_amount", temp - price);
                completeMission1();
            }
            else if(PlayerPrefs.GetInt("coins_amount") < price && !PlayerPrefs.HasKey(Name1))
            {
                showWarningWin();
            }

        }
        if(a == 2)
        {
            int price = 0;
            int level = PlayerPrefs.GetInt("GameLevel");
            if (level <= 5)
            {
                price = level * 100 + 500;
            }
            else if (level > 5 && level <= 10)
            {
                price = level * 100 + 2500;
            }
            else if (level > 10 && level <= 20)
            {
                price = level * 100 + 5000;
            }
            else if (level > 20)
            {
                price = level * 300 + 5000;
            }
            if (PlayerPrefs.GetInt("coins_amount") >= price)
            {
                int temp = PlayerPrefs.GetInt("coins_amount");
                PlayerPrefs.SetInt("coins_amount", temp - price);
                completeMission2();
            }
            else if (PlayerPrefs.GetInt("coins_amount") < price && !PlayerPrefs.HasKey(Name2))
            {
                showWarningWin();
            }

        }
        if(a == 3)
        {
            int price = 0;
            int level = PlayerPrefs.GetInt("GameLevel");
            if (level <= 5)
            {
                price = level * 100 + 500;
            }
            else if (level > 5 && level <= 10)
            {
                price = level * 100 + 2500;
            }
            else if (level > 10 && level <= 20)
            {
                price = level * 100 + 5000;
            }
            else if (level > 20)
            {
                price = level * 300 + 5000;
            }
            if (PlayerPrefs.GetInt("coins_amount") >= price)
            {
                int temp = PlayerPrefs.GetInt("coins_amount");
                PlayerPrefs.SetInt("coins_amount", temp - price);
                completeMission3();
            }
            else if (PlayerPrefs.GetInt("coins_amount") < price && !PlayerPrefs.HasKey(Name3))
            {
                showWarningWin();
            }
        }
        UpdateMissionPurchasingPrice();
    }
}
