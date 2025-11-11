using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject star1, star2, star3;
    void Start()
    {
        Debug.Log(GameManager.score);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        if (GameManager.score > GameManager.starScore1) star1.SetActive(true);
        if (GameManager.score > GameManager.starScore2) star2.SetActive(true);
        if (GameManager.score > GameManager.starScore3) star3.SetActive(true);
    }
}
