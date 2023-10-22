using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    highScore highscoreScript;
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    public GameObject diamond;
    public GameObject specialBox;
    public GameObject coins;
    public GameObject mysteryBox;
    public int spawnCount;
    bool spawningBox = false;
    bool spawnNow = false;
    public float thresholdHeight;
    public static GroundTile instance;
    
    
    
    
    void Start()
    {
        spawnCount = 1;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        highscoreScript = GameObject.FindObjectOfType<highScore>();
        
        if(PlayerPrefs.HasKey("firstTimeGame"))
        {
            SpawnObstacle();
            SpawnSpecialBox();
            spawnCoins();
            activateSpeedManagers();
            activateJumpBoosters();
            activateSpeedUpandDownKeys();
        }
        PlayerPrefs.SetString("firstTimeGame", "declared");


    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    groundSpawner.SpawnTile();
    //    Destroy(gameObject, 20);
    //}

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("roadParent").Length < 52 && spawnNow)
        {
            //groundSpawner.SpawnTile();
        }
        if(ballMotion.instance.player.transform.position.z > (GroundSpawner.instance.nextSpawnPoint.z - 100*50))
        {
            groundSpawner.SpawnTile();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            thresholdHeight = this.gameObject.transform.position.y;
            //groundSpawner.SpawnTile();
            if(GameObject.FindGameObjectsWithTag("roadParent").Length > 52)
            {
                Destroy(gameObject,1);
                if(!spawnNow)
                {
                    spawnNow = true;
                }
                
            }
            else
            {
                Destroy(gameObject, 5);
            }
            spawnCount++;
            Debug.Log(GameObject.FindGameObjectsWithTag("roadParent").Length);
        }
        
    }

    void SpawnObstacle()
    {
        int temp = PlayerPrefs.GetInt("rampGap", 0);
        PlayerPrefs.SetInt("rampGap", temp + 1);
        int obstacleSpawnProbability = Random.Range(0, 6);
        if (obstacleSpawnProbability == 2 && PlayerPrefs.GetInt("rampGap") > 30)
        {
            PlayerPrefs.SetInt("rampGap", 0);
            int obstacleSpawnIndex = Random.Range(1, 4);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
            Instantiate(obstaclePrefab2, spawnPoint.position, Quaternion.identity, transform);
        }
        else
        {
            int obstacleSpawnIndex = Random.Range(0, 3);
            transform.GetChild(13).GetChild(obstacleSpawnIndex).gameObject.SetActive(true);
        }
    }
    void SpawnSpecialBox()
    {
        int obstacleSpawnIndex = Random.Range(4, 7);
        int obstacleSpawnProbability = Random.Range(1, 50);
        if (obstacleSpawnProbability == 2)
        {
            spawningBox = true;
            Transform spawnpoint = transform.GetChild(obstacleSpawnIndex).GetChild(0).transform;
            Instantiate(specialBox, spawnpoint.position, Quaternion.identity);
        }
        else
        {
            spawningBox = false;
        }
    }

    void spawnCoins()
    {
        int numRowsToSpawn = Random.Range(1, 3);
        if(numRowsToSpawn == 1)
        {
            int whichRow = Random.Range(1, 4);
            if(whichRow == 1)
            {
                int i1 = Random.Range(0,10);
                int i2 = Random.Range(0,10);
                if(i1 > i2)
                {
                    for(int i = i2; i < i1; i++)
                    {
                        Transform spawnPositions = transform.GetChild(8).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
                else if(i1 < i2)
                {
                    for (int i = i1; i < i2; i++)
                    {
                        Transform spawnPositions = transform.GetChild(8).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
            }
            else if(whichRow == 2)
            {
                int i1 = Random.Range(0, 10);
                int i2 = Random.Range(0, 10);
                if (i1 > i2)
                {
                    for (int i = i2; i < i1; i++)
                    {
                        Transform spawnPositions = transform.GetChild(9).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
                else if (i1 < i2)
                {
                    for (int i = i1; i < i2; i++)
                    {
                        Transform spawnPositions = transform.GetChild(9).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
            }
            else if (whichRow == 3)
            {
                int i1 = Random.Range(0, 10);
                int i2 = Random.Range(0, 10);
                if (i1 > i2)
                {
                    for (int i = i2; i < i1; i++)
                    {
                        Transform spawnPositions = transform.GetChild(10).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
                else if (i1 < i2)
                {
                    for (int i = i1; i < i2; i++)
                    {
                        Transform spawnPositions = transform.GetChild(10).GetChild(i).transform;
                        Instantiate(coins, spawnPositions.position, Quaternion.identity);
                    }
                }
            }

        }
    }
    void activateSpeedManagers()
    {
        if(PlayerPrefs.HasKey("delayCount"))
        {
            int val = PlayerPrefs.GetInt("delayCount");
            PlayerPrefs.SetInt("delayCount", val + 1);
        }
        if(!PlayerPrefs.HasKey("delayCount"))
        {
            int random1 = Random.Range(0, 10);
            int random2 = Random.Range(0, 12);
            if (ballMotion.instance.maxSpeed > 50)
            {

                if (random1 == 1 && spawningBox == false)
                {
                    int speedLimiterIndex = Random.Range(0, 3);
                    transform.GetChild(11).GetChild(speedLimiterIndex).gameObject.SetActive(true);
                    PlayerPrefs.SetInt("delayCount", 0);
                }
            }

            if (random2 == 1 && spawningBox == false && random1 != 1)
            {
                int speedLimiterIndex = Random.Range(0, 3);
                transform.GetChild(12).GetChild(speedLimiterIndex).gameObject.SetActive(true);
                PlayerPrefs.SetInt("delayCount", 0);
            }
        }
        if(PlayerPrefs.GetInt("delayCount") >= 35)
        {
            PlayerPrefs.DeleteKey("delayCount");
        }
    }
    void activateJumpBoosters()
    {
        if(Random.Range(0,40) == 7 && PlayerPrefs.GetString("activateBoosters") == "true")
        {
            transform.GetChild(16).gameObject.SetActive(true);
            PlayerPrefs.SetString("activateBoosters", "false");
        }
        if (!PlayerPrefs.HasKey("activateBoosters"))
        {
            PlayerPrefs.SetString("activateBoosters", "declared");
        }
        if (!PlayerPrefs.HasKey("boostGap"))
        {
            PlayerPrefs.SetInt("boostGap", 0);
        }
        int temp = PlayerPrefs.GetInt("boostGap", 0);
        temp++;
        PlayerPrefs.SetInt("boostGap", temp);
        if (PlayerPrefs.GetInt("boostGap") == 75)
        {
            PlayerPrefs.SetInt("boostGap", 0);
            PlayerPrefs.SetString("activateBoosters", "true");
        }
        

    }
    void activateSpeedUpandDownKeys()
    {
        int temp = PlayerPrefs.GetInt("delayForSpeedKeys",0);
        if(temp > 50)
        {
            int random1 = Random.Range(0, 20);
            if(random1 == 5)
            {
                int random2 = Random.Range(1, 3);
                if(random2 == 1)
                {
                    int random3 = Random.Range(0, 3);
                    transform.GetChild(20).GetChild(0).GetChild(random3).gameObject.SetActive(true);
                }
                else
                {
                    int random3 = Random.Range(0, 3);
                    transform.GetChild(20).GetChild(1).GetChild(random3).gameObject.SetActive(true);
                }
            }
            PlayerPrefs.DeleteKey("delayForSpeedKeys");
        }
        PlayerPrefs.SetInt("delayForSpeedKeys", temp + 1);
    }
}
