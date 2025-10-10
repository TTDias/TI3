using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject[] obj;
    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject G in obj)
        {
            G.LeanScale(Vector3.zero, 0f);
        }
        LeanTween.init();
        foreach (GameObject G in obj)
        {
            LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setDelay(t);
            t += 0.5f;
        }
        foreach (GameObject G in obj)
        {
            LeanTween.scale(G, new Vector3(1.1f, 1.1f, 1.1f), 0.5f).setOnComplete(() =>
            {
                if (G.name != "menu")
                {
                    //t = 0;
                    LeanTween.scale(G, new Vector3(1, 1, 1), 0.5f).setLoopPingPong();
                    //t += 10;
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void botaojogar()
    {
       
    }
    public void botaocreditos()
    {

    }
}