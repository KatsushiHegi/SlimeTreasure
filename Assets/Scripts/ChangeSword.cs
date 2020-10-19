using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSword : MonoBehaviour
{
    public GameObject ItemBoxPanel;
    public GameObject[] swords;
    public void OnClickSwordBotton()
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
}
