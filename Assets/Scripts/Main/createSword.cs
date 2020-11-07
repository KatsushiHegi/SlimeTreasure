using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSword : MonoBehaviour
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
        itemSystem.gameSystem.GameConfig.sworded[swordNum] = true;
        item.setKCount(0);
        itemSystem.gameSystem.GameConfig.kakeraCounts[swordNum] = 0;
        item.delK();
        itemSystem.setSwordCount(itemSystem.getSwordCount() + 1);
        item.getButton().transform.Find("c").gameObject.SetActive(true);
        item.dispSwordButton();
    }
}
