using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject[] obj, slaider;
    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject G in obj)
        {
            G.LeanScale(Vector3.zero, 0f);
        }
        LeanTween.init();
        foreach (GameObject G in obj)
        {
            LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setDelay(t);
            t += 0.5f;
        }
        foreach (GameObject G in obj)
        {
            LeanTween.scale(G, new Vector3(1.1f, 1.1f, 1.1f), 0.5f).setOnComplete(() =>
            {
                if (G.name != "menu")
                {
                    //t = 0;
                    LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setLoopPingPong();
                    //t += 10;
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void botaojogar()
    {
        SceneManager.LoadScene("TestMechanics");
    }
    public void botaocreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void botaoOpçoes()
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
                        LeanTween.scale(S, new Vector3(1f, 1f, 1f), 0.5f).setDelay(t);
                        t += 0.2f;
                    }
                });
                
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
            LeanTween.scale(S, new Vector3(0f, 0f, 0f), 0.5f).setDelay(t).setOnComplete(() =>
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
                    LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setDelay(t);
                    t += 0.5f;
                }
                foreach (GameObject G in obj)
                {
                    LeanTween.scale(G, new Vector3(1.1f, 1.1f, 1.1f), 0.5f).setOnComplete(() =>
                    {
                        if (G.name != "menu")
                        {
                            //t = 0;
                            LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setLoopPingPong();
                            //t += 10;
                        }
                    });
                }
            });
        }
    }
}