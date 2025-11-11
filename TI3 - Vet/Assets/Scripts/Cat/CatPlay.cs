using UnityEngine;

public class CatPlay : MonoBehaviour
{

    public float waitTime;
    public float cooldown;
    public bool waiting;
    public menu menu;

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
        if(menu.dicas.transform.lossyScale.y == 0)
        {
            menu.MostrarDica();
        }
        GameManager.RunawayScoreDown();
        GetComponent<CatMove>().Runaway();
    }
}
