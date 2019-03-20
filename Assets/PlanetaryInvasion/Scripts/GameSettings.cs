using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PI/Game Settings")]
public class GameSettings : ScriptableObject
{
    public bool ShowAllCards = false;
    public int CardSelectionLimit = 3;
    public string SavePath = "StreamingAssets/Saves";
    public int SaveFileVersion = 1;
}
