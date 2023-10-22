using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playClickSound : MonoBehaviour
{

    public AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayClickSoundSFX()
    {
        clickSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
