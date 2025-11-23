using UnityEngine;
using UnityEngine.UI;

public class BuildTimer : UIRepairScript
{
    public Image clock;
    float time;
    bool onRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);

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
        if (!onRange) return;
        reparing = true;
        clock.enabled = true;
        time = 3;
        player.UseItem();
        item.Use();
    }

    public override void Select(InteractiveItem item)
    {
        onRange = true;
    }

    public override void Deselect()
    {
        onRange = false;
    }
}
