using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public ballMotion ballMotionScript;

    public static collision instance;
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
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "obstacle" )
        {

            ballMotionScript.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }

    public void enableScript()
    {
        ballMotionScript.enabled = true;
    }

    public void disableScript()
    {
        ballMotionScript.enabled = false;
    }
}
