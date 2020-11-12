using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed_rand; //移動速度
    float time_rand, time_sum;
    public bool flag_range; //true：プレイヤーへ移動
    bool flag_moving;　//false:停止 true:移動
    bool flag_swich; //停止・移動の切り替えフラグ
    Animator animator;
    void Start()
    {
        flag_range = false;
        speed_rand = 0.05f;
        time_sum = 0;
        time_rand = 1;
        flag_moving = false;
        flag_swich = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        if (!flag_range)
        {
            if (flag_swich)
            {
                time_rand = Random.value * (3f - 1f) + 1f; //1~3の間でランダムに時間を設定
                speed_rand = Random.value * (0.075f - 0.025f) + 0.025f; //0.025~0.075の間でランダムにスピードを設定

                if (!flag_moving)
                {
                    flag_moving = true;
                    transform.rotation = Quaternion.Euler(0, Random.value * 360f, 0);//ランダムな方向に向きを変える
                    animator.SetBool("isRun", true);
                }
                else
                {
                    flag_moving = false;
                    animator.SetBool("isRun", false);
                }

                time_sum = 0;
                flag_swich = false;
            }
            else
            {
                time_sum += Time.deltaTime;//ランダムで定めた時間の間、停止・移動を続ける
                if (flag_moving)
                {
                    transform.position += transform.rotation * new Vector3(0, 0, speed_rand);//向いてる方向に向かってランダムで定めたスピードで移動する
                }
                if (time_sum >= time_rand) flag_swich = true;//ランダムで定めた時間が経過したら停止・移動を切り替えるフラグを立てる
            }
        }
    }
}
