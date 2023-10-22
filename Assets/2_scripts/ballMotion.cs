using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;


public class ballMotion : MonoBehaviour
{
    public static ballMotion instance;
    public AxisTouchButton axisTouchButton_axisValueNegative;
    public AxisTouchButton axisTouchButton_axisValuePositive;
    public AudioSource source;
    public AudioSource source2;
    public AudioSource oncollisonWithRoad;

    public GameObject player;
    private List<GameObject> specialWoodenBoxes;
    public Rigidbody rb;
    public Text diamondsValue;
    public Text speedValue;
    public TMP_Text scoreIncrementOnBoxCollision;
    public TMP_Text inAirReward_text;
    public TMP_Text onCoinCollection_text;
    public TMP_Text speedIncreaseAvailableTokens;
    public TMP_Text speedDecreaseAvailableTokens;

    public Toggle IncreaseSpeed;

    public GameObject groundTile;
    public GameObject IncreaseSpeednote;
    public GameObject DecreaseSpeednote;
    public GameObject boxHitScoreNote;
    public GameObject inAirReward_gameobject;
    public GameObject onCoinCollection_gameobject;

    public float forceValue = 30f;
    public float forceValue2 = 0.002f;
    public float forceValue3 = 0.002f;
    public float moveSpeed = 500f;
    public float moveSpeed2 = 0.90f;
    public float swipeCheck = 0;
    public float SwipeForce = 20;
    public float sensitivity = 0.8f;
    public float maxSpeed = 30;
    public float minSpeed = 5;

    public float Move;
    public float boundary1;
    public float boundary2;
    private float dirX;

    public Touch touch;

    public bool gameIsEnded = false;
    public bool gameIsStarted = false;
    public bool inAir = false;
    bool freezeX = false;

    float rotX = 0;
    float rotY = 10;
    float rotZ = 0;
    public int diamondsAmountInThisGame;
    public int coinAmountThisGame;
    public int speedBoostThisGame;
    public int speedLostThisGame;
    public float currentScore;
    public float bonusScore = 0;
    public float inAirBonusScore = 0;
    int collisionsWithSpecialWoodenBox;
    public int fallenWoodenBoxes;
    Vector2 touchPosition;
    Vector3 oldPos;

    GameManager GameManagerScript;
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
    public void Start()
    {
        speedIncreaseAvailableTokens.text = PlayerPrefs.GetInt("speedUpTokens").ToString();
        speedDecreaseAvailableTokens.text = PlayerPrefs.GetInt("speedDownTokens").ToString();
        currentScore = 0;
        speedLostThisGame = 0;
        speedBoostThisGame = 0;
        coinAmountThisGame = 0;
        if(PlayerPrefs.HasKey("highestNumberFallenBox"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("highestNumberFallenBox"); i++)
            {
                string name = "fallenBox" + i.ToString();
                PlayerPrefs.DeleteKey(name);

            }
        }
        
        
        collisionsWithSpecialWoodenBox = 0;
        diamondsAmountInThisGame = 0;
        fallenWoodenBoxes = 0;

        specialWoodenBoxes = new List<GameObject>();
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            PlayerPrefs.SetFloat("highscore", 0);
            PlayerPrefs.SetFloat("firstTime", 0);
        }
        //enhance_script.instance.HideBanner();
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetFloat("sens_value") > 0)
        {
            sensitivity = PlayerPrefs.GetFloat("sens_value");
            
        }
        else
        {
            PlayerPrefs.SetFloat("sens_value", 0.5f);

        }
        oldPos = player.transform.position;
        if(!PlayerPrefs.HasKey("diamondsAmount"))
        {
            diamondsValue.text = "0";
        }
        diamondsValue.text = GameManager.instance.convertToKiloSystem(PlayerPrefs.GetInt("diamondsAmount"));
        //PlayerPrefs.DeleteAll();
        Invoke("OnGameStart", 3.1f);
        GameManagerScript = FindObjectOfType<GameManager>();
        source = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void setSensitivity()
    {
        axisTouchButton_axisValueNegative.axisValue = -2 * sensitivity;
        axisTouchButton_axisValuePositive.axisValue = 2 * sensitivity;
    }
    public void FixedUpdate()
    {
        if(inAir)
        {
            inAirReward_gameobject.SetActive(true);
            inAirBonusScore += 1;
            inAirReward_text.text = inAirBonusScore + " x airtime";
        }
        if (!inAir)
        {
            inAirReward_gameobject.SetActive(false);
        }
        currentScore = player.transform.position.z + bonusScore + inAirBonusScore;
        for(int i = 0; i < collisionsWithSpecialWoodenBox; i++)
        {
            string name = "fallenBox" + i.ToString();
            if(!PlayerPrefs.HasKey(name))
            {
                if (specialWoodenBoxes[i].transform.position.y < GroundSpawner.instance.nextSpawnPoint.y - 5)
                {
                    fallenWoodenBoxes++;
                    PlayerPrefs.SetInt(name, 1);
                    Destroy(specialWoodenBoxes[i]);
                    PlayerPrefs.SetInt("highestNumberFallenBox", fallenWoodenBoxes);
                }
            }  
        }
        if(rb.velocity.z <= 0)
        {
            speedValue.text = "0" + "km/h";
        }
        else if (rb.velocity.z >= 0)
        {
            speedValue.text = rb.velocity.z.ToString("#") + "km/h";
        }
        axisTouchButton_axisValueNegative.axisValue = -2*PlayerPrefs.GetFloat("sens_value");
        axisTouchButton_axisValuePositive.axisValue =  2*PlayerPrefs.GetFloat("sens_value");
        if (gameIsStarted == true)
        {
            rb = GetComponent<Rigidbody>();
            if (player.transform.position.z <= 15000)
            {
                rb.AddForce(0, 0, (forceValue + (player.transform.position.z) * 0.001f) * Time.deltaTime, ForceMode.VelocityChange);
                
            }
            else if(player.transform.position.z > 15000 && player.transform.position.z <= 30000)
            {
                rb.AddForce(0, 0, (forceValue * 1.5f) * Time.deltaTime, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(0, 0, (forceValue * 2) * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (rb.velocity.magnitude > maxSpeed && (PlayerPrefs.GetInt("difficultyLevel") == 0 || PlayerPrefs.GetInt("difficultyLevel") == 1 || PlayerPrefs.GetInt("difficultyLevel") == 2))
            {
                Vector3 backup = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, backup.z);
            }
            if (!PlayerPrefs.HasKey("easySpeed"))
            {
                PlayerPrefs.SetFloat("easySpeed", rb.velocity.z);
            }
            else
            {
                if (rb.velocity.z > PlayerPrefs.GetFloat("easySpeed"))
                {
                    PlayerPrefs.SetFloat("easySpeed", rb.velocity.z);
                }
            }
            if (maxSpeed <= 300)
            {
                maxSpeed = maxSpeed + 0.0005f;
            }
        }
        else
        {
            rb.transform.Rotate(rotX, rotY, rotZ);
            rotY -= 0.02f;
        }

        if (Time.timeScale == 0)
        {
            Debug.Log("game stopped due to time freeze");
        }


    }

    void swipeManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            swipeCheck = 0;
            rb.constraints = RigidbodyConstraints.None;
        }

        if (Input.GetMouseButtonUp(0) && swipeCheck == 0)
        {
            
            swipeCheck = 1;
            Vector2 swipeDelta = touchPosition - (Vector2)Input.mousePosition;

            if (swipeDelta.x > 5 && Mathf.Abs(swipeDelta.y) < 50)
            {
                rb.AddForce(-SwipeForce, 0, 0, ForceMode.Impulse);
                freezeX = true;
            }
            else if (swipeDelta.x < 5 && Mathf.Abs(swipeDelta.y) < 50)
            {
                rb.AddForce(SwipeForce, 0, 0, ForceMode.Impulse);
                freezeX = true;
            }
            
        }
    }
   
    void OnGameStart()
    {
        gameIsStarted = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(gameIsEnded == false)
        {
            if (collision.collider.CompareTag("obstacle"))
            {
                GameManagerScript.EndGame();
                if(PlayerPrefs.GetInt("Ad") == 0)
                {
                    enhance_script.instance.ShowRewardedAd();
                    PlayerPrefs.SetInt("Ad", PlayerPrefs.GetInt("Ad") + 1);
                }
                else if(PlayerPrefs.GetInt("Ad") == 1)
                {
                    PlayerPrefs.SetInt("Ad", PlayerPrefs.GetInt("Ad") + 1);
                    
                }
                else
                {
                    PlayerPrefs.SetInt("Ad", 0);
                }

                
            }
        }
        if (collision.collider.CompareTag("incline"))
        {
            inAir = true;
        }

    }

    private void Update()
    {
        
        if ((player.transform.position.x < oldPos.x - 6.5 ) && freezeX == true)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            player.transform.position = new Vector3(oldPos.x - 6.5f, player.transform.position.y, player.transform.position.z);
            oldPos = player.transform.position;
            freezeX = false;
            
            
        }
        if ((player.transform.position.x > oldPos.x + 6.5) && freezeX == true)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            player.transform.position = new Vector3(oldPos.x + 6.5f, player.transform.position.y, player.transform.position.z);
            oldPos = player.transform.position;
            freezeX = false;
            
            
        }
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed2;
        rb.AddForce(dirX, 0, 0, ForceMode.VelocityChange);
        if( transform.position.y < (GroundSpawner.instance.nextSpawnPoint.y - 20))
        {
            GameManagerScript.EndGame();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("obstacle"))
        {
            source.Play();
        }
        if (collision.collider.CompareTag("road") && inAir)
        {
            oncollisonWithRoad.Play();
        }
        if (collision.collider.CompareTag("road"))
        {
            inAir = false;
        }

        if (collision.collider.CompareTag("specialWoodenBox") && !specialWoodenBoxes.Contains(collision.gameObject))
        {
            //currentScore = currentScore + 1000;
            scoreIncrementNoteOnBoxHit();
            specialWoodenBoxes.Add(collision.gameObject);
            collisionsWithSpecialWoodenBox++;
            scoreIncrementNoteOnBoxCollision_activate();
            inAir = false;
        }
        if (collision.collider.CompareTag("specialWoodenBox"))
        {
            inAir = false;
            oncollisonWithRoad.Play();
        }
        
    }
    void scoreIncrementNoteOnBoxCollision_activate()
    {
        scoreIncrementOnBoxCollision.text = "+" + 100 * (ballMotion.instance.fallenWoodenBoxes + 1) + " Score";
        bonusScore += 100 * (ballMotion.instance.fallenWoodenBoxes + 1);
        boxHitScoreNote.SetActive(true);
        Invoke("scoreIncrementNoteOnBoxCollision_deactivate", 1.5f);
    }
    void scoreIncrementNoteOnBoxCollision_deactivate()
    {
        boxHitScoreNote.SetActive(false);
    }
    void scoreIncrementNoteOnBoxHit()
    {
        //boxHitScoreNote.SetActive(true);
        //Invoke("hideIncrementNoteOnBoxHit", 3);
    }
    void hideIncrementNoteOnBoxHit()
    {
        boxHitScoreNote.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("diamond"))
        {
            diamondsAmountInThisGame++;
            int curDiamondVal = PlayerPrefs.GetInt("diamondsAmount");
            PlayerPrefs.SetInt("diamondsAmount", curDiamondVal + 1);
            diamondsValue.text = PlayerPrefs.GetInt("diamondsAmount").ToString();
        }
        if (other.CompareTag("coin"))
        {
            coinAmountThisGame++;
            onCoinCollection_gameobject.SetActive(false);
            OnCoinCollection_activate();
            PlayerPrefs.SetInt("coins_amount", PlayerPrefs.GetInt("coins_amount", 0) + 1);
        }
        if(other.CompareTag("speedLimiter"))
        {
            if(maxSpeed > 50)
            {
                maxSpeed -= 20;
                speedLostThisGame++;
                showSpeedNote1();
            }
            
        }
        if (other.CompareTag("speedBooster"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + 20);
            if(maxSpeed <= 300)
            {
                maxSpeed += 20;
                speedBoostThisGame++;
                showSpeedNote2();
            }    
        }
        if(other.CompareTag("booster"))
        {
            rb.AddForce(0, 30, 500, ForceMode.Impulse);
            inAir = true;
        }
        if(other.CompareTag("speedUpToken"))
        {
            int temp = PlayerPrefs.GetInt("speedUpTokens",0);
            temp++;
            PlayerPrefs.SetInt("speedUpTokens", temp);
            updateTokenValuetext();
        }
        if (other.CompareTag("speedDownToken"))
        {
            int temp = PlayerPrefs.GetInt("speedDownTokens", 0);
            temp++;
            PlayerPrefs.SetInt("speedDownTokens", temp);
            updateTokenValuetext();
        }
    }
    public void IncreaseSpeedWithTokens()
    {
        if(PlayerPrefs.GetInt("speedUpTokens") > 0 && rb.velocity.z < 280)
        {
            int temp = PlayerPrefs.GetInt("speedUpTokens");
            temp--;
            PlayerPrefs.SetInt("speedUpTokens", temp);
            maxSpeed += 20;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + 20);
            updateTokenValuetext();
            showSpeedNote2();
        }
        else if(rb.velocity.z > 280)
        {
            TMP_Text temp = IncreaseSpeednote.transform.GetChild(0).GetComponent<TMP_Text>();
            temp.fontSize = 30;
            temp.text = "Speed already maximum possible";
            temp.color = Color.white;
            IncreaseSpeednote.SetActive(true);
            Invoke("hideSpeedNote2", 1.5f);
        }
        else
        {
            TMP_Text temp = IncreaseSpeednote.transform.GetChild(0).GetComponent<TMP_Text>();
            temp.text = "Collect tokens first";
            temp.color = Color.white;
            IncreaseSpeednote.SetActive(true);
            Invoke("hideSpeedNote2", 1.5f);
        }
    }
    public void DecreaseSpeedWithTokens()
    {
        if (PlayerPrefs.GetInt("speedDownTokens") > 0 && rb.velocity.z > 50)
        {
            int temp = PlayerPrefs.GetInt("speedDownTokens");
            temp--;
            maxSpeed -= 20;
            PlayerPrefs.SetInt("speedDownTokens", temp);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - 20);
            updateTokenValuetext();
            showSpeedNote1();
        }
        else if (rb.velocity.z < 50)
        {
            TMP_Text temp = IncreaseSpeednote.transform.GetChild(0).GetComponent<TMP_Text>();
            temp.text = "Speed already minimum possible";
            temp.fontSize = 30;
            temp.color = Color.white;
            IncreaseSpeednote.SetActive(true);
            Invoke("hideSpeedNote2", 1.5f);
        }
        else
        {
            TMP_Text temp = IncreaseSpeednote.transform.GetChild(0).GetComponent<TMP_Text>();
            temp.text = "Collect tokens first";
            temp.color = Color.white;
            IncreaseSpeednote.SetActive(true);
            Invoke("hideSpeedNote2", 1.5f);
        }
    }
    void updateTokenValuetext()
    {
        speedIncreaseAvailableTokens.text = PlayerPrefs.GetInt("speedUpTokens").ToString();
        speedDecreaseAvailableTokens.text = PlayerPrefs.GetInt("speedDownTokens").ToString();
    }
    void OnCoinCollection_activate()
    {
        onCoinCollection_gameobject.SetActive(true);
        onCoinCollection_text.text = "+" + coinAmountThisGame;
        Invoke("OnCoinCollection_deactivate", 1);
    }
    void OnCoinCollection_deactivate()
    {
        onCoinCollection_gameobject.SetActive(false);
    }
    void showSpeedNote1()
    {
        DecreaseSpeednote.SetActive(true);
        Invoke("hideSpeedNote1", 1.5f);
    }
    void hideSpeedNote1()
    {
        DecreaseSpeednote.SetActive(false);
    }
    void showSpeedNote2()
    {
        TMP_Text temp = IncreaseSpeednote.transform.GetChild(0).GetComponent<TMP_Text>();
        temp.text = " +20 Speed";
        temp.color = Color.green;
        IncreaseSpeednote.SetActive(true);
        Invoke("hideSpeedNote2", 1.5f);
    }
    void hideSpeedNote2()
    {
        IncreaseSpeednote.SetActive(false);
    }
    public void BackButton()
    {
        SceneManager.GetSceneByBuildIndex(0);
    }
}
