using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public GameObject[] effect;
    public float[] effectTime;
    public ItemSystem itemSystem;
    private bool flag;

    /*
    public void effectActive(){
        int swordNum= int.Parse(itemSystem.activeSword().getSword().name);
        
        effect[swordNum-1].SetActive(false);
        effect[swordNum-1].SetActive(true);
    }
    */
    public void effectInstantiate(Vector3 pos,Quaternion rot)
    {
        if (!flag)
        {
            rot.eulerAngles += new Vector3(0, 0, 45);
            int swordNum = int.Parse(itemSystem.activeSword().getSword().name);
            StartCoroutine(desEffect(Instantiate(effect[swordNum], pos, rot),effectTime[swordNum]));
            flag = true;
        }
    }

    IEnumerator desEffect(GameObject effect,float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(effect);
        flag = false;
    }

}