using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithRamp : MonoBehaviour
{
    public static collisionWithRamp instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("incline"))
        {
            PlayerPrefs.SetString("onRamp", "true");
            Invoke("MakeFalse", 5f);
        }
    }
    void MakeFalse()
    {
        PlayerPrefs.SetString("onRamp", "false");
    }
}
