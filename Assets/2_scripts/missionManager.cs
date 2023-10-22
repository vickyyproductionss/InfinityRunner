using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class missionManager : MonoBehaviour
{
    public Text levelCount;
    //public Text levelDoneNotification;
    //public GameObject levelDoneNotificationWin;
    public GameObject[] missionsCompleted;
    public Text mission1;
    public Text mission2;
    public Text mission3;
    bool[] missionsDone;
    int totalMissions;
    int levelsCreated;
    public static missionManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        levelsCreated = 6;
        levelCount.text = PlayerPrefs.GetInt("myLevel").ToString();
        updateMissions();
        //PlayerPrefs.DeleteAll();
        missionsDone = new bool[(PlayerPrefs.GetInt("myLevel") * 3)];
        GetMission(PlayerPrefs.GetInt("myLevel", 1));
        
    }
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
    void updateMissions()
    {
        totalMissions = (PlayerPrefs.GetInt("myLevel") * 3 - 1);
        if (!PlayerPrefs.HasKey("myLevel"))
        {
            PlayerPrefs.SetInt("myLevel", 1);
        }
        missionsDone = new bool[totalMissions + 1];
        for (int i = 0; i < totalMissions + 1; i++)
        {
            string name = "mission" + (i+1).ToString();
            if (PlayerPrefs.HasKey(name))
            {
                missionsDone[i] = true;
                if (i + 1 == (PlayerPrefs.GetInt("myLevel") - 1) * PlayerPrefs.GetInt("myLevel") + 1)
                {
                    missionsCompleted[0].SetActive(true);
                }
                else if (i + 1 == (PlayerPrefs.GetInt("myLevel") - 1) * PlayerPrefs.GetInt("myLevel") + 2)
                {
                    missionsCompleted[1].SetActive(true);
                }
                else if (i + 1 == (PlayerPrefs.GetInt("myLevel") - 1) * PlayerPrefs.GetInt("myLevel") + 3)
                {
                    missionsCompleted[2].SetActive(true);
                }
            }
            else
            {
                missionsDone[i] = false;
            }
        }
    }

    void GetMission(int level)
    {
        if(PlayerPrefs.GetInt("myLevel") <= levelsCreated)
        {
            levelCount.text = PlayerPrefs.GetInt("myLevel").ToString();
            int myLevel = PlayerPrefs.GetInt("myLevel");
            missionsDone = new bool[3 * myLevel];
            
            if (PlayerPrefs.GetInt("myLevel") == 1)
            {
                int a = 5000;
                int b = 2;
                int c = 100;
                missions.mission_score l1m1 = new missions.mission_score(a);
                PlayerPrefs.SetInt("l1m1", a);
                missions.mission_boxes l1m2 = new missions.mission_boxes(b);
                PlayerPrefs.SetInt("l1m2", b);
                missions.mission_speed l1m3 = new missions.mission_speed(c);
                PlayerPrefs.SetInt("l1m3", c);
                mission1.text = l1m1.statement;
                mission2.text = l1m2.statement;
                mission3.text = l1m3.statement;
            }
            else if (PlayerPrefs.GetInt("myLevel") == 2)
            {
                int a = 50;
                int b = 4;
                int c = 500;
                missions.mission_coins l2m1 = new missions.mission_coins(a);
                PlayerPrefs.SetInt("l2m1", a);
                missions.mission_diamonds l2m2 = new missions.mission_diamonds(b);
                PlayerPrefs.SetInt("l2m2", b);
                missions.mission_total_coins l2m3 = new missions.mission_total_coins(c);
                PlayerPrefs.SetInt("l2m3", c);
                mission1.text = l2m1.statement;
                mission2.text = l2m2.statement;
                mission3.text = l2m3.statement;
            }
            else if (PlayerPrefs.GetInt("myLevel") == 3)
            {
                int a = 10000;
                int b = 8;
                int c = 120;
                missions.mission_score l3m1 = new missions.mission_score(a);
                PlayerPrefs.SetInt("l3m1", a);
                missions.mission_diamonds l3m2 = new missions.mission_diamonds(b);
                PlayerPrefs.SetInt("l3m2", b);
                missions.mission_speed l3m3 = new missions.mission_speed(c);
                PlayerPrefs.SetInt("l3m3", c);
                mission1.text = l3m1.statement;
                mission2.text = l3m2.statement;
                mission3.text = l3m3.statement;
            }
            else if (PlayerPrefs.GetInt("myLevel") == 4)
            {
                int a = 100;
                int b = 200;
                int c = 150;
                missions.mission_coins l4m1 = new missions.mission_coins(a);
                PlayerPrefs.SetInt("l4m1", a);
                missions.mission_total_diamonds l4m2 = new missions.mission_total_diamonds(b);
                PlayerPrefs.SetInt("l4m2", b);
                missions.mission_speed l4m3 = new missions.mission_speed(c);
                PlayerPrefs.SetInt("l4m3", c);
                mission1.text = l4m1.statement;
                mission2.text = l4m2.statement;
                mission3.text = l4m3.statement;
            }

            else if (PlayerPrefs.GetInt("myLevel") == 5)
            {
                int a = 150;
                int b = 12;
                int c = 1000;
                missions.mission_coins l5m1 = new missions.mission_coins(a);
                PlayerPrefs.SetInt("l5m1", a);
                missions.mission_diamonds l5m2 = new missions.mission_diamonds(b);
                PlayerPrefs.SetInt("l5m2", b);
                missions.mission_total_coins l5m3 = new missions.mission_total_coins(c);
                PlayerPrefs.SetInt("l5m3", c);
                mission1.text = l5m1.statement;
                mission2.text = l5m2.statement;
                mission3.text = l5m3.statement;
            }

            else if (PlayerPrefs.GetInt("myLevel") == 6)
            {
                int a = 15000;
                int b = 5;
                int c = 180;
                missions.mission_score l6m1 = new missions.mission_score(a);
                PlayerPrefs.SetInt("l6m1", a);
                missions.mission_boxes l6m2 = new missions.mission_boxes(b);
                PlayerPrefs.SetInt("l6m2", b);
                missions.mission_speed l6m3 = new missions.mission_speed(c);
                PlayerPrefs.SetInt("l6m3", c);
                mission1.text = l6m1.statement;
                mission2.text = l6m2.statement;
                mission3.text = l6m3.statement;
            }

        }
        else
        {
            mission1.text = "Kindly update the game from play store";
            mission2.text = "to get more missions if still see this window";
            mission3.text = "message developer at Gmail: Vickychaudhary8955@gmail.com";
            levelCount.text ="unavailable";
        }


    }

    public void CheckLevelCompletion(int level)
    {
        if(PlayerPrefs.GetInt("myLevel") <= levelsCreated)
        {
            if (missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1))] == false || missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1)) + 1] == false || missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1)) + 2] == false)
            {
                int myLevel = PlayerPrefs.GetInt("myLevel");
                if (PlayerPrefs.GetInt("myLevel") == 1)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.player.transform.position.z >= (PlayerPrefs.GetInt("l1m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if(!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                        
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && ballMotion.instance.fallenWoodenBoxes == (PlayerPrefs.GetInt("l1m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && ballMotion.instance.rb.velocity.z >= (PlayerPrefs.GetInt("l1m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }
                else if (PlayerPrefs.GetInt("myLevel") == 2)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.coinAmountThisGame >= (PlayerPrefs.GetInt("l2m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && ballMotion.instance.diamondsAmountInThisGame >= (PlayerPrefs.GetInt("l2m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && PlayerPrefs.GetInt("coins_amount") >= (PlayerPrefs.GetInt("l2m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }
                else if (PlayerPrefs.GetInt("myLevel") == 3)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.player.transform.position.z >= (PlayerPrefs.GetInt("l3m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && ballMotion.instance.diamondsAmountInThisGame >= (PlayerPrefs.GetInt("l3m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && ballMotion.instance.rb.velocity.z >= (PlayerPrefs.GetInt("l3m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }
                else if (PlayerPrefs.GetInt("myLevel") == 4)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.coinAmountThisGame >= (PlayerPrefs.GetInt("l4m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && PlayerPrefs.GetInt("diamonds_Amount") >= (PlayerPrefs.GetInt("l4m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && ballMotion.instance.rb.velocity.z >= (PlayerPrefs.GetInt("l4m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }
                else if (PlayerPrefs.GetInt("myLevel") == 5)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.coinAmountThisGame >= (PlayerPrefs.GetInt("l5m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && PlayerPrefs.GetInt("diamonds_Amount") >= (PlayerPrefs.GetInt("l5m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && PlayerPrefs.GetInt("coins_amount") >= (PlayerPrefs.GetInt("l5m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }

                else if (PlayerPrefs.GetInt("myLevel") == 6)
                {
                    if (missionsDone[(myLevel * (myLevel - 1)) + 0] == false && ballMotion.instance.player.transform.position.z >= (PlayerPrefs.GetInt("l6m1")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 0] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 1).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[0].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 1] == false && ballMotion.instance.fallenWoodenBoxes >= (PlayerPrefs.GetInt("l6m2")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 1] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 2).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[1].SetActive(false);
                        }
                    }
                    if (missionsDone[(myLevel * (myLevel - 1)) + 2] == false && ballMotion.instance.rb.velocity.z >= (PlayerPrefs.GetInt("l6m3")))
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        PlayerPrefs.SetInt(name, 1);
                        missionsDone[(myLevel * (myLevel - 1)) + 2] = true;
                        updateMissions();
                    }
                    else
                    {
                        string name = "mission" + ((myLevel * (myLevel - 1)) + 3).ToString();
                        if (!PlayerPrefs.HasKey(name))
                        {
                            missionsCompleted[2].SetActive(false);
                        }
                    }
                }

            }
            else if (missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1))] == true && missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1)) + 1] == true && missionsDone[(PlayerPrefs.GetInt("myLevel") * (PlayerPrefs.GetInt("myLevel") - 1)) + 2] == true)
            {
                int curLevel = PlayerPrefs.GetInt("myLevel");
                for(int i = 0; i < 3; i++)
                {
                    string playerprefNames = "l" + curLevel.ToString() + "m" + (i+1).ToString();
                    PlayerPrefs.DeleteKey(playerprefNames);
                }
                
                ballMotion.instance.diamondsAmountInThisGame = 0;
                PlayerPrefs.SetInt("myLevel", PlayerPrefs.GetInt("myLevel") + 1);
                levelCount.text = PlayerPrefs.GetInt("myLevel").ToString();
                GetMission(PlayerPrefs.GetInt("myLevel"));
            }
        }
        
    }
    void Update()
    {
        CheckLevelCompletion(PlayerPrefs.GetInt("myLevel"));
    }
}
