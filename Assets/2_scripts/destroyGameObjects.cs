using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGameObjects : MonoBehaviour
{
    public GameObject thisObject;
    public int distanceForDestroying = 100 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisObject.transform.position.z < ballMotion.instance.player.transform.position.z - distanceForDestroying)
        {
            Destroy(thisObject, 1);
        }
    }
}
