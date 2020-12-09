using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameEffectController : MonoBehaviour
{
    [SerializeField] GameObject[] SwordEffects;
    public void Attack(int swordNum, Vector3 pos, Quaternion rot)
    {
        rot.eulerAngles += new Vector3(0, 0, 45);
        StartCoroutine(delEffect(Instantiate(SwordEffects[swordNum], pos, rot)));
    }
    IEnumerator delEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(effect);
    }
}
