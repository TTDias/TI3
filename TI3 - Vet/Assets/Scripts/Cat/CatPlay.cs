using UnityEngine;

public class CatPlay : MonoBehaviour
{
    private CatSoundMannager catSound;
    public float waitTime;
    public float cooldown;
    public bool waiting;
    public menu menu;


    float fightProb = 0;

    int runaway = 0;

    public bool catHurted = false;
    // Update is called once per frame
    void Start()
    {
        catSound = GetComponent<CatSoundMannager>();
    }
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
        if (Random.value > 0.5f)
            catSound.PlayMeow();
        else
            catSound.PlayMeow2();

        cooldown = waitTime;
        waiting = true;
    }

    public void Sleep()
    {
        catSound.PlaySleep();
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
            catSound.PlayAngry();
        }
        else
        {
            catHurted = true;
            GameManager.FightPenality();
            fightProb = 0;
            catSound.PlayMeow2();
        }
            GetComponent<CatMove>().Runaway();
    }
}
