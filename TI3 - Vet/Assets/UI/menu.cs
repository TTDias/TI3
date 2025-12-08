using System;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject dicas, sairPopup, canvasdicatxt, tutorialfala, avatarvelho, avatarveterinario;
    public Image imageF;
    public Text txtajuda, txtajudaJogo, falas;
    public GameObject[] obj, slaider, pause, mudanças, imagansFala;
    float t = 0;
    int contafalas = 0;
    static int plays = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        contafalas = 0;
        if (SceneManager.GetActiveScene().name == "menuinicial")
        {
            t = 0;
            LeanTween.cancelAll();
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
        //Debug.Log(GameManager.Statustutorial());
        if (GameManager.Statustutorial())
        {
            
            //GameManager.Mudartutorial(true);
            //Debug.Log(GameManager.StatusPhone());
            if (contafalas == 0 && GameManager.StatusPhone())
            {
                avatarvelho.transform.localScale = Vector3.zero;
                avatarveterinario.transform.localScale = Vector3.one;
                LeanTween.init();
                LeanTween.scale(tutorialfala, new Vector3(1, 1, 1), 0.5f).setOnComplete(() => { falas.text = "Olá! Sou eu, seu veterinário. Descobri que você se mudou, espero que esteja gostando da casa nova."; });

            }
            else if (contafalas == 1)
            {
                LeanTween.cancel(tutorialfala);
                falas.text = "Estou te ligando porque percebi que a região onde está tendo alguns casos de esporotricose. Cuide bem do seu gato para que ele não se contamine.";

            }
            else if (contafalas == 2)
            {
                falas.text = "Lembre-se de sempre trocar sua água e limpar a caixinha de areia, se não ele pode sair de casa para atender as necessidades na rua. E tenha brinquedinhos para ele, para fazê-lo gastar energia";

            }
            else if (contafalas == 3)
            {
                falas.text = "Coloque telas de proteção na janela de sua casa, para que ele não fuja. Tome cuidado, pois se ele fugir, pode brigar com outros gatos e contrair a doença.";

            }
            else if (contafalas == 4)
            {
                falas.text = "Se ele voltar machucado de casa, nao deixe de me ligar, basta usar este telefone. Até mais. \n*Click* ";
            }
            else if (contafalas == 5)
            {
                LeanTween.scale(avatarveterinario, Vector3.zero, 0.5f).setOnComplete(() =>
                {
                    falas.text = "trrrrim-trrrim\n*Click*";
                });

            }
            else if (contafalas == 6)
            {
                avatarveterinario.transform.localScale = Vector3.zero;
                imagansFala[0].transform.localScale = Vector3.one;
                LeanTween.scale(avatarvelho, Vector3.one, 0.5f).setOnComplete(() => { falas.text = "Oi minha criança, como você está?";});
            }
            else if (contafalas == 7)
            {
                avatarvelho.transform.localScale = Vector3.one;

                LeanTween.scale(imagansFala[0], Vector3.zero, 0.2f);
                LeanTween.scale(imagansFala[1], Vector3.one, 0.2f);
                falas.text = "As últimas caixas da sua mudança devem estar chegando, fique atento com a buzina do caminhão.";
            }
            else if(contafalas == 8)
            {
                LeanTween.cancel(imagansFala[1]);
                LeanTween.scale(imagansFala[1], Vector3.zero, 0.2f);
                LeanTween.scale(imagansFala[2], Vector3.one, 0.2f);
                falas.text = "Fiquei sabendo que um vizinho tem um gato doente e conversei com seu veterinário. Comprei umas telas para você botar nas janelas da sua casa que devem chegar com as caixas da mudança";
            }
            else if (contafalas == 9)
            {
                LeanTween.cancel(imagansFala[2]);
                LeanTween.scale(imagansFala[2], Vector3.zero, 0.2f);
                LeanTween.scale(imagansFala[3], Vector3.one, 0.2f);
                falas.text = "Não se esqueça de construir elas, e lemnre de cuidar do seu gato. Ele é bem chatinho, se escutar ele miando você sabe que ele quer alguma coisa. \nTchau tchau!";
            }
            else if (contafalas > 9)
            {
                LeanTween.scale(tutorialfala, Vector3.zero, 0.5f);
                GameManager.Mudartutorial(false);
                GameManager.MudarPhone(false);
            }
        }
    }
    public void botaojogar(bool tutorial = true)
    {
        if (SceneManager.GetActiveScene().name == "menuinicial")
        {
            plays++;
            AnalyticsTest.Instance.AddAnalytics("Game", "Plays", plays.ToString());
            GameManager.GameStart();
            GameManager.Mudartutorial(tutorial);
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
        txtajudaJogo.text = msg;
        LeanTween.scaleY(dicas, 1.74f, 0.5f);
        LeanTween.delayedCall(12f, () => { LeanTween.scaleY(dicas, 0, 0.5f); });
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
            txtajuda.text = "Você pode se movimentar mantendo o dedo precionado na tela e consertar os brinquedos do gato com o botão 'consertar' no canto da tela.";
    }
    public void botaotextoadica1()
    {
        txtajuda.text = "O gato vai querer brincar, beber água e usar caixinha de areia e o seu papel é consertar esses item para mantê-lo seguro. Se as necessidades do gato não forem supridas, ele pode fugir de casa e se contaminar com a esporotricose, principlamente brigando com gatos contaminados";
    }
    public void botaotextoadica2()
    {
        txtajuda.text = "Você está de mudança, construa os itens necessarios na sua casa para você, como sua cama, e também para o seu gato, como as telas de proteção nas janelas, para evitar que ele fuja e possa se expor à contaminação da esporotricose.";
    }
    public void botaotextoadica3()
    {
        txtajuda.text = "A jogo possui um relógio que mostrar o tempo que você tem até o fim da fase. Crie um ambiente confortável e seguro para seu gato, para que ele não saia de casa e não fique doente.";
    }
    public void botaotextoadica4()
    {
        txtajuda.text = "A esporotricose é uma doença que seu gato pode pegar ao se contaminar com os esporos de um fungo. Ela se caracteriza por diversos sintomas, como feridas pelo corpo do gato. Tome cuidado, pois a doença também pode contaminar humanos. Se perceber os sintomas, evite o contato com seu gato e comunique seu veterinário.";
    }
    public void botaopasarfala()
    {
        contafalas += 1;
    }
}