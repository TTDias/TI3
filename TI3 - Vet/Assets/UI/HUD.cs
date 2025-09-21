using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    float T = 0;
    Button pause, config, voltar, menu, fase, despausar;
    VisualElement configpause, menupause;
    ProgressBar Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        UIDocument ui = GetComponent<UIDocument>();
        var root = ui.rootVisualElement;
        pause = root.Q<Button>("pause");
        pause.clicked += PauseOnclick;
        menupause = root.Q<VisualElement>("menupause");
        configpause = root.Q<VisualElement>("Configpause");
        config = root.Q<Button>("config");
        config.clicked += configOnclick;
        voltar = root.Q<Button>("voltar");
        voltar.clicked += VoltarOnclick;
        Timer = root.Q<ProgressBar>("relogio");
        menu = root.Q<Button>("menuinicial");
        menu.clicked += MenuOnclick;
        fase = root.Q<Button>("faseteste");
        fase.clicked += FaseOnclick;
        despausar = root.Q<Button>("despausar");
        despausar.clicked += DespausarOnclick;
    }

    // Update is called once per frame
    void Update()
    {
        T += Time.deltaTime;
        //Debug.Log(T);
        Timer.value = T;
    }
    void PauseOnclick()
    {
        menupause.style.display = DisplayStyle.Flex;
        Time.timeScale = 0;
    }
    void configOnclick()
    {
        menupause.style.display = DisplayStyle.None;
        configpause.style.display = DisplayStyle.Flex;
    }
    void VoltarOnclick()
    {
        menupause.style.display = DisplayStyle.Flex;
        configpause.style.display = DisplayStyle.None;
    }
    void DespausarOnclick()
    {
        menupause.style.display = DisplayStyle.None;
        configpause.style.display = DisplayStyle.None;
        Time.timeScale = 1;
    }
    void MenuOnclick()
    {
        SceneManager.LoadScene("menuinicial");
    }
    void FaseOnclick()
    {
        SceneManager.LoadScene("TestMechanics com HUD");
    }
}
