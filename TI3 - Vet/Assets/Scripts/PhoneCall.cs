using System.Linq;
using System.Threading;
using UnityEngine;

public class PhoneCall : InteractiveItem
{
    public CatPlay[] cats;
    int vetcall = 0;
    void Start()
    {
        highlight = GetComponent<Outline>();
        vetcall = 0;
    }

    public override void Use()
    {
        foreach (CatPlay cat in cats)
        {
            if (cat.catHurted)
            {
                cat.catHurted = false;
                vetcall++;
                GameManager.VetCall();
                AnalyticsTest.Instance.AddAnalytics("Phone", "Vet called", vetcall.ToString());
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
            BuildButton.Instance.Deselect();
        }
    }
}
