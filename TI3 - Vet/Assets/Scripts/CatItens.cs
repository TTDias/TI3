using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatItens : InteractiveItem
{
    private CatSoundMannager catSound;
    public enum Item { water, post, toy, litterbox }
    [SerializeField] Item type;

    public bool broken {get;set;}

    bool trigger = true;

    public GameObject broked, repaired;

    static int repairSum;
    void Start()
    {
        broken = true;
        repairSum = 0;
        highlight = GetComponent<Outline>();
        catSound = FindObjectOfType<CatSoundMannager>();
    }

    public void Broke()
    {
        LeanTween.delayedCall(1.5f, () => { broked.SetActive(true); repaired.SetActive(false); broken = true; });
       
    }

    public override void Use()
    {
        broked.SetActive(false);
        repaired.SetActive(true);
        broken = false;
        GameManager.RepairScoreUp();

        repairSum++;
        AnalyticsTest.Instance.AddAnalytics(type.ToString(), "Repaired Itens", repairSum.ToString());
    }

    public bool IsItemType(Item type)
    {
        return type == this.type;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && broken)
        {
            Focus();
        }
        else if(other.tag == "Cat" && !broken)
        {
            if (type == Item.water)
                catSound.PlayEat();

            if (UIRepairScript.Instance.reparing)
            {
                LeanTween.delayedCall(3f, () => {
                    other.GetComponent<CatPlay>().Play(this);
                });
            }
            else
            {
                other.GetComponent<CatPlay>().Play(this);
            }
        }
        else if (other.tag == "Cat" && broken)
        {
            other.GetComponent<CatPlay>().Call();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && broken)
        {
            Focus();
        }
        if (other.tag == "Cat" && !broken && !other.GetComponent<CatMove>().running)
        {
            if (UIRepairScript.Instance.reparing && trigger)
            {
                trigger = false;
                other.GetComponent<CatPlay>().Cancel();
                LeanTween.delayedCall(3f, () => {
                    trigger = true;
                    other.GetComponent<CatPlay>().Play(this);
                });
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            UIRepairScript.Instance.Deselect();
            Unfocus();
        }
    }

    
}
