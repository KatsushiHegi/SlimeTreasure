using System;
using UnityEngine;

public class TitleSystem 
{
    public GameConfig GameConfig { get; private set; }

    public TitleSystem()
    {
        LoadDataFromLocal();
    }

    public void LoadDataFromLocal()
    {
        string json = PlayerPrefs.GetString("gameconfig", null);
        GameConfig = String.IsNullOrEmpty(json) ? new GameConfig() : JsonUtility.FromJson<GameConfig>(json);
    }
    public void SaveDataToLocal()
    {
        var json = JsonUtility.ToJson(GameConfig);
        PlayerPrefs.SetString("gameconfig", json);
    }
}
