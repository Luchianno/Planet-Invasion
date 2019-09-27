using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpdateableViewManager
{
    [Inject]
    readonly List<IUpdateableView> views;

    public void UpdateViews()
    {
        if (views != null)
        {
            foreach (var item in views)
            {
                item.UpdateView();
            }
        }
    }
}