﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSword : MonoBehaviour
{
    public ItemSystem itemSystem;
    public GameObject ItemBoxPanel;
    private int swordNum;
    Item item;
    private void Start()
    {
        swordNum = int.Parse(this.name);
        item = itemSystem.getItem(swordNum);
    }
    public void OnClickSwordBotton()
    {
        itemSystem.activeSword().getSword().SetActive(false);
        item.setIsActive(true);
        item.getSword().SetActive(true);
        ItemBoxPanel.SetActive(false);
    }
}
