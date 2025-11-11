using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider levelTime, catTolerance, stars;
    public CatPlay cat;
    public Transform pointer;
    void Start()
    {
        stars.value = 0;
        stars.maxValue = GameManager.starScore3;
        levelTime.maxValue = GameManager.timer;

        catTolerance.maxValue = cat.waitTime;
        catTolerance.value = cat.waitTime;
    }

    
    void Update()
    {
        levelTime.value = levelTime.maxValue - GameManager.timer;
        if(GameManager.score < GameManager.starScore1) stars.value = GameManager.score/3;
        else if(GameManager.score < GameManager.starScore2) stars.value = GameManager.score*2/3;
        else stars.value = GameManager.score;


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
