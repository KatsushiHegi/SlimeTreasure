using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
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
    void Start()
    {
        StartCoroutine(MainThered());
    }

    void Init()
    {
        bossGameSystem = new BossGameSystem();
        DispInit();
    }

    void DispInit()
    {
        NameText.text = bossGameSystem.GameConfig.playerName;
        KillCounter.text = bossGameSystem.GameConfig.killCount.ToString();
        SwordCounter.text = bossGameSystem.GameConfig.swordCount.ToString();
        BossHpSlider.value = (float)bossGameSystem.Boss.hp / Boss.maxHp;
        PlayerController.SetPlayer(bossGameSystem);
    }

    public void AttackToBoss()
    {
        bool flag;
        flag=bossGameSystem.Attack();
        ReDispHp();
        StartCoroutine(PlayerController.PlayAttack());
        StartCoroutine(BossController.PlayBossTakenDam());
        if (flag)
        {
            StartCoroutine(ResultThered());
            TapPanel.SetActive(false);
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


    IEnumerator MainThered()
    {
        SoundController.BossBgmFadeIn();
        Init();
        yield return FadeIn();

    }

    IEnumerator ResultThered()
    {
        bossGameSystem.SaveDataToLocal();
        SoundController.BossBgmFadeOut();
        yield return BossController.PlayBossDead();
        SoundController.ResultBgmFadeIn();
        ResultController.SetResult(bossGameSystem);
    }

    IEnumerator ToMainThered()
    {
        SoundController.ResultBgmFadeOut();
        yield return FadeOut();
        SceneManager.LoadScene("Main");
    }


    IEnumerator FadeIn()
    {
        FadeImage.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1);
        FadeImage.SetActive(false);
    }
    IEnumerator FadeOut()
    {
        FadeImage.SetActive(true);
        FadeImage.GetComponent<Animator>().Play("Fade Out");
        yield return new WaitForSeconds(1);
    }
}
