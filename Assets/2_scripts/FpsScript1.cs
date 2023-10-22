using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FpsScript1 : MonoBehaviour
{
    public GameObject text;
    public Text fpsText;
    public float hudRefreshRate = 1f;

    public float timer;

    public void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = fps + " FPS on " + SceneManager.GetActiveScene().path;
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}