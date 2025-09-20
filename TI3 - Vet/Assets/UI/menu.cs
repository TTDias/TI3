using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class menu : MonoBehaviour
{
    Button config, voutar;
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
}
