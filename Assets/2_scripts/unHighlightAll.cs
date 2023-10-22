using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unHighlightAll : MonoBehaviour
{
    public static unHighlightAll instance;
    public GameObject playerContent;
    public GameObject routeContent;
    public GameObject glowContent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UnhighlighAll(int index)
    {
        if(index == 0)
        {
            for (int i = 0; i < purchase_new_ball.instance.totalMats; i++)
            {
                GameObject go = playerContent.gameObject.transform.GetChild(i).gameObject;
                go.GetComponent<Image>().color = Color.white;
            }
        }
        if (index == 1)
        {
            for (int i = 0; i < purchase_new_route.instance.totalMats; i++)
            {
                GameObject go = routeContent.gameObject.transform.GetChild(i).gameObject;
                go.GetComponent<Image>().color = Color.white;
            }
        }
        if (index == 2)
        {
            for (int i = 0; i < purchase_new_glow_edge.instance.totalMats; i++)
            {
                GameObject go = glowContent.gameObject.transform.GetChild(i).gameObject;
                go.GetComponent<Image>().color = Color.white;
            }
        }
    }
}
