using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public GameObject[] effect;

    [SerializeField] GameObject DeathEffect;
    public ItemSystem itemSystem;
    bool flag;
    public void effectInstantiate(Vector3 pos, Quaternion rot)
    {
        if (!flag)
        {
            rot.eulerAngles += new Vector3(0, 0, 45);
            int swordNum = int.Parse(itemSystem.activeSword().getSword().name);
            StartCoroutine(destroyEffect(Instantiate(effect[swordNum], pos, rot)));
            flag = true;
            StartCoroutine(CoolTime());
        }
    }
    public void DeathEffectInstantiate(Vector3 pos, Quaternion rot)
    {
        StartCoroutine(destroyEffect(Instantiate(DeathEffect, pos, rot)));
    }

    IEnumerator destroyEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(effect);
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(0.2f);
        flag = false;
    }

}