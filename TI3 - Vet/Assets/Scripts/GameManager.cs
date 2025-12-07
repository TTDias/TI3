using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    static public float score = 0;
    static public float timer = 2 * 60;
    public static float starScore1 = 500, starScore2 = 800, starScore3 = 1000;

    static bool tutorial = false, phonruse = false;
    
    static int loses = 0, victories = 0;
    
    static public void GameStart()
    {
        score = 0;
        timer = 2 * 60;
    }

    void Update()
    {
        if (timer <= 0f) GameEnd();
        else if (!tutorial)
        {
            timer -= Time.deltaTime;
        }
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
        if (score < starScore1)
        {
            loses++;
            AnalyticsTest.Instance.AddAnalytics("Game", "Loses", loses.ToString());
            SceneManager.LoadScene("TelaDerrota");
        }
        else 
        {
            victories++;
            AnalyticsTest.Instance.AddAnalytics("Game", "Victories", victories.ToString());
            SceneManager.LoadScene("TelaVitoria");
        } 
    }

    static public bool Statustutorial()
    {
        return tutorial;
    }
    static public void Mudartutorial(bool mudar)
    {
        tutorial = mudar;
    }
    static public bool StatusPhone()
    {
        return phonruse;
    }
    static public void MudarPhone(bool mudar)
    {
        phonruse = mudar;
    }
}
