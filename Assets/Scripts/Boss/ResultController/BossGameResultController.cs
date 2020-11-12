using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameResultController : MonoBehaviour
{
    [SerializeField] GameObject ResultObj;

    [SerializeField] Text TotalKillTextValue, TotalTimeTextValue;

    [SerializeField] Image TreasureImg;
    [SerializeField] Sprite[] TreImgs;

    public void SetResult(BossGameSystem bossGameSystem)
    {
        ResultObj.SetActive(true);
        TotalKillTextValue.text = bossGameSystem.GameConfig.killCount.ToString();
        TotalTimeTextValue.text = "00:00:00";
        //Treasure
        TreasureImg.sprite = TreImgs[bossGameSystem.FindTreasure()];
    }
}
