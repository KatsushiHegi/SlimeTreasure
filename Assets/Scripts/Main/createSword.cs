using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createSword : MonoBehaviour
{
    public ItemSystem itemSystem;
    private int swordNum;
    Item item;
    private void Start()
    {
        swordNum = int.Parse(this.gameObject.transform.parent.name);
        item = itemSystem.getItem(swordNum);
    }
    public void create()
    {
        item.setIsSword(true);
        item.setKCount(0);
        item.delK();
        item.getButton().transform.Find("c").gameObject.SetActive(true);
        item.dispSwordButton();
    }
}
