using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject dicas, sairPopup;
    public GameObject[] obj, slaider, pause;
    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "menuinicial")
        {
            t = 0;
            LeanTween.init();
            foreach (GameObject go in obj) 
            {
                LeanTween.scale(go, Vector3.zero, 0);
            }
            foreach (GameObject go in obj)
            {
                t += 0.5f;
                LeanTween.scale(go, new Vector3(1f, 1f, 1f), 0.5f).setDelay(t).setOnComplete(() =>
                {
                    if (go.name != "menu")
                    {
                        LeanTween.scale(go, new Vector3(1.05f, 1.05f, 1.05f), 0.4f).setLoopPingPong();
                    }
                });
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void botaojogar()
    {
        if (SceneManager.GetActiveScene().name == "menuinicial")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            botaoDespause();
        }
    }
    public void botaocreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void botaoOp�oes()
    {
        LeanTween.cancelAll();
        LeanTween.init();
        t = 0;
        foreach (GameObject G in obj)
        {
            if (G.name != "menu")
            {
                LeanTween.scale(G, new Vector3(0f, 0f, 0f), 0.5f).setDelay(t).setOnComplete(() =>
                {
                    t = 0;
                    foreach (GameObject g in obj)
                    {
                        if (g.name != "menu")
                        {
                            g.SetActive(false);
                        }
                    }
                    foreach (GameObject S in slaider)
                    {
                        S.gameObject.SetActive(true);
                    }
                    foreach (GameObject S in slaider)
                    {
                        LeanTween.scale(S, new Vector3(1f, 1f, 1f), 0.5f).setDelay(t).setIgnoreTimeScale(true);
                        t += 0.2f;
                    }
                }).setIgnoreTimeScale(true);

            }
        }

    }
    public void botaoVoltarMenu()
    {
        LeanTween.cancelAll();
        LeanTween.init();
        t = 0;
        foreach (GameObject S in slaider)
        {
            LeanTween.scale(S, new Vector3(0f, 0f, 0f), 0.5f).setDelay(t).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                //Debug.Log(t);
                foreach (GameObject S in slaider)
                {
                    S.gameObject.SetActive(false);
                }
                foreach (GameObject g in obj)
                {
                    if (g.name != "menu")
                    {
                        g.SetActive(true);
                    }
                }
                t = 0;
                foreach (GameObject G in obj)
                {
                    LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setDelay(t).setIgnoreTimeScale(true);
                    t += 0.5f;
                }
                foreach (GameObject G in obj)
                {
                    LeanTween.scale(G, new Vector3(1.1f, 1.1f, 1.1f), 0.5f).setIgnoreTimeScale(true).setOnComplete(() =>
                    {
                        if (G.name != "menu")
                        {
                            //t = 0;
                            LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setLoopPingPong().setIgnoreTimeScale(true);
                            //t += 10;
                        }
                    });
                }
            }).setIgnoreTimeScale(true);
        }
    }
    public void botaopause()
    {
        Time.timeScale = 0;
        LeanTween.scale(obj[0], new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            foreach (GameObject go in obj)
            {
                if (go.name != "menu")
                {
                    LeanTween.scale(go, new Vector3(1.1f, 1.1f, 1.1f), 0.5f).setIgnoreTimeScale(true).setLoopPingPong();
                }

            }
        }).setIgnoreTimeScale(true);
        LeanTween.scale(pause[0], new Vector3(0, 0, 0), 0.5f).setIgnoreTimeScale(true);
        LeanTween.scale(pause[1], new Vector3(1, 1, 1), 0.5f).setIgnoreTimeScale(true);
    }
    public void botaoDespause()
    {
        Time.timeScale = 1;
        LeanTween.scale(obj[0], new Vector3(0, 0, 0), 0.5f).setIgnoreTimeScale(true);
        LeanTween.scale(pause[0], new Vector3(1, 1, 1), 0.5f).setIgnoreTimeScale(true);
        LeanTween.scale(pause[1], new Vector3(0, 0, 0), 0.5f).setIgnoreTimeScale(true);
    }
    public void botaoSair()
    {
        if(SceneManager.GetActiveScene().name != "menuinicial")
        {
            SceneManager.LoadScene("menuinicial");
        }
        else
        {
            Application.Quit();
        }
    }

    public void MostrarDica(string msg = null)
    {
        LeanTween.alpha(dicas, 0, 0.0f);
        if (msg == null)
        {
            LeanTween.scaleY(dicas, 1.74f, 0.5f);
            //LeanTween.alpha(dicas, 1, 0.3f);
        }
    public void botaovoutarmenooutros()
    {

    }
}