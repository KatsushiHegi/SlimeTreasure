using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        SaveDataToLocal();
    }

    public bool Attack()
    {
        Boss.hp--;
        if (Boss.hp <= 0)
        {
            return true;
        }
        return false;
    }

    public int FindTreasure()
    {
        GameConfig.TreasuresCount++;
        if (GameConfig.TreasuresCount > 3)
        {
            GameConfig.TreasuresCount = 3;
            return 0;
        }
        return GameConfig.TreasuresCount;
    }
    
    public void Clear()
    {
        GameConfig.clearCount++;
        GameConfig.nowPlace = 2;
        Debug.Log(GameConfig.nowPlace);
        SaveDataToLocal();
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
