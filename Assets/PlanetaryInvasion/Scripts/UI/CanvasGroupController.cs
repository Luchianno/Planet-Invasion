using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    public bool RenderingEnabled
    {
        get
        {
            return renderingEnabled;
        }
        set
        {
            // Debug.Log("rendering changed" + value);
            renderingEnabled = value;

            if (value)
                TurnOn();
            else
                TurnOff();
        }
    }

    public float FadeTime = 0.2f;

    CanvasGroup group;

    bool renderingEnabled;

    public void FadeOff()
    {
        StartCoroutine(fadeOffRoutine());
    }

    IEnumerator fadeOffRoutine()
    {
        float elapsed = 0;

        group.interactable = false;

        while (elapsed < FadeTime)
        {
            group.alpha = Mathf.SmoothStep(1f, 0f, elapsed / FadeTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        group.blocksRaycasts = false;
    }

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    void TurnOn()
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    void TurnOff()
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }
}