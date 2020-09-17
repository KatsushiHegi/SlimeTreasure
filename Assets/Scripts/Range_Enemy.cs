using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Enemy : MonoBehaviour
{
    GameObject Enemy;
    const float SPEED_ENEMY = 0.075f;
    void Start()
    {
        Enemy = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy.GetComponent<Enemy>().flag_range = true;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = collision.gameObject;
            Enemy.transform.LookAt(Player.transform);
            if (Vector3.Distance(Enemy.transform.position, Player.transform.position) > 2)//EnemyとPlayerとの距離が２よりも離れていたら近づく
            {
                Enemy.transform.position += Enemy.transform.rotation * new Vector3(0, 0, SPEED_ENEMY);
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy.GetComponent<Enemy>().flag_range = false;
        }
    }
}
