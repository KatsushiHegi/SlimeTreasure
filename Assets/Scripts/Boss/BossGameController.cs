using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameController : MonoBehaviour
{
    public GameObject FadeImage;
    void Start()
    {
        StartCoroutine(MainThered());
    }
    IEnumerator MainThered()
    {
        yield return FadeIn();
    }

    IEnumerator FadeIn()
    {
        FadeImage.GetComponent<Animator>().Play("Fade In");
        yield return new WaitForSeconds(1);
        FadeImage.SetActive(false);
    }
}
