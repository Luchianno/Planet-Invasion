using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    public float FramesPerSecond = 30;

    [SerializeField]
    [NonReorderable]
    List<Sprite> sprites;
    
    [SerializeField]
    Image image;
    int index = 0;
    float timer = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if ((timer += Time.deltaTime) >= (1 / FramesPerSecond))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Count;
        }
    }
}
