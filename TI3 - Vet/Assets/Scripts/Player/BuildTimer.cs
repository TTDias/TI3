using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildTimer : UIRepairScript
{
    public Image clock;
    public Button useButton;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            clock.fillAmount = (3f - time) / 3f;
        }
        if(time <= 0 && reparing)
        {
            clock.enabled = false;
            reparing = false;
        }
    }

    public void Activate(InteractiveItem item)
    {
        
        Vector3 distance = player.transform.position - item.transform.position;
        
        if (distance.magnitude < 1.65 && !reparing)
        {
            reparing = true;
            clock.enabled = true;
            time = 3;
            player.UseItem();
            player.transform.LookAt(item.transform);
            item.Use();
        }
        else if(!reparing)
        {
            player.agent.SetDestination(item.transform.position);
        }
    }

    public override void Select(InteractiveItem item)
    {
        if (!reparing)
        {
            useButton.gameObject.SetActive(true);
            EventTrigger trigger = item.gameObject.GetComponentInChildren<EventTrigger>();
        
            useButton.onClick.AddListener(() =>
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                trigger.OnPointerDown(eventData);
                Deselect();
            });
        }
    }

    public override void Deselect()
    {
        useButton.gameObject.SetActive(false);
        useButton.onClick.RemoveAllListeners();
    }
}
