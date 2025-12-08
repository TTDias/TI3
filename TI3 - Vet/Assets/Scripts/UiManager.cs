using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider levelTime, catTolerance, stars;
    public CatPlay cat;
    public Transform pointer;
    public Image catBar;

    ColorBlock colors;
    Color red;
    Color yellow = new Color(255, 170, 0);
    void Start()
    {
        colors = stars.colors;
        red = colors.disabledColor;
        Debug.Log(colors.disabledColor);

        colors.disabledColor = Color.white;
        stars.colors = colors;

        stars.value = 0;
        stars.maxValue = GameManager.starScore3;
        levelTime.maxValue = GameManager.timer;

        catTolerance.maxValue = cat.waitTime;
        catTolerance.value = cat.waitTime;

        levelTime.gameObject.SetActive(false);
        stars.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (!GameManager.Statustutorial() && !levelTime.gameObject.activeSelf)
        {
            levelTime.gameObject.SetActive(true);
            stars.gameObject.SetActive(true);
        }

        levelTime.value = levelTime.maxValue - GameManager.timer;
        if (GameManager.score < 0)
        {
            if (colors.disabledColor != red)
            {
                colors.disabledColor = red;
                Debug.Log(colors.disabledColor);
            }
        }
        else if (colors.disabledColor != Color.white)
            colors.disabledColor = Color.white;
        stars.colors = colors;


        if (GameManager.score < GameManager.starScore1)
            stars.value = Mathf.Abs(GameManager.score / 3);
        else if (GameManager.score < GameManager.starScore2) 
            stars.value = GameManager.score * 2 / 3;
        else 
            stars.value = GameManager.score;


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
        float val = catTolerance.value / catTolerance.maxValue;
        if (val > 0.5)
            catBar.color = Color.Lerp(Color.yellow, Color.green, (val-0.5f) * 2f);
        else
            catBar.color = Color.Lerp(Color.red, Color.yellow, (val * 2f));

    }
}
