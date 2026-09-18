using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void SetMovementSpeed(float speed)
    {
        anim.SetFloat("Speed", speed);
    }
    public void SetGrounded(bool isGrounded)
    {
        anim.SetBool("Grounded", isGrounded);
    }
    public void SetVelY(float speedY)
    {
        anim.SetFloat("SpeedVertical", speedY);
    }
    public void SetAttack(int combo)
    {
        anim.SetInteger("Combo", combo);
    }
}
