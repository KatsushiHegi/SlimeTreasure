using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy_parent;
    public GameObject ItemBoxPanel,Fade,ToBossImage,canvas;
    public Text killCounter,swordCounter,nameText;
    public ItemSystem itemSystem;
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
        itemSystem.loadItem(GameConfig.swordCount, GameConfig.activeSword, GameConfig.kakeraCounts);
    }

    public void ToBoss()
    {
        StartCoroutine(ToBossThered());
    }
    IEnumerator ToBossThered()
    {
        Instantiate(ToBossImage, canvas.transform);
        yield return new WaitForSeconds(1.5f);
        Fade.SetActive(true);
        Fade.transform.SetAsLastSibling();
        Fade.GetComponent<Animator>().Play("Fade Out");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Boss");
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
        float x, z;
        LoadDataFromLocal();
        Init();
        yield return fadeIn();


        StartCoroutine(SlimePop());
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

    IEnumerator SlimePop()
    {
        float x, z;
        GameObject[] slimes=new GameObject[50];
        while (true)
        {
            for (int i = 0; i < slimes.Length; i++)
            {
                if (slimes[i] == null)
                {
                    x = UnityEngine.Random.Range(-50, 50);
                    z = UnityEngine.Random.Range(-50, 50);
                    slimes[i] = Instantiate(Enemy, new Vector3(x, 0, z), Quaternion.identity, Enemy_parent.transform);
                }
            }
            yield return new WaitForSeconds(10);
        }

    }
}

