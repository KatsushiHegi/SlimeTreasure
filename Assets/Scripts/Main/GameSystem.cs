using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy_parent;
    [SerializeField] GameObject[] Treasures;
    public GameObject ItemBoxPanel,Fade,ToBossImage,canvas;
    public Text killCounter,swordCounter,nameText;
    public ItemSystem itemSystem;
    private int killCount;
    public GameConfig GameConfig { get; private set; }

    public MainSoundController SoundController;



    public int getKillCount() { return this.killCount; }
    public void setKillCount(int killCount)
    {
        this.killCount = killCount;
        GameConfig.killCount = killCount;
    }
    public void incKillCount(int inc)
    {
        this.killCount += inc;
        GameConfig.killCount = killCount;
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
        for (int i = 0; i < GameConfig.TreasuresCount; i++)
        {
            Treasures[i].SetActive(true);
        }
        itemSystem.loadItem(GameConfig.swordCount, GameConfig.sworded, GameConfig.kakeraCounts, GameConfig.activeSwordNum);
    }

    public void BossChallenge()
    {
        if (UnityEngine.Random.value < 0.001f) ToBoss();
    }

    public void ToBoss()
    {
        StartCoroutine(ToBossThered());
    }
    IEnumerator ToBossThered()
    {
        GameConfig.nowPlace = 1;
        Instantiate(ToBossImage, canvas.transform);
        SoundController.PlayAndFadeToBossSe();
        yield return new WaitForSeconds(1.5f);
        Fade.SetActive(true);
        Fade.transform.SetAsLastSibling();
        Fade.GetComponent<Animator>().Play("Fade Out");
        SoundController.MainBgmFadeOut();
        yield return new WaitForSeconds(1f);
        SaveDataToLocal();
        SceneManager.LoadScene("Boss");
    }

    IEnumerator fadeIn()
    {
        SoundController.MainBgmFadeIn();
        Fade.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1);
        Fade.SetActive(false);

    }
    IEnumerator MainThered()
    {
        LoadDataFromLocal();
        Init();
        yield return fadeIn();
        StartCoroutine(SlimePop());
        StartCoroutine(SaveLoop());
    }
    //save
    public void LoadDataFromLocal()
    {
        string json = PlayerPrefs.GetString("gameconfig", null);
        GameConfig = String.IsNullOrEmpty(json) ? new GameConfig() : JsonUtility.FromJson<GameConfig>(json);
        //GameConfig = new GameConfig();
    }

    public void SaveDataToLocal()
    {
        var json = JsonUtility.ToJson(GameConfig);
        PlayerPrefs.SetString("gameconfig", json);
    }

    IEnumerator SlimePop()
    {
        float x, z;
        GameObject[] slimes = new GameObject[25];
        while (true)
        {
            for (int i = 0; i < slimes.Length; i++)
            {
                if (slimes[i] == null)
                {
                    x = UnityEngine.Random.Range(-50, 50);
                    z = UnityEngine.Random.Range(-50, 50);
                    slimes[i] = Instantiate(Enemy, new Vector3(x, 0.07f, z), Quaternion.identity, Enemy_parent.transform);
                }
            }
            yield return new WaitForSeconds(10);
        }

    }
    IEnumerator SaveLoop()
    {
        while (true)
        {
            SaveDataToLocal();
            yield return new WaitForSeconds(3);
        }
        
    }
}

