using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundController : MonoBehaviour
{
    [SerializeField] AudioSource TitleBGM;
    [SerializeField] GameObject Shakin;
    public void FadeOutTitleBGM()
    {
        StartCoroutine(FadeOut(TitleBGM));
    }

    public void PlayShakin()
    {
        Shakin.SetActive(true);
    }

    IEnumerator FadeIn(AudioSource audio, float maxVol = 1, float second = 1)
    {
        float maxFlame = second * 60;
        for (int i = 0; i < maxFlame; i++)
        {
            audio.volume = maxVol * (i / maxFlame);
            yield return null;
        }
    }
    IEnumerator FadeOut(AudioSource audio, float second = 1)
    {
        float maxVol = audio.volume;
        float maxFlame = second * 60;
        for (int i = 0; i < maxFlame; i++)
        {
            audio.volume = maxVol - maxVol*(i / maxFlame);
            yield return null;
        }
    }

}
