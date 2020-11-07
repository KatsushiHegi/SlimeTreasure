using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGamePlayerController : MonoBehaviour
{
    public BossGameEffectController EffectController;

    [SerializeField] GameObject[] Swords;
    [SerializeField] GameObject Player;

    Animator playerAnim;

    int swordNum;
    public void SetPlayer(BossGameSystem bossGameSystem)
    {
        swordNum = bossGameSystem.GameConfig.activeSwordNum;
        Swords[swordNum].SetActive(true);
        playerAnim = Player.GetComponent<Animator>();
    }

    public IEnumerator PlayAttack()
    {
        playerAnim.SetTrigger("Attack");
        EffectController.Attack(swordNum, Player.transform.position, Player.transform.rotation);
        yield return new WaitForSeconds(0.5f);
    }
}
