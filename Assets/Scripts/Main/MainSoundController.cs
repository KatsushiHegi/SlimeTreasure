using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundController : MonoBehaviour
{
    [SerializeField] AudioSource BGM;

    public void MainBgmFadeIn()
    {
        StartCoroutine(FadeIn(BGM));
    }
    public void MainBgmFadeOut()
    {
        StartCoroutine(FadeOut(BGM));
    }
    IEnumerator FadeIn(AudioSource audio, float second = 1)
    {
        float maxVol = audio.volume;
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
            audio.volume = maxVol - maxVol * (i / maxFlame);
            yield return null;
        }
    }
}
