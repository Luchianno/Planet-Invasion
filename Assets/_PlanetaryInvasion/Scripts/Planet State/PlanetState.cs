using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "PI/Game State")]
[Serializable]
public class PlanetState : ScriptableObject
{
    GameSettings settings;

    int version;

    [Inject]
    public void Init(GameSettings settings)
    {
        this.settings = settings;
        this.version = settings.SaveFileVersion;
    }

    void OnEnable()
    {
        // var countries = AI.CountryStates;
        // for (int i = 0; i < countries.Count; i++)
        // {
        //     countries[i] = Instantiate(countries[i]);
        // }
    }

    [NonSerialized]
    public int Turn = 0;

    public PlayerState Player = new PlayerState();

    public AIState AI = new AIState();

    public GameEventLog EventLog = new GameEventLog();

    // public List<Report> Reports = new List<Report>();

    public void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(this, true);

        string filePath = Path.Combine(Application.dataPath, settings.SavePath);
        File.WriteAllText(filePath, dataAsJson);
    }

    public PlanetState LoadGameData(string gameDataFileName)
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Path.Combine(Application.dataPath, settings.SavePath), gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            PlanetState loadedData = null;

            try
            {
                loadedData = JsonUtility.FromJson<PlanetState>(dataAsJson);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Cannot load game data!");
                Debug.LogError(e.ToString());
                // throw;
            }

            return loadedData;
        }
        else
        {
            Debug.LogError("file on path does not exist!");
            return null;
        }
    }
}
