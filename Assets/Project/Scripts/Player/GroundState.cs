using UnityEngine;
public class GroundState : IState
{
    private Player player;
    public GroundState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.isGrounded=true;
        player.anim.SetBool("Grounded",true);
        player.isFalling=false;
    }
    public void Tick()
    {
        player.anim.SetFloat("SpeedX",Mathf.Abs(player.MoveAction.ReadValue<float>()));
        player.rb.linearVelocityX=player.walkSpeed*player.MoveAction.ReadValue<float>();
        if (player.JumpAction.ReadValue<float>() > 0 && player.isGrounded)
        {
            player.StateMachine.ChangeState(player.AirState);
        }
        if (player.DashAction.WasPressedThisFrame())
        {
            player.StateMachine.ChangeState(player.DashState);
        }
        if (player.AttackAction.WasPressedThisFrame())
        {
            player.StateMachine.ChangeState(player.AttackState);
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        /*player.isGrounded=false;
        player.anim.SetBool("Grounded",false);*/
    }

}