using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    static public float score = 0;
    static public float timer = 2 * 60;
    public static float starScore1 = 500, starScore2 = 800, starScore3 = 1000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static public void GameStart()
    {
        score = 0;
        timer = 2 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f) GameEnd();
        else timer -= Time.deltaTime;
    }

    static public void RepairScoreUp()
    {
        score += 75;
    }

    static public void RunawayScoreDown()
    {
        score -= 150;
    }

    static public void FightPenality()
    {
        score -= 500;

    }

    static public void VetCall()
    {
        score += 300;
    }

    static public void BoxPlacementScoreUp()
    {
        score += 150;
    }

    static public void BoxPlacementScoreDown()
    {
        score -= 150;
    }

    static void GameEnd()
    {
        if(score < starScore1) SceneManager.LoadScene("TelaDerrota");
        else SceneManager.LoadScene("TelaVitoria");
    }
}
