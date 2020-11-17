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


    public void dropChallenge()
    {
        if (swordCount < 6
            && UnityEngine.Random.value < 0.01f)//ドロップ率
        {
            int[] rAry = new int[6 - swordCount];
            int j = 0;
            for (int i = 0; i < 6; i++) //武器の種類数を回数とする
            {
                if (!gameSystem.GameConfig.sworded[i])
                {
                    rAry[j] = i;
                    j++;
                }
            }
            int dNum = rAry[UnityEngine.Random.Range(0, 6 - swordCount)];

            items[dNum].drop();
            gameSystem.GameConfig.kakeraCounts[dNum] = items[dNum].getKCount();
            StartCoroutine(PlayDropAnim(dNum));
        }
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

    public void loadItem(int swordCount,bool[] sworded,int[] kakeraCounts, int activeSwordNum)
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item(swords[i], buttons[i]);
        }
        setSwordCount(swordCount);
        for (int i = 0; i < sworded.Length; i++)
        {
            if (i == activeSwordNum)
            {
                items[i].setIsActive(true);
                swords[i].SetActive(true);
            }
            items[i].setIsSword(sworded[i]);
            items[i].setKCount(kakeraCounts[i]);
        }
    }
    IEnumerator PlayDropAnim(int num)
    {
        GameObject ins;
        ins = Instantiate(kakeras[num], kParent.transform);
        yield return new WaitForSeconds(1);
        Destroy(ins);
    }
    
}
