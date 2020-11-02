using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy_parent;
    public GameObject ItemBoxPanel,Fade;
    public Text killCounter,swordCounter,nameText;
    public ItemSystem itemSystem;
    private float x, z;
    private int killCount;
    public GameConfig GameConfig { get; private set; }



    public int getKillCount() { return this.killCount; }
    public void setKillCount(int killCount)
    {
        this.killCount = killCount;
        GameConfig.killCount = killCount;
    //    dispKillCount();
    }
    public void incKillCount(int inc)
    {
        this.killCount += inc;
        disp(killCounter, killCount.ToString());
    }
    /*
    public void LoadDataFromLocal()
    {
        string json = PlayerPrefs.GetString("gameconfig", null);
        var data = String.IsNullOrEmpty(json) ? new GameConfig() : JsonUtility.FromJson<GameConfig>(json);
        GameConfig = data;
        Player = data is null ? new Player() : data.Player is null ? new Player() : data.Player;
    }

    public void SaveDataToLocal()
    {
        var json = JsonUtility.ToJson(GameConfig);
        PlayerPrefs.SetString("gameconfig", json);
    }
    */
    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSに設定
    }
    void Start()
    {
        StartCoroutine(MainThered());
    }


    public void OnClickItemBoxBotton()
    {
        ItemBoxPanel.SetActive(true);
        itemSystem.itemBoxControl();
    }

    public void disp(Text text,string msg)
    {
        text.text = msg;
    }

    void Init()
    {
        disp(nameText, GameConfig.playerName);
        setKillCount(GameConfig.killCount);
        disp(killCounter, killCount.ToString());
        Debug.Log("0");
        itemSystem.loadItem(GameConfig.swordCount, GameConfig.activeSword, GameConfig.kakeraCounts);
    }


    IEnumerator fadeIn()
    {
        //yield return null;
        Fade.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1);
        Fade.SetActive(false);

    }
    IEnumerator MainThered()
    {
        LoadDataFromLocal();
        Init();
        yield return fadeIn();


        for (int i = 0; i < 20; i++)
        {
            x = UnityEngine.Random.Range(-50, 50);
            z = UnityEngine.Random.Range(-50, 50);
            Instantiate(Enemy, new Vector3(x, 0, z), Quaternion.identity).transform.parent = Enemy_parent.transform;
        }
        killCount = 0;
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

