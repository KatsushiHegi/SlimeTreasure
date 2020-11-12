using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundController : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] GameObject CreateSe;
    [SerializeField] GameObject[] EffectSounds;
    public void MainBgmFadeIn()
    {
        StartCoroutine(FadeIn(BGM));
    }
    public void MainBgmFadeOut()
    {
        StartCoroutine(FadeOut(BGM));
    }
    public void PlayCreateSe()
    {
        StartCoroutine(InsDel(CreateSe, 1));
    }
    public void PlayEffectSound(int num)
    {
        StartCoroutine(InsDel(EffectSounds[num], 1.5f));
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
    IEnumerator InsDel(GameObject obj ,float time)
    {
        GameObject g = Instantiate(obj);
        yield return new WaitForSeconds(time);
        Destroy(g);
    }
}
