using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeControlMobile : MonoBehaviour
{
    //public GameObject Player;
    public int threshHold = 10;
    public float gap = 3.3f;
    Touch touch;
    Vector2 initialPos;
    Vector2 finalPos;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                
                initialPos = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                finalPos = touch.position;
                if ((finalPos.x - initialPos.x) < threshHold)
                {
                    Vector3 ballInitPos;
                    ballInitPos = ballMotion.instance.player.transform.position;
                    Vector3 newBallPos = new Vector3(ballInitPos.x - gap, ballInitPos.y, ballInitPos.z);
                    ballMotion.instance.player.transform.position = newBallPos;
                }
                else if ((finalPos.x - initialPos.x) > threshHold)
                {
                    Vector3 ballInitPos;
                    ballInitPos = ballMotion.instance.player.transform.position;
                    Vector3 newBallPos = new Vector3(ballInitPos.x + gap, ballInitPos.y, ballInitPos.z);
                    ballMotion.instance.player.transform.position = newBallPos;
                }
            }
            
        }
    }
}
