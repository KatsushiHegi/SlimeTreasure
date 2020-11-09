using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject fade;
    public void titlePanelClick()
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().Play("Fade Out");
        StartCoroutine("goToMain");
    }
    IEnumerator goToMain()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }
}
