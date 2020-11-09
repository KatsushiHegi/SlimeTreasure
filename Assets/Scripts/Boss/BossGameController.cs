using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class BossGameController : MonoBehaviour
{
    public GameObject FadeImage, ResultObj;
    public Text NameText, KillCounter, SwordCounter;
    public Slider BossHpSlider;

    public BossGamePlayerController PlayerController;
    public BossGameBossController BossController;

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
        if (flag) StartCoroutine(ResultThered());
    }

    public void ReDispHp()
    {
        BossHpSlider.value = (float)bossGameSystem.Boss.hp / Boss.maxHp;
    }


    IEnumerator MainThered()
    {
        Init();
        yield return FadeIn();

    }

    IEnumerator ResultThered()
    {
        yield return BossController.PlayBossDead();
        ResultObj.SetActive(true);
    }


    IEnumerator FadeIn()
    {
        FadeImage.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1);
        FadeImage.SetActive(false);
    }
}
