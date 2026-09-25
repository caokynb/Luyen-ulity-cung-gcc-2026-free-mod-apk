using UnityEngine;
public class AirState : IState
{
    private Player player;
    public AirState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.anim.SetBool("Grounded",false);
        player.isGrounded=false;
        if(!player.isFalling) player.rb.linearVelocityY=player.jumpForce;
        player.isFalling=false;
    }
    public void Tick()
    {
        player.anim.SetFloat("SpeedY",player.rb.linearVelocityY);
        player.rb.linearVelocityX=player.walkSpeed*player.MoveAction.ReadValue<float>();
        if (player.rb.linearVelocityY == 0)
        {
            player.StateMachine.ChangeState(player.GroundState);
        }
        if (player.DashAction.WasPressedThisFrame())
        {
            player.StateMachine.ChangeState(player.DashState);
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        /*player.isGrounded=true;
        player.anim.SetBool("Grounded",true);*/
    }

}