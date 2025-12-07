using System.Collections.Generic;
using UnityEngine;

public class BoxThrower : MonoBehaviour
{
    public Transform constructions;
    public Transform boxThrowPoint;
    public GameObject box;
    Stack<GameObject> boxStack = new Stack<GameObject>();

    public float timer, waitTime = 3;
    public bool truck = false, truckRun = false;

    public Animator TruckAnimator;
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


        if(transform.childCount < 2 && boxStack.Count > 0 && !truck)
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
            TruckAnimator.SetTrigger("Run");
        }
        
    }

    public void ThrowBox()
    {
        GameObject newBox = boxStack.Pop();
        newBox.transform.SetParent(transform);
        newBox.transform.position = boxThrowPoint.position;
        float magnitude = 4.5f;
        newBox.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 1) * magnitude, ForceMode.Impulse);
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
