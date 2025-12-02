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
            BoxPickup(obj);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BoxArea" )
        {
            BuildArea area = other.GetComponent<BuildArea>();
            if (carrying && !area.obj.activeSelf && area.boxConstruct == null)
            {
                BoxPlace(area);
                ConstructRange(area);
            }
            else if (area.boxConstruct != null)
            {
                ConstructRange(area);
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
                BuildButton.Instance.Deselect();
            }
        }
    }

    void BoxPickup(GameObject obj)
    {
        obj.transform.parent = pickup;
        obj.transform.localPosition = Vector3.zero;
        carrying = true;
        GetComponent<PlayerMove>().anima.SetLayerWeight(1, 1);
        PlayerSoundMannager.Instance.PlayPop();
        PickupBox?.Invoke();
    }

    void BoxPlace(BuildArea area)
    {
        carrying = false;
        PlayerSoundMannager.Instance.PlayPop();
        PlaceBox?.Invoke();
        area.BuildStart(pickup.GetChild(0).gameObject);
        GetComponent<PlayerMove>().anima.SetLayerWeight(1, 0);
    }

    void ConstructRange(BuildArea area)
    {
        BuildButton.Instance.useButton.gameObject.SetActive(true);
        BuildButton.Instance.useButton.onClick.AddListener(() =>
        {
            BuildButton.Instance.InitBuild(area);
        });
    }

    public static void DisableActions()
    {
        PickupBox = null;
        PlaceBox = null;
    }
}
