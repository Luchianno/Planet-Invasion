using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameScreen : BaseScreen
{
    public Button Restart;

    [SerializeField]
    Image image;

    [SerializeField]
    TextMeshProUGUI description;

    [SerializeField]
    TextMeshProUGUI title;

    void Start()
    {
        Restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    // public void Init(string title, string description, Sprite image)
    // {
    //     (string, string, Sprite) data = transitionData as (string, string, Sprite);
    //     this.image.sprite = image;
    //     this.title.text = title;
    //     this.description.text = description;
    // }
}
