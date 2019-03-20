using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Luchianno
{
    public static class CanvasGroupExtensions
    {
        public static void EnableInteraction(this CanvasGroup group)
        {
            group.interactable = true;
            group.blocksRaycasts = true;
            group.alpha = 1f;
        }

        public static void DisableInteraction(this CanvasGroup group)
        {
            group.interactable = false;
            group.blocksRaycasts = false;
            group.alpha = 0f;
        }
    }
}