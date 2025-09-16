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
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
}
