using UnityEngine;
using UnityEngine.UI;

public class UIRepairScript : MonoBehaviour
{
    public static UIRepairScript Instance;
    public Button btn;
    public Image loadBar;
    CatItens obj;
    public bool reparing = false;

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
        btn.onClick.AddListener( ButtonLoad );
    }

    public void Deselect()
    {
        //if (btn.onClick.GetPersistentEventCount() > 0)
            btn.onClick.RemoveAllListeners();
        obj.Unfocus();
        btn.interactable = false;
    }

    public void TestEvent()
    {
        Debug.Log("Mensagem");
    }

    void ButtonLoad()
    {
        reparing = true;
        loadBar.gameObject.SetActive(true);
        LeanTween.value(gameObject, 0, 1, 3)
            .setOnUpdate((float val) => { loadBar.fillAmount = val; })
            .setOnComplete(() => {
                reparing = false;
                LeanTween.delayedCall(gameObject, 0.65f, () => { 
                    loadBar.gameObject.SetActive(false); 
                    btn.interactable = false; 
                }); 
            });
    }
}
