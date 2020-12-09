using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameSoundController : MonoBehaviour
{
    [SerializeField] AudioSource BossBGM, ResultBGM;

    public void BossBgmFadeIn()
    {
        StartCoroutine(FadeIn(BossBGM));
    }
    public void BossBgmFadeOut()
    {
        StartCoroutine(FadeOut(BossBGM));
    }
    public void ResultBgmFadeIn()
    {
        ResultBGM = Instantiate(ResultBGM);
        StartCoroutine(FadeIn(ResultBGM));
    }
    public void ResultBgmFadeOut()
    {
        StartCoroutine(FadeOut(ResultBGM));
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
        Destroy(audio);
    }
}
