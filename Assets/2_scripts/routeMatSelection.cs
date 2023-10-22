using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routeMatSelection : MonoBehaviour
{
    public Material[] material;
    public int numberOfMaterials = 6;
    public GameObject route;

    void Start()
    {
        MeshRenderer meshRenderer = route.GetComponent<MeshRenderer>();
        if (PlayerPrefs.HasKey("selectedMat"))
        {
            for (int i = 0; i < numberOfMaterials; i++)
            {
                if (PlayerPrefs.GetInt("selectedMat") == i)
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
