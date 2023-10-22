using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeObstacleMaterial : MonoBehaviour
{
    public Material[] material;
    public int numberOfMaterials = 6;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < numberOfMaterials; i++)
        {
            if (PlayerPrefs.GetInt("obstacles") == i + 1)
            {
                meshRenderer.material = material[i];
            }
        }

    }
}
