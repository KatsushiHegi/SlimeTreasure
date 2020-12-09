using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossGameController : MonoBehaviour
{
    public GameObject FadeImage, TapPanel;
    public Text NameText, KillCounter, SwordCounter;
    public Slider BossHpSlider;
    public BossGamePlayerController PlayerController;
    public BossGameBossController BossController;
    public BossGameResultController ResultController;
    public BossGameSoundController SoundController;

    BossGameSystem bossGameSystem;

    bool flag;
    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSに設定
    }
    void Start()
    {
        bossGameSystem = new BossGameSystem();
        StartCoroutine(MainThered());
    }

    void Init()
    {
        DispInit();
    }

    void DispInit()
    {
        NameText.text = bossGameSystem.GameConfig.playerName;
        KillCounter.text = bossGameSystem.GameConfig.killCount.ToString();
        SwordCounter.text = bossGameSystem.GameConfig.swordCount.ToString();
        BossHpSlider.value = (float)bossGameSystem.Boss.hp / Boss.maxHp;
        PlayerController.SetPlayer(bossGameSystem);
        StartCoroutine(BossAutoRecovery());
    }

    public void AttackToBoss()
    {
        flag=bossGameSystem.Attack();
        ReDispHp();
        StartCoroutine(PlayerController.PlayAttack());
        StartCoroutine(BossController.PlayBossTakenDam());
        if (flag)
        {
            StartCoroutine(ResultThered());
        }
    }

    public void ReDispHp()
    {
        BossHpSlider.value = (float)bossGameSystem.Boss.hp / Boss.maxHp;
    }

    public void ButtonClick()
    {
        StartCoroutine(ToMainThered());
    }


    IEnumerator BossAutoRecovery()
    {
        while (!flag)
        {
            yield return new WaitForSeconds(0.8f);
            if (!flag)
            {
                bossGameSystem.Boss.Recovery();
                ReDispHp();
            }
        }
    }


    IEnumerator MainThered()
    {
        Init();
        SoundController.BossBgmFadeIn();
        yield return FadeIn();
        if (bossGameSystem.GameConfig.nowPlace == 2) { yield return StartCoroutine(ResultThered()); }
    }

    IEnumerator ResultThered()
    {
        TapPanel.SetActive(false);
        bossGameSystem.Clear();
        SoundController.BossBgmFadeOut();
        yield return BossController.PlayBossDead();
        SoundController.ResultBgmFadeIn();
        ResultController.SetResult(bossGameSystem);
    }

    IEnumerator ToMainThered()
    {
        bossGameSystem.GameConfig.nowPlace = 0;
        bossGameSystem.SaveDataToLocal();

        SoundController.ResultBgmFadeOut();
        yield return FadeOut();
        SceneManager.LoadScene("Main");
    }


    IEnumerator FadeIn()
    {
        FadeImage.GetComponent<Animator>().SetTrigger("fadeIn");
        yield return new WaitForSeconds(1);
        FadeImage.SetActive(false);
    }
    IEnumerator FadeOut()
    {
        FadeImage.SetActive(true);
        FadeImage.GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(1);
    }
}
