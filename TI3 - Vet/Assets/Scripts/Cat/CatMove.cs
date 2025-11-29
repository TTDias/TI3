using System.Runtime.ConstrainedExecution;
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

    public menu menu;
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
      
        if (running && meshAgent.isOnOffMeshLink)
        {
            running = false;
            Jump();
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
        meshAgent.autoTraverseOffMeshLink = false;
        string msg = "<b>Dicas do Veterinário</b>\r\n\r\n";
        if (menu.dicas.transform.lossyScale.y == 0)
        {
            if (trackingItem.GetComponent<CatItens>().IsItemType(CatItens.Item.water))
                msg += "Gatos são animais dificeis para beber água. Tenha preferencialmente mais que um pote e garanta que os estejam sempre limpos e troque a água com frequência. Gatos podem fugir de casa e beber água suja de poças, por exemplo.";
            else if (trackingItem.GetComponent<CatItens>().IsItemType(CatItens.Item.post))
                msg += "Tenha sempre opções para o gato brincar. Sem isso, eles podem se sentir entediados e estressados por não gastarem energia e buscar esses estimulos na rua.\n Podem arranhar troncos podres, caçar animais potencialmente doentes e brigar com gatos contaminados, podendo constrair a esporotricose.";
            else if (trackingItem.GetComponent<CatItens>().IsItemType(CatItens.Item.litterbox))
                msg += "Lembre-se de limpar a caixa de areia do seu gato. Com a caixa de areia suja, eles vão se recusar a usar e podem sair de casa para fazer suas necessiades. Ao cavar a terra com suas unhas, elas podem se sujar com os esporos do fungo e contaminar outro gato em uma briga, ou contaminar o próprio dono.";
            else
                msg += "Seu gato precisa de um ambiente doméstico estimulante, caso o contrário poderá ter problemas relacionados a estresse e fugir de casa com mais frequência";

        }
        menu.MostrarDica(msg);

        meshAgent.SetDestination(runawayPoint.position);
        running = true;
    }

    void Jump()
    {
        OffMeshLinkData data = meshAgent.currentOffMeshLinkData;

        Vector3 end = data.endPos;

        transform.rotation = Quaternion.LookRotation(end);

        animator.SetTrigger("Jump");
        LeanTween.delayedCall(0.46f, () => 
        { 
            LeanTween.moveLocal(gameObject,end, 0.5f); 
        });  
        LeanTween.delayedCall(1.5f, () => 
        {
            meshAgent.Warp(transform.position);
            meshAgent.CompleteOffMeshLink();
            meshAgent.autoTraverseOffMeshLink = true;  
            meshAgent.SetDestination(runawayPoint.position); 
        });

        LeanTween.delayedCall(sleepTime - 1, () => { meshAgent.SetDestination(exitPoint.position); Sleep(0.8f); });
    }
}
