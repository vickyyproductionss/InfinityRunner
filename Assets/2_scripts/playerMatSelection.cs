using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMatSelection : MonoBehaviour
{
    public Material[] material;
    public int numberOfMaterials = 6;
    public GameObject player;
    public string playerprefsName;

    void Start()
    {
        MeshRenderer meshRenderer = player.GetComponent<MeshRenderer>();
        if(PlayerPrefs.HasKey(playerprefsName))
        {
            for (int i = 0; i < numberOfMaterials; i++)
            {
                if (PlayerPrefs.GetInt(playerprefsName) == i)
                {
                    meshRenderer.material = material[i];
                }
            }
        }
        else
        {
            meshRenderer.material = material[0];
        }
    }
}
