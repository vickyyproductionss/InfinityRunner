using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class sound : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "obstacle")
        {
            source.Play();
        }
        
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "road")
        {
            source.Pause();
        }
    }
}
