using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameSystem
{
    public GameConfig GameConfig { get; private set; }

    public Boss Boss { get; private set; }
    public BossGameSystem()
    {
        LoadDataFromLocal();
        Boss = new Boss();
        Boss.hp = GameConfig.bossHp;
    }

    public void Attack()
    {
        Boss.hp--;
    }

    //save
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
