using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatItens : MonoBehaviour
{
    public enum Item { food, post, toy, litterbox }
    [SerializeField] Item type;

    public bool broken {get;set;}

    public MeshRenderer mesh;
    public Material broked, repaired, highlight;
    void Start()
    {
        broken = true;
    }

    public void Broke()
    {
        mesh.material = broked;
        broken = true;
    }

    public void Repair()
    {
        mesh.material = repaired;
        broken = false;
    }

    public bool IsItemType(Item type)
    {
        return type == this.type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
        mesh.material = highlight;
    }

    public void Unfocus()
    {
        mesh.material = broken ? broked : repaired;
    }

}
