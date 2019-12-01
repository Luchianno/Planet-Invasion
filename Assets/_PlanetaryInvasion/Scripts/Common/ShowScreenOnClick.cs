using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class ShowScreenOnClick : MonoBehaviour
{
    public string ScreenName;

    Button button;

    [Inject]
    protected ScreenManager screenManager;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => screenManager.ShowScreen(ScreenName));
    }

}
