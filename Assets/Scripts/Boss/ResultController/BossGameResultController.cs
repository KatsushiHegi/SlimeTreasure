using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameResultController : MonoBehaviour
{
    [SerializeField] GameObject ResultObj;

    [SerializeField] Text TotalKillTextValue, TotalClearCountValue;

    [SerializeField] Image TreasureImg;
    [SerializeField] Sprite[] TreImgs;

    public void SetResult(BossGameSystem bossGameSystem)
    {
        ResultObj.SetActive(true);
        TotalClearCountValue.text = bossGameSystem.GameConfig.clearCount.ToString();
        TotalKillTextValue.text = bossGameSystem.GameConfig.killCount.ToString();

        int num = bossGameSystem.FindTreasure();
        if (num != 9)
        {
            TreasureImg.gameObject.SetActive(true);
            TreasureImg.sprite = TreImgs[num];
        }
    }
}
