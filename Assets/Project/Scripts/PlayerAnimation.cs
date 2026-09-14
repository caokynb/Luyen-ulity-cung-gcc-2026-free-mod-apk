using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void SetMovementSpeed(float speed)
    {
        anim.SetFloat("Speed", speed);
    }
    public void SetJump()
    {
        anim.SetTrigger("Jump");
    }
    public void SetGrounded(bool isGrounded)
    {
        anim.SetBool("Grounded", isGrounded);
    }
}
