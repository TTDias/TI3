using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public NavMeshAgent agent;

    //void Update()
    //{
    //    if (UIRepairScript.Instance.reparing == true) return;
        
    //    bool mouseClick = Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject();
    //    bool touchClick = Input.touchCount > 0 
    //                      && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) 
    //                      && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

    //    if(Input.GetMouseButtonUp(0) || Input.touchCount > 0)
    //    {
    //        Debug.Log("Mouse na ui: " + EventSystem.current.IsPointerOverGameObject());
    //        Debug.Log("Touch na ui: " + EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId));
    //    }

    //    if (mouseClick || touchClick)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            agent.SetDestination(hit.point);
    //        }
    //    }
    //    else if(Input.GetMouseButtonUp(0) || Input.touchCount == 0)
    //    {
    //        agent.ResetPath();
    //    }
    //}

    public void OnClickOrTouch(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        // Verifica se o clique está sobre a UI
        //if (IsPointerOverUI()) return;

        // Raycast para detectar ponto de destino
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }


}
