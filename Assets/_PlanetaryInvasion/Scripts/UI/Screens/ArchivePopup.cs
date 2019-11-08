using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using UnityEngine.UI;

public class ArchivePopup : BaseScreen
{
    public Button Close;

    void Start()
    {
        Close.onClick.AddListener(()=> screenManager.Hide());
    }
}
