using System.Linq;
using System.Threading;
using UnityEngine;

public class PhoneCall : InteractiveItem
{
    public CatPlay[] cats;
    void Start()
    {
        highlight = GetComponent<Outline>();
    }

    public override void Use()
    {
        foreach (CatPlay cat in cats)
        {
            if (cat.catHurted)
            {
                cat.catHurted = false;
                GameManager.VetCall();
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && cats.Any(cat => cat.catHurted))
        {
            Focus();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && cats.Any(cat => cat.catHurted))
        {
            Focus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIRepairScript.Instance.Deselect();
        }
    }
}
