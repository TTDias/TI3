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
            PlayerSoundMannager.Instance.PlayPop();
            PickupBox?.Invoke();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BoxArea" )
        {
            BuildArea area = other.GetComponent<BuildArea>();
            if (carrying && !area.obj.activeSelf && area.boxConstruct == null)
            {
                carrying = false;
                PlayerSoundMannager.Instance.PlayPop();
                PlaceBox?.Invoke();
                area.BuildStart(pickup.GetChild(0).gameObject);
            }
            else if (area.boxConstruct != null)
            {
                area.BuildAnim();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BoxArea")
        {
            BuildArea area = other.GetComponent<BuildArea>();
            if (area.boxConstruct != null)
            {
                area.BuildStop();
            }
        }
    }

    public static void DisableActions()
    {
        PickupBox = null;
        PlaceBox = null;
    }
}
