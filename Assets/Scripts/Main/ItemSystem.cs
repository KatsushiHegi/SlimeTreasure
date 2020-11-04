using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class ItemSystem : MonoBehaviour
{
    public GameObject[] swords;
    public GameObject[] buttons;
    public GameObject[] kakeras;
    public GameObject kParent;
    public GameObject ItemBoxPanel;
    public GameSystem gameSystem;
    Item[] items = new Item[6];
    private int swordCount;

    public int getSwordCount() { return swordCount; }
    public void setSwordCount(int swordCount) {
        this.swordCount = swordCount;
        gameSystem.GameConfig.swordCount = swordCount;
        gameSystem.disp(gameSystem.swordCounter, this.swordCount.ToString());
    }
    public Item getItem(int num) { return items[num]; }

    public void swordChange()
    {
        foreach (GameObject sword in swords)
        {
            if (Equals(sword.name, this.name))
            {
                sword.SetActive(true);
                ItemBoxPanel.SetActive(false);
            }
            else
            {
                sword.SetActive(false);
                ItemBoxPanel.SetActive(false);
            }
        }
    }


    public int dropChallenge()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (!items[i].getIsSword())
            {
                if (items[i].drop())
                {
                    gameSystem.GameConfig.kakeraCounts[i] = items[i].getKCount();
                    StartCoroutine(PlayDropAnim(i));
                    return i;
                }
            }
        }
        return 9;
    }

    public void itemBoxControl()
    {
        foreach (Item item in items)
        {
            if (item.getIsSword()) item.dispSwordButton();
            else item.dispK();
        }
    }
    
    public Item activeSword()
    {
        foreach (Item item in items)
        {
            if(item.getIsActive())return item;
        }
        return items[0];
    }

    public void loadItem(int swordCount,bool[] activeSwords,int[] kakeraCounts)
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item(swords[i], buttons[i], 0.5);
        }
        setSwordCount(swordCount);
        for (int i = 0; i < activeSwords.Length; i++)
        {
            items[i].setIsActive(activeSwords[i]);
            items[i].setIsSword(activeSwords[i]);
            items[i].setKCount(kakeraCounts[i]);
        }
    }
    IEnumerator PlayDropAnim(int num)
    {
        Debug.Log("aaa");

        GameObject ins;
        ins = Instantiate(kakeras[num], kParent.transform);
        yield return new WaitForSeconds(1);
        Destroy(ins);
    }
    
}
