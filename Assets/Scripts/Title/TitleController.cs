using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject fade;

    public TitleSoundController SoundController;

    TitleSystem titleSystem;
    void Start()
    {
        titleSystem = new TitleSystem();
    }

    public void titlePanelClick()
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().SetTrigger("fadeOut");
        SoundController.FadeOutTitleBGM();
        SoundController.PlayShakin();
        StartCoroutine("goToMain");
    }
    IEnumerator goToMain()
    {
        yield return new WaitForSeconds(1);
        if (titleSystem.GameConfig.nowPlace == 0) SceneManager.LoadScene("Main");
        else SceneManager.LoadScene("Boss");
    }
}
