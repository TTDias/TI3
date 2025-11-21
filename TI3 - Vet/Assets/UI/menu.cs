using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject dicas, sairPopup, canvasdicatxt;
    public Image imageF;
    public Text txtajuda;
    public GameObject[] obj, slaider, pause;
    float t = 0;

    static int plays = 0;
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
                    if (go.name != "menu" && go.name != "ajudatexto")
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
            plays++;
            AnalyticsTest.Instance.AddAnalytics("Game", "Plays", plays.ToString());
            SceneManager.LoadScene("SampleScene");
            GameManager.GameStart();
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
    public void botaoOpcoes()
    {
        LeanTween.cancelAll();
        LeanTween.init();
        t = 0;
        foreach (GameObject G in obj)
        {
            if (G.name != "menu" && G.name != "ajudatexto")
            {
                LeanTween.scale(G, new Vector3(0f, 0f, 0f), 0.5f).setDelay(t).setOnComplete(() =>
                {
                    t = 0;
                    foreach (GameObject g in obj)
                    {
                        if (g.name != "menu" && g.name != "ajudatexto" && g.name != "menu dicas")
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
                    if (g.name != "menu" && g.name != "ajudatexto" && g.name != "menu dicas")
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
                        if (G.name != "menu" && G.name != "ajudatexto")
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
        imageF.enabled = true;
        Time.timeScale = 0;
        LeanTween.scale(obj[0], new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            foreach (GameObject go in obj)
            {
                if (go.name != "menu" && go.name != "ajudatexto")
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
        imageF.enabled = false;
        LeanTween.scale(obj[0], new Vector3(0, 0, 0), 0.5f).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            foreach (GameObject S in slaider)
            {
                S.gameObject.SetActive(false);
            }
            foreach (GameObject g in obj)
            {
                if (g.name != "menu")
                {
                    g.SetActive(true);
                    g.transform.localScale = Vector3.one;
                }
            }
        });
        LeanTween.scale(pause[0], new Vector3(1, 1, 1), 0.5f).setIgnoreTimeScale(true);
        LeanTween.scale(pause[1], new Vector3(0, 0, 0), 0.5f).setIgnoreTimeScale(true);
    }
    public void botaoSair()
    {
        if(SceneManager.GetActiveScene().name != "menuinicial")
        {
            AnalyticsTest.Instance.Save();
            SceneManager.LoadScene("menuinicial");
        }
        else
        {
            Application.Quit();
        }
    }

    public void MostrarDica(string msg = null)
    {
        if (msg == null)
        {
            LeanTween.scaleY(dicas, 1.74f, 0.5f);
            LeanTween.delayedCall(7f, () => { LeanTween.scaleY(dicas, 0, 0.5f); });
            
        }
    }
    public void botaovoutarmenuajuda()
    {
        foreach (GameObject G in obj)
        {

            if (G.name == "voltarMenu (ajuda)" || G.name == "dica" || G.name == "dica (1)" || G.name == "dica (2)" || G.name == "dica (3)" || G.name == "menu dicas")
            {
                G.SetActive(false);
            }
            else
            {
                G.SetActive(true);
            }
            canvasdicatxt.SetActive(false);
        }
    }
    public void botaoajuda()
    {
        foreach (GameObject G in obj)
        {

            if (G.name == "menu" || G.name == "voltarMenu (ajuda)" || G.name == "dica" || G.name == "dica (1)" || G.name == "dica (2)" || G.name == "dica (3)" || G.name == "menu dicas")
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
            canvasdicatxt.SetActive(true);
        }
    }
    public void botaotextoadica()
    {
            txtajuda.text = "voce pode se movimentar mantendo o dedo precionado na tela e consertar os brinquedos do gato com o butao 'consertar' no canto da tela.";
    }
    public void botaotextoadica1()
    {
        txtajuda.text = "O gato vai querer usar seus brinquedos para se manter bem e e o seu papeu consertar esses item para mantelo seguro e bem dentro de casa, evitando a comtaminaçao da sporotricoze";
    }
    public void botaotextoadica2()
    {
        txtajuda.text = "Apesar de tudo vc deve arrumar sua prapria casa, pois esta em plena mudansa.";
    }
    public void botaotextoadica3()
    {
        txtajuda.text = "A fase posue um taimer que mostrar o tempo que voce tem para comcluir suas atividades alem de uma breve dica de o que o gato pode estar precisando mostrado bela barra verde.";
    }
}