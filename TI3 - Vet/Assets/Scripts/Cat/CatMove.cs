using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CatMove : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public Transform[] positions;
    public Transform sleepPoint, exitPoint, runawayPoint;

    public float sleepTime;
    float sleepCooldown;
    bool sleeping, running;

    GameObject trackingItem;
    public Animator animator;
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
        animator.SetFloat("Velocity", meshAgent.velocity.magnitude);
    }

    public void Sleep(float mod = 1)
    {
        sleepCooldown = sleepTime * mod;
        meshAgent.SetDestination(sleepPoint.position);
        sleeping = true;
    }

    public void Runaway()
    {
        AnalyticsTest.Instance.AddAnalytics("Cat", "Runaway Item", trackingItem.name);
        meshAgent.SetDestination(exitPoint.position);
        running = true;
    }

    void RunAwayStart()
    {
        animator.SetTrigger("Jump");
        LeanTween.delayedCall(0.7f, () => { meshAgent.SetDestination(exitPoint.position + new Vector3(1, 1, 0)); });  
        LeanTween.delayedCall(1, () => { meshAgent.SetDestination(runawayPoint.position); });
        //GetComponent<Animation>().Play("CatWindowJump");
        LeanTween.delayedCall(sleepTime - 1, () => { meshAgent.SetDestination(exitPoint.position); Sleep(0.8f); });
    }
}
