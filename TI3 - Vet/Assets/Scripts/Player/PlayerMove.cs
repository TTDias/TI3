using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    public NavMeshAgent agent;
    bool isPressed;
    Vector2 position;

    void Update()
    {
        if (UIRepairScript.Instance.reparing == true) return;

        //    bool mouseClick = Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject();
        //    bool touchClick = Input.touchCount > 0 
        //                      && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) 
        //                      && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

        //    if(Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        //    {
        //        Debug.Log("Mouse na ui: " + EventSystem.current.IsPointerOverGameObject());
        //        Debug.Log("Touch na ui: " + EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId));
        //    }

        if (isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (agent.hasPath)
        {
            agent.ResetPath();
        }
    }

    public void OnPointerPosition(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }

    public void OnPointerClick(InputAction.CallbackContext context)
    {
        isPressed = context.ReadValue<float>() > 0;
    }


}

