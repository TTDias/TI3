using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeButtons : MonoBehaviour
{
    public Animator anim;
    public float delay = 1.5f;

    public void MainMenu()
    {
        StartCoroutine(ChangeScene("menuinicial"));
    }

    public void Checklist()
    {
        StartCoroutine(ChangeScene("checklist"));
    }

    public void Credits()
    {
        StartCoroutine(ChangeScene("Creditos"));
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        anim.SetTrigger("start");

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
