using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haveCrystal : MonoBehaviour
{
    
    void Start()
    {
        if(Random.Range(0, 3) == 1)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    
}
