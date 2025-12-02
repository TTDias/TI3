using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    public Image clock;
    public Button useButton;
    public PlayerMove player;

    public static BuildButton Instance;

    float time, maxtime;
    public bool reparing = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        clock.enabled = false;
        useButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        

        if(time > 0 && reparing)
        {
            time -= Time.deltaTime;
            clock.fillAmount = (maxtime - time) / maxtime;
        }
        if(time <= 0 && reparing)
        {
            clock.enabled = false;
            reparing = false;
            player.Build(false);
        }
    }

    public void Activate(InteractiveItem item)
    {
        
        Vector3 distance = player.transform.position - item.transform.position;
        
        if (distance.magnitude < 1.9 && !reparing)
        {
            reparing = true;
            clock.enabled = true;
            time = 3;
            maxtime = time;
            player.UseItem();
            player.transform.LookAt(item.transform);
            item.Use();
            Deselect();
        }
        else if(!reparing)
        {
            player.agent.SetDestination(item.transform.position);
        }
    }

    public void InitBuild(BuildArea area)
    {
        reparing = true;
        clock.enabled = true;
        time = 3f;
        maxtime = time;
        player.Build(true);
        player.transform.LookAt(area.transform);
        area.Use();
        Deselect();
    }

    public void Select(InteractiveItem item)
    {
        Vector3 distance = player.transform.position - item.transform.position;

        if (distance.magnitude < 1.9 && !reparing)
        {
            useButton.gameObject.SetActive(true);
            EventTrigger trigger = item.gameObject.GetComponentInChildren<EventTrigger>();
        
            useButton.onClick.AddListener(() =>
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                trigger.OnPointerDown(eventData);
            });
        }
    }

    public void Deselect()
    {
        useButton.gameObject.SetActive(false);
        useButton.onClick.RemoveAllListeners();
    }
}
