using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScreenMgr;
using Zenject;

[RequireComponent(typeof(Button))]
public class HideScreenOnClick : MonoBehaviour
{
    Button button;

    [Inject]
    ScreenManager screenManager;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => screenManager.Hide());
    }

}
