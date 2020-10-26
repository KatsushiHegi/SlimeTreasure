using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    private int kCount;
    private double dropProb;
    private bool isSword,isActive;
    private GameObject sword, button;
    private GameObject swordButton;
    private GameObject[] k;
    private System.Random r = new System.Random();
    public Item(GameObject sword, GameObject button, double dropProb = 0.01)
    {
        kCount = 0;
        this.sword = sword;
        this.button = button;
        this.dropProb = dropProb;
        k = new GameObject[3];
        swordButton = button.transform.Find(button.name).gameObject;
        for (int i = 0; i < k.Length; i++)
        {
            k[i] = button.transform.Find("k" + i).gameObject;
        }
    }

    private void kCountup(int i = 1)
    {        this.kCount = kCount + i > 3 ? 3 : kCount + i;

    }

    public GameObject getSword() { return sword; }
    public GameObject getButton() { return button; }

    public int getKCount()
    {
        return kCount;
    }
    public void setKCount(int kCount)
    {
        this.kCount = kCount;
    }

    public bool getIsSword()
    {
        return isSword;
    }
    public void setIsSword(bool b)
    {
        this.isSword = b;
    }

    public bool getIsActive()
    {
        return isActive;
    }
    public void setIsActive(bool b)
    {
        this.isActive = b;
    }


    public bool drop()
    {
        if (r.NextDouble() < dropProb)
        {
            kCountup();
            //かけら
            Debug.Log(sword.name + "drop");
            return true;
        }
        return false;
    }

    public void dispSwordButton()
    {
        swordButton.SetActive(true);
    }

    public void dispK()
    {
        for (int i = 0; i < kCount; i++)
        {
            k[i].SetActive(true);
        }
        if (kCount == 3)
        {
            button.transform.Find("c").gameObject.SetActive(true);
        }
    }
    public void delK()
    {
        for (int i = 0; i < 3; i++)
        {
            k[i].SetActive(false);
        }
    }
}
