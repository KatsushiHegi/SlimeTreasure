using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameBossController : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    Animator bossAnim;

    void Start()
    {
        bossAnim = Boss.GetComponent<Animator>();
    }
    public IEnumerator PlayBossTakenDam()
    {
        bossAnim.Play("TakenDam");
        yield return new WaitForSeconds(0.5f);
    }
    public IEnumerator PlayBossDead()
    {
        yield return new WaitForSeconds(0.5f);
        bossAnim.Play("Dead");
        yield return new WaitForSeconds(1);
    }
}
