using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    float waitTime;

    [SerializeField]
    float fadeInTime;

    [SerializeField]
    float fadeOutTime;

    [SerializeField]
    Image fadeImage;

    [SerializeField]
    AnyKeyDownDetector keyListener;

    [SerializeField]
    UniGifImage gifImage;

    void Start()
    {
        keyListener.enabled = false;
        keyListener.AnyKeyUp.AddListener(KeyUp);
        fadeImage.color = Color.black;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(waitTime);
        while (gifImage.nowState != UniGifImage.State.Playing)
        {
            // Debug.Log(gifImage.nowState);
            yield return null;
        }

        // Debug.Log("lalala");
        fadeImage.CrossFadeAlpha(0f, fadeInTime, false);
        yield return new WaitForSeconds(fadeInTime);
        keyListener.enabled = true;
    }

    IEnumerator FadeOut()
    {
        // start fading
        fadeImage.CrossFadeAlpha(1f, fadeOutTime, false);

        // start async scene load
        Debug.Log("start scene load");
        var op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        // op.allowSceneActivation = false;
        yield return op;
        Debug.Log(" scene load complete");

        op.allowSceneActivation = true;
        op = SceneManager.UnloadSceneAsync(0);
        yield return op;
        Debug.Log("menu scene unload complete");
    }

    void KeyUp()
    {
        keyListener.enabled = false;
        StartCoroutine(FadeOut());
    }
}
