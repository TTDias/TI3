using UnityEngine;

public class CatPlay : MonoBehaviour
{

    public float waitTime;
    public float cooldown;
    public bool waiting;
    public menu menu;


    float fightProb = 0;

    int runaway = 0;

    public bool catHurted = false;
    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0 && waiting) cooldown -= Time.deltaTime;
        if (cooldown <=0 && waiting)
        {
            waiting = false;
            Runaway();
        }
    }

    public void Call()
    {
        cooldown = waitTime;
        waiting = true;
    }

    public void Sleep()
    {
        GetComponent<CatMove>().Sleep();
    }

    public void Cancel()
    {
        waiting = false;
    }

    void Runaway()
    {
        runaway ++;
        AnalyticsTest.Instance.AddAnalytics("Cat", "Runaway", runaway.ToString());
        if(menu.dicas.transform.lossyScale.y == 0)
        {
            menu.MostrarDica();
        }
        if (fightProb <= Random.value)
        {
            GameManager.RunawayScoreDown();
            fightProb += 0.5f;
        }
        else
        {
            catHurted = true;
            GameManager.FightPenality();
            fightProb = 0;
        }
            GetComponent<CatMove>().Runaway();
    }
}
