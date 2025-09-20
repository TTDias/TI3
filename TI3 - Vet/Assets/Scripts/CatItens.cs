using UnityEngine;

public class CatItens : MonoBehaviour
{
    public enum Item { food, post, toy, litterbox }
    [SerializeField] Item type;

    public bool broken {get;set;}
    public GameObject icon;

    void Start()
    {
        broken = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsItemType(Item type)
    {
        return type == this.type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            icon.SetActive(true);
        }
        else if(other.tag == "Cat" && !broken)
        {
            broken = true;
            icon.GetComponent<TesteClique>().Broke();
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
            icon.GetComponent<TesteClique>().Broke();
            other.GetComponent<CatPlay>().Cancel();
            other.GetComponent<CatPlay>().Sleep();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
}
