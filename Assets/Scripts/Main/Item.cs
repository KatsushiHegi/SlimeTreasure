using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    private int kCount;
    private bool isSword,isActive;
    private GameObject sword, button;
    private GameObject swordButton;
    private GameObject[] k;
    public Item(GameObject sword, GameObject button)
    {
        kCount = 0;
        this.sword = sword;
        this.button = button;
        k = new GameObject[3];
        swordButton = button.transform.Find(button.name).gameObject;
        for (int i = 0; i < k.Length; i++)
        {
            k[i] = button.transform.Find("k" + i).gameObject;
        }
    }

    private void kCountup(int i = 1)
    {
        this.kCount = kCount + i > 3 ? 3 : kCount + i;

    }

    public GameObject getSword() { return sword; }
    public GameObject getButton() { return button; }

    public int getKCount() { return kCount; }
    public void setKCount(int kCount) { this.kCount = kCount; }

    public bool getIsSword() { return isSword; }
    public void setIsSword(bool b) { this.isSword = b; }

    public bool getIsActive() { return isActive; }
    public void setIsActive(bool b) { this.isActive = b; }


    public void drop()
    {
        kCountup();
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
