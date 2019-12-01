using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScreenMgr;
using DG.Tweening;

public class ScaleAnimatedScreen : BaseScreen
{
    [Header("Scale Aniamtion")]
    public float InTime = 0.3f;
    public float OutTime = 0.3f;

    public Ease InAnimation = Ease.OutCubic;
    public Ease OutAnimation = Ease.InCubic;

    public RectTransform ScaleTarget;

    public override void OnAnimationIn()
    {
        ScaleTarget.DOScale(1f, InTime)
            .From(0)
            .SetEase(InAnimation)
            .OnComplete(OnAnimationInEnd);
    }

    public override void OnAnimationOut()
    {
        ScaleTarget.DOScale(0f, OutTime)
            .From(1)
            .SetEase(OutAnimation)
            .OnComplete(OnAnimationOutEnd);
    }
}
