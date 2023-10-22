using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class levelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject everythingScreen;
    public Slider slider;
    public Text progressText;

    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(Asynchronously(sceneIndex));
    }

    IEnumerator Asynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        everythingScreen.SetActive(false);

        while(operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = "LOADING..." + (progress * 100f).ToString("#") + "%";
            yield return null;
        }
    }
}
