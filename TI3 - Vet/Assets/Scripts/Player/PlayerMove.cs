using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public NavMeshAgent agent;
    bool isPressed;
    Vector2 position, moveInput;
    public Animator anima;
    float idleTime = 0;
    public LayerMask ground;
    void Update()
    {

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        if(move != Vector3.zero)
        {
            agent.SetDestination(transform.position + move*2);
        }

        anima.SetFloat("Blend", agent.velocity.magnitude);
        if (gameObject.name == "PlayerFinalVariant")
            if (BuildButton.Instance.reparing == true) return;

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

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void UseItem()
    {
        anima.SetTrigger("UseItem");
    }

    public void Build(bool val)
    {
        anima.SetBool("Building", val);
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

