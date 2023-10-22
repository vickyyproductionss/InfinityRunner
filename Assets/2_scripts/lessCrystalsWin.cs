using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lessCrystalsWin : MonoBehaviour
{
    public GameObject Warningwin;
    public static lessCrystalsWin instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
