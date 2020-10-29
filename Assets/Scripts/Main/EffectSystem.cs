using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public GameObject[] effect;
    public ItemSystem itemSystem;

    /*
    public void effectActive(){
        int swordNum= int.Parse(itemSystem.activeSword().getSword().name);
        
        effect[swordNum-1].SetActive(false);
        effect[swordNum-1].SetActive(true);
    }
    */
    public void effectInstantiate(Vector3 pos,Quaternion rot)
    {
        rot.eulerAngles += new Vector3(0, 0, 45);
        int swordNum = int.Parse(itemSystem.activeSword().getSword().name);
        StartCoroutine(desEffect(Instantiate(effect[swordNum], pos, rot)));
    }

    IEnumerator desEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(effect);
    }

}