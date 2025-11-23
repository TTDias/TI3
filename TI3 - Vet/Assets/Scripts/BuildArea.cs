using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public GameObject area;
    public GameObject obj;

    public GameObject boxConstruct;

    static int totalBuild = 0;
    private void OnEnable()
    {
        PlayerPickup.PickupBox += AreaHighlight;
        PlayerPickup.PlaceBox += AreaDisable;
    }
    private void OnDisable()
    {
        PlayerPickup.PickupBox -= AreaHighlight;
        PlayerPickup.PlaceBox -= AreaDisable;
    }

    void Start()
    {
        area.SetActive(false);
        obj.SetActive(false);
        totalBuild = 0;
    }

    void AreaHighlight()
    {
        area.SetActive(true);
    }

    void AreaDisable()
    {
        area.SetActive(false);
    }

    public void BuildStart(GameObject box)
    {
        box.transform.parent = transform;
        box.transform.localPosition = Vector3.zero;
        box.tag = "Untagged";
        boxConstruct = box;
        BuildAnim();
    }

    public void BuildStop()
    {
        LeanTween.init();
        LeanTween.cancel(boxConstruct);
    }

    public void BuildAnim()
    {
        LeanTween.init();
        LeanTween.scale(boxConstruct, Vector3.one * 100, 0);
        LeanTween.scale(boxConstruct, Vector3.one * 70f, 0.3f).setLoopPingPong(6).setOnComplete(Build);
    }

    void Build()
    {
        obj.SetActive(true);
        area.SetActive(false);
        Destroy(boxConstruct);
        PlayerPickup.PickupBox -= AreaHighlight;
        GameManager.BoxPlacementScoreUp();

        totalBuild++;
        AnalyticsTest.Instance.AddAnalytics(obj.name, "Builded Furnitures", totalBuild.ToString());
    }
}
