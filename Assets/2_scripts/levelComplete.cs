using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class levelComplete : MonoBehaviour
{
    public Text levelUpText;
    public Text scoreText;
    public ballMotion ballMotionScript;

    //public GameObject LevelUp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "levelUp")
        {
            levelUpText.enabled = true;
            scoreText.enabled = false;
            ballMotionScript.enabled = false;
            Invoke("NextLevel", 5f);
            //Invoke("Restart", 5f);
        }
    }
   
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
