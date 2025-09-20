using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menu : MonoBehaviour
{
    Button config, voutar, creditos, jogar;
    VisualElement painelconfig, painelmenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument ui = GetComponent<UIDocument>();
        var root = ui.rootVisualElement;
        config = root.Q<Button>("configuracao");
        config.clicked += ConfigOnclick;
        painelconfig = root.Q<VisualElement>("config");
        painelmenu = root.Q<VisualElement>("menu");
        voutar = root.Q<Button>("voltar");
        voutar.clicked += voutarOnclick;
        creditos = root.Q<Button>("creditos");
        creditos.clicked += CreditosOnclick;
        jogar = root.Q<Button>("jogar");
        jogar.clicked += JogarOnclick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ConfigOnclick()
    {
        painelmenu.style.display = DisplayStyle.None;
        painelconfig.style.display = DisplayStyle.Flex;
    }
    void voutarOnclick()
    {
        painelmenu.style.display = DisplayStyle.Flex;
        painelconfig.style.display = DisplayStyle.None;
    }
    void CreditosOnclick()
    {
        SceneManager.LoadScene("Creditos");
    }
    void JogarOnclick()
    {
        SceneManager.LoadScene("TesteScenario");
    }
}
