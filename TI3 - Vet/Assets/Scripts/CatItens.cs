using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatItens : MonoBehaviour
{
    public enum Item { food, post, toy, litterbox }
    [SerializeField] Item type;

    public bool broken {get;set;}

    Outline highlight;
    public GameObject broked, repaired;
    void Start()
    {
        highlight = GetComponent<Outline>();
        broken = true;
    }

    public void Broke()
    {
        broked.SetActive(true);
        repaired.SetActive(false);
        broken = true;
    }

    public void Repair()
    {
        broked.SetActive(false);
        repaired.SetActive(true);
        broken = false;
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
            broken = true;
            Broke();
            other.GetComponent<CatPlay>().Sleep();
        }
        else if (other.tag == "Cat" && broken)
        {
            other.GetComponent<CatPlay>().Call();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cat" && !broken)
        {
            broken = true;
            Broke();
            other.GetComponent<CatPlay>().Cancel();
            other.GetComponent<CatPlay>().Sleep();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            UIRepairScript.Instance.Deselect();
        }
    }

    public void Focus()
    {
        UIRepairScript.Instance.Select(this);
        highlight.OutlineColor = Color.white;
    }

    public void Unfocus()
    {
        highlight.OutlineColor = Color.black;
        //if (broken) { broked.SetActive(true); repaired.SetActive(false); }
        //else { broked.SetActive(false); repaired.SetActive(true); }
    }

}
