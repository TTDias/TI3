using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score = 0, starScore1 = 500, starScore2, starScore3;
    public float timer = 3 * 60;
    public static GameManager Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f) GameEnd();
        else timer -= Time.deltaTime;
    }

    public void RepairScoreUp()
    {
        score += 100;
    }

    public void RunawayScoreDown()
    {
        score -= 150;
    }

    public void VetCallScoreUp()
    {
        score += 100;
    }

    public void BoxPlacementScoreUp()
    {
        score += 50;
    }

    public void BoxPlacementScoreDown()
    {
        score -= 50;
    }

    void GameEnd()
    {

    }
}
