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
    public Animator anima;
    float idleTime = 0;
    void Update()
    {
        if (UIRepairScript.Instance.reparing == true) return;

        if (isPressed && !IsPointerOverUI())
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            anima.SetFloat("Blend", 1);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (agent.hasPath)
        {
            agent.ResetPath();
            anima.SetFloat("Blend", 0);
        }


        if(anima.GetFloat("Blend") == 0)
        {
            idleTime += Time.deltaTime;
            anima.SetFloat("Time", idleTime);
        }
        if(idleTime >= 4 || anima.GetFloat("Blend") == 1)
        {
            idleTime = -1;
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

    bool IsPointerOverUI()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue());
        }
#endif
        return EventSystem.current.IsPointerOverGameObject();
    }

}

