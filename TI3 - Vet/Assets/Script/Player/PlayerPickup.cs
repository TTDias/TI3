using System;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform pickup;
    public bool carrying { get; set; }
    public static event Action PickupBox;
    public static event Action PlaceBox;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Box" && !carrying)
        {
            obj.transform.parent = pickup;
            obj.transform.localPosition = Vector3.zero;
            carrying = true;
            PickupBox?.Invoke();
        }
        if (obj.tag == "BoxArea" && carrying)
        {
            carrying = false;
            Destroy(pickup.GetChild(0).gameObject);
            obj.GetComponent<BuildArea>().Build();
            PlaceBox?.Invoke();
        }
    }
}
