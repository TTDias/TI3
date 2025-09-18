using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public GameObject area;
    public GameObject obj;

    private void OnEnable()
    {
        PlayerPickup.PickupBox += AreaHighlight;
        PlayerPickup.PlaceBox += AreaDesable;
    }
    private void OnDisable()
    {
        PlayerPickup.PickupBox -= AreaHighlight;
        PlayerPickup.PlaceBox -= AreaDesable;
    }

    void Start()
    {
        area.SetActive(false);
        obj.SetActive(false);
    }

    void AreaHighlight()
    {
        area.SetActive(true);
    }

    void AreaDesable()
    {
        area.SetActive(false);
    }

    public void Build()
    {
        obj.SetActive(true);
        area.SetActive(false);
        PlayerPickup.PickupBox -= AreaHighlight;
        PlayerPickup.PickupBox -= AreaHighlight;
    }
}
