using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public GameObject[] swords;
    public GameObject[] buttons;
    public GameObject ItemBoxPanel;
    Item[] items = new Item[6];

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item(swords[i], buttons[i], 0.5);
        }
        items[0].setIsSword(true);
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
        foreach (Item item in items)
        {
            if (!item.getIsSword())
            {
                if (item.drop()) break;
            }
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
    
}
