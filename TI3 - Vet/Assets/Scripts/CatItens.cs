using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatItens : InteractiveItem
{
    public enum Item { food, post, toy, litterbox }
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

        repairSum++;
        AnalyticsTest.Instance.AddAnalytics("Cat Item: " + type.ToString(), "Repairs", repairSum.ToString());
    }

    public bool IsItemType(Item type)
    {
        return type == this.type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && broken)
        {
            Focus();
        }
        else if(other.tag == "Cat" && !broken)
        {
            if (UIRepairScript.Instance.reparing)
            {
                LeanTween.delayedCall(3f, () => {
                    Broke(); other.GetComponent<Animation>().Play("CatItemUse");
                    LeanTween.delayedCall(1.5f, other.GetComponent<CatPlay>().Sleep);
                });
            }
            else
            {
                other.GetComponent<Animation>().Play("CatItemUse");
                Broke();
                LeanTween.delayedCall(1.5f, other.GetComponent<CatPlay>().Sleep);
            }
        }
        else if (other.tag == "Cat" && broken)
        {
            other.GetComponent<CatPlay>().Call();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cat" && !broken && UIRepairScript.Instance.reparing && trigger)
        {
            trigger = false;
            other.GetComponent<CatPlay>().Cancel();
            LeanTween.delayedCall(3f, () => {
                trigger = true; Broke(); other.GetComponent<Animation>().Play("CatItemUse");
                LeanTween.delayedCall(1.5f, other.GetComponent<CatPlay>().Sleep);
            });
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            UIRepairScript.Instance.Deselect();
        }
    }


}
