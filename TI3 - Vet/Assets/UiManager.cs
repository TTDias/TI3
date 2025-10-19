using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider levelTime, catTolerance;
    public CatPlay cat;
    void Start()
    {
        levelTime.maxValue = GameManager.Manager.timer;
        catTolerance.maxValue = cat.waitTime;
        catTolerance.value = cat.waitTime;
    }

    
    void Update()
    {
        levelTime.value = levelTime.maxValue - GameManager.Manager.timer;

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
