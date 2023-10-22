using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSkinSelection : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("dealingWith"))
        {
            PlayerPrefs.SetString("dealingWith", "none");
        }
    }

    public void dealingWithRoutes()
    {
        PlayerPrefs.SetString("dealingWith", "routes");
    }

    public void dealingWithObstacles()
    {
        PlayerPrefs.SetString("dealingWith", "obstacles");
    }
}
