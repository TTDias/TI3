using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CatMove : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public Transform[] positions;
    public Vector3 sleepPoint, exitPoint;

    public float sleepTime;
    float sleepCooldown;
    bool sleeping, running;

    GameObject trackingItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sleepCooldown > 0f)
            sleepCooldown -= Time.deltaTime;
        if (sleepCooldown <= 0 && sleeping)
        {
            sleeping = false;
            int index = Random.Range(0, positions.Length);
            meshAgent.SetDestination(positions[index].position);
            trackingItem = positions[index].gameObject;
        }

        if (running && (!meshAgent.pathPending && meshAgent.remainingDistance <= meshAgent.stoppingDistance))
        {
            running = false;
            RunAwayStart();
        }
    }

    public void Sleep(float mod = 1)
    {
        sleepCooldown = sleepTime;
        meshAgent.SetDestination(sleepPoint*mod);
        sleeping = true;
    }

    public void Runaway()
    {
        AnalyticsTest.Instance.AddAnalytics("Cat", "Runaway Item", trackingItem.name);
        meshAgent.SetDestination(exitPoint);
        running = true;
    }

    void RunAwayStart()
    {
        GetComponent<Animation>().Play("CatWindowJump");
        LeanTween.delayedCall(sleepTime - 1, () => { GetComponent<Animation>().Play("CatWindowBack"); Sleep(0.7f); });
    }
}
