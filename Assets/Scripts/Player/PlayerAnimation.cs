using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator animator;

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 movementInput = value.ReadValue<Vector2>();
        animator.SetBool("IsRunning", movementInput != Vector2.zero);

        //if (movementInput > 0f)
        //{
        //    animator.SetBool("IsRunning", true);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //}

    }

}
