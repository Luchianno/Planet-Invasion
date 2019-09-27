using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TMPro;

public class EndGameView : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    TextMeshProUGUI description;
    
    [SerializeField]
    TextMeshProUGUI title;

    public void Init(string title, string description, Sprite image)
    {
        this.image.sprite = image;
        this.title.text = title;
        this.description.text = description;
        
    }
}
