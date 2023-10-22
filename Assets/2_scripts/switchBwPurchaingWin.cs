using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBwPurchaingWin : MonoBehaviour
{
    public GameObject routesWin;
    public GameObject playersWin;
    public GameObject edgeGlowWin;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void Route_Player()
    {
        routesWin.SetActive(false);
        playersWin.SetActive(true);
    }
    public void Player_Route()
    {
        playersWin.SetActive(false);
        routesWin.SetActive(true);
    }
    public void Route_Glow()
    {
        routesWin.SetActive(false);
        edgeGlowWin.SetActive(true);
    }
    public void Player_Glow()
    {
        playersWin.SetActive(false);
        edgeGlowWin.SetActive(true);
    }
    public void Glow_player()
    {
        edgeGlowWin.SetActive(false);
        playersWin.SetActive(true);
    }
    public void Glow_Route()
    {
        edgeGlowWin.SetActive(false);
        routesWin.SetActive(true);
    }

}
