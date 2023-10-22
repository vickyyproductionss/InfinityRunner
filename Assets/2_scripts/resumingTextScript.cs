using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumingTextScript : MonoBehaviour
{
    public Text ResumingText;
    public GameObject ResumingTextField;


    public static resumingTextScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void ShowResumingtexts()
    {
        
        ResumingTextField.SetActive(true);
        Text1();
    }

    public void Text1()
    {
        //ballMotion.instance.rb.constraints = RigidbodyConstraints.FreezePositionX;
        //ballMotion.instance.rb.constraints = RigidbodyConstraints.FreezePositionZ;
        ResumingText.text = "Resuming in 3s";
        Invoke("Text2", 1);
    }
    public void Text2()
    {
        ResumingText.text = "Resuming in 2s";
        Invoke("Text3", 1);
    }
    public void Text3()
    {
        ResumingText.text = "Resuming in 1s";
        Invoke("HideText", 1);
    }

    public void HideText()
    {
        ballMotion.instance.rb.constraints = RigidbodyConstraints.None;
        
        ResumingTextField.SetActive(false);
    }
}
