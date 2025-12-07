using System.Collections.Generic;
using UnityEngine;

public class BoxThrower : MonoBehaviour
{
    public Transform constructions;
    public Transform boxThrowPoint;
    public GameObject box;
    Stack<GameObject> boxStack = new Stack<GameObject>();

    float timer, waitTime = 3;
    bool truck = false, truckRun = false;

    public Animator house;
    void Start()
    {
        timer = 3;
        foreach(Transform area in constructions)
        {
            if (area.gameObject.activeSelf)
            {
                GameObject newBox = Instantiate(box);
                newBox.transform.position = new Vector3(100, 1, 0);
                boxStack.Push(newBox);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Statustutorial())
            return;


        if(transform.childCount < 3 && boxStack.Count > 0 && !truck)
        {
            truck = true;
            truckRun = true;
            timer = waitTime;
        }

        if(timer > 0 )
        {
            timer -= Time.deltaTime;
        }
        else if (truckRun)
        {
            truckRun = false;
            house.SetTrigger("Run");
        }
        
    }

    public void ThrowBox()
    {
        GameObject newBox = boxStack.Pop();
        newBox.transform.SetParent(transform);
        newBox.transform.position = boxThrowPoint.position;
        float magnitude = 2;
        newBox.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1) * magnitude);
        truck = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Truck")
        {
            ThrowBox();
        }
    }
}
