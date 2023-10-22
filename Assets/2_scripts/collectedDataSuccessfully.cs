using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedDataSuccessfully : MonoBehaviour
{

    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterToPlayScreen()
    {
        screen2.SetActive(true);
        screen1.SetActive(false);
    }
    public void EnterToMainScreen()
    {
        screen4.SetActive(true);
        screen3.SetActive(false);
    }
}
