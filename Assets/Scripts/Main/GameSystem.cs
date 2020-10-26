using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy_parent;
    public GameObject TextCountObj,ItemBoxPanel,Fade;
    ItemSystem itemSystem;
    private int killCount;
    public int getKillCount() { return this.killCount; }
    public void setKillCount(int killCount)
    {
        this.killCount = killCount;
    //    this.dispKillCount();
    }
    public void incKillCount(int inc)
    {
        this.killCount += inc;
    //    dispKillCount();
    }


    float x, z;
    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSに設定
    }
    void Start()
    {

        StartCoroutine(MainThered());
        
    }
    private void Update()
    {
        Text TextCounter = TextCountObj.GetComponent<Text>();
        TextCounter.text = "討伐数：" + killCount;
    }

    public void OnClickItemBoxBotton()
    {
        ItemBoxPanel.SetActive(true);
        itemSystem.itemBoxControl();
    }

    IEnumerator fadeIn()
    {
        Fade.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1f);
        Fade.SetActive(false);
    }
    IEnumerator MainThered()
    {
        yield return fadeIn();
        
        for (int i = 0; i < 20; i++)
        {
            x = Random.value * 100 - 50;
            z = Random.value * 100 - 50;
            Instantiate(Enemy, new Vector3(x, 0, z), Quaternion.identity).transform.parent = Enemy_parent.transform;
        }
        killCount = 0;

        itemSystem = this.GetComponent<ItemSystem>();
    }

}
