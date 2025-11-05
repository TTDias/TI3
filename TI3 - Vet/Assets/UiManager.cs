using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider levelTime, catTolerance;
    public CatPlay cat;
    public Transform pointer;
    void Start()
    {
        levelTime.maxValue = GameManager.Manager.timer;

        catTolerance.maxValue = cat.waitTime;
        catTolerance.value = cat.waitTime;
    }

    
    void Update()
    {
        levelTime.value = levelTime.maxValue - GameManager.Manager.timer;
        float rotation = -levelTime.value * 360/ levelTime.maxValue;
        pointer.rotation = Quaternion.Euler(0, 0, rotation);

        if (cat.waiting)
        {
            catTolerance.value = cat.cooldown;
        }
        else if(catTolerance.value < catTolerance.maxValue)
        {
            catTolerance.value = catTolerance.maxValue;
        }
    }
}
