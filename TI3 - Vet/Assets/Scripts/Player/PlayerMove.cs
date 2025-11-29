using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    public InputAction click;

    public NavMeshAgent agent;
    bool isPressed;
    Vector2 position;
    public Animator anima;
    float idleTime = 0;
    public LayerMask ground;
    void Update()
    {
        anima.SetFloat("Blend", agent.velocity.magnitude);
        if (gameObject.name == "PlayerFinalVariant")
            if (UIRepairScript.Instance.reparing == true) return;

        if (isPressed && !IsPointerOverUI())
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            //anima.SetFloat("Blend", 1);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (!isPressed)
        {
            agent.ResetPath();
            //anima.SetFloat("Blend", 0);
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

    public void UseItem()
    {
        anima.SetTrigger("UseItem");
    }

    public void Build(bool val)
    {
        anima.SetBool("Build", val);
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

