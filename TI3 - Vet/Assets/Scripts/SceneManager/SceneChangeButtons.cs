using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButtons : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("menuinicial");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}