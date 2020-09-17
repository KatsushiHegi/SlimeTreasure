using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Player : MonoBehaviour
{
    GameObject Player;
    Animator animator;
    AnimatorStateInfo animInfo;
    void Start()
    {
        Player = transform.parent.gameObject;
        animator = Player.GetComponent<Animator>();
        animInfo = animator.GetCurrentAnimatorStateInfo(0);
    }
    private void Update()
    {

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
                Destroy(collision.gameObject);
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
