using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    
    void LateUpdate()
    {
        Vector3 playerPos = player.position;
        //transform.position = new Vector3(0, playerPos.y, playerPos.z - 10) + offset;
        transform.position = player.position + offset;
    }

}
