using UnityEngine;

public class CatPlay : MonoBehaviour
{
    private CatSoundMannager catSound;
    public string status = "Normal";
    public float waitTime;
    public float cooldown;
    public bool waiting;

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

    public void Play(CatItens item)
    {
        //GetComponent<Animation>().Play("CatItemUse");
        item.Broke();
        LeanTween.delayedCall(2f, Sleep);
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

        status = "Angry";
        if (fightProb <= Random.value)
        {
            GameManager.RunawayScoreDown();
            fightProb += 0.5f;
            catSound.PlayMeow2();
        }
        else
        {
            catHurted = true;
            GameManager.FightPenality();
            fightProb = 0;
            catSound.PlayAngry();
        }
            GetComponent<CatMove>().Runaway();
    }


}
