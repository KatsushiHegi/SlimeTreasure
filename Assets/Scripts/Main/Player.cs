using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attackFlag;
    [SerializeField] Joystick _joystick = null;
    private const float SPEED = 0.15f; //移動速度
    public  ParticleSystem smoke;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Vector3 pos = transform.position;
        Vector3 savePos = pos;

        pos.x += _joystick.Direction.x * SPEED;
        pos.z += _joystick.Direction.y * SPEED;

        Vector3 diff = pos - savePos;

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
            animator.SetTrigger("isRun");
            if (!smoke.isEmitting)
            {
                smoke.Play();
            }
        }
        else
        {
            animator.ResetTrigger("isRun");
            if (smoke.isEmitting)
            {
                smoke.Stop();
            }
        }


        transform.position = pos;
    }
}
