using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public GameObject[] effect;
    public ItemSystem itemSystem;
    private int swordNum;

    public void effectActive(){
        Debug.Log("解除");
        for(int i=0;i<5;i++){
            effect[i].SetActive(false);
        }
        this.swordNum = int.Parse(itemSystem.activeSword().getSword().name);
        switch(this.swordNum){
            case 1:effect[0].SetActive(true);break;
            case 2:effect[1].SetActive(true);break;
            case 3:effect[2].SetActive(true);break;
            case 4:effect[3].SetActive(true);break;
            case 5:effect[4].SetActive(true);break;
        }
    }
}