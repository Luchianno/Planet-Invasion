using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PI/Game Settings")]
public class GameSettings : ScriptableObject
{
    public bool ShowAllCards = false;
    public bool CardSelectionLimit;
    public string SavePath = "StreamingAssets/Saves";
    public int SaveFileVersion = 1;
}
