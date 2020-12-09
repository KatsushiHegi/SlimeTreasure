using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Player : MonoBehaviour
{
    public GameSystem gameSystem;
    public ItemSystem itemSystem;
    public EffectSystem effectSystem;
    GameObject Player;
    Animator animator;
    AnimatorStateInfo animInfo;

    void Start()
    {
        Player = transform.parent.gameObject;
        animator = Player.GetComponent<Animator>();
        animInfo = animator.GetCurrentAnimatorStateInfo(0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy"
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
            && !animator.IsInTransition(0))
        {
            animator.SetTrigger("Attack");            
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Player.transform.LookAt(collision.gameObject.transform);
            animator.SetTrigger("Attack");
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                effectSystem.effectInstantiate(Player.transform.position, Player.transform.rotation);
                effectSystem.DeathEffectInstantiate(collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                Destroy(collision.gameObject);
                gameSystem.incKillCount(1);
                itemSystem.dropChallenge();
                if (gameSystem.GameConfig.clearCount > 0) gameSystem.BossChallenge();
                animator.ResetTrigger("Attack");
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.ResetTrigger("Attack");
        }
    }
}
