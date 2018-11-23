using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "PI/Game State")]
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

    [Header("Careful, don't mess this up")]
    public int Turn = 0;

    public PlayerState Player = new PlayerState();

    public AIState AI = new AIState();

    public StoryLog Story = new StoryLog();

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
