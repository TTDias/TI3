using UnityEngine;
using UnityEngine.UI;

public class UIRepairScript : MonoBehaviour
{
    public static UIRepairScript Instance;
    public static Button btn;
    CatItens obj;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        btn.interactable = false;
    }

    public void Select(CatItens item)
    {
        if(obj != null)
        {
            Deselect();
        }
        btn.interactable = true;
        obj = item;
        btn.onClick.AddListener(obj.Repair);
        btn.onClick.AddListener( () => { btn.interactable = false; });
    }

    public void Deselect()
    {
        //if(btn.onClick.GetPersistentEventCount() > 0)
        //    btn.onClick.RemoveAllListeners();
        obj.Unfocus();
        btn.interactable = false;
    }

    public void TestEvent()
    {
        Debug.Log("Mensagem");
    }
}
