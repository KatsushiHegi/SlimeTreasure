using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy_parent;
    float x, z;
    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSに設定
    }
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            x = Random.value * 100 - 50;
            z = Random.value * 100 - 50;
            Instantiate(Enemy, new Vector3(x, 0, z), Quaternion.identity).transform.parent=Enemy_parent.transform;
        }
    }
}
