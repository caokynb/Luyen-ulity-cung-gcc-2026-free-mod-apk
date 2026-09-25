using UnityEngine;
public class DashState : IState
{
    private Player player;
    private float timer=0f;
    private int dir;
    public DashState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.anim.SetBool("Dash",true);
        timer=0f;
        if(player.transform.localScale.x>0) dir=1;
        else dir=-1;
        player.rb.linearVelocityX=player.dashSpeed*dir;
    }
    public void Tick()
    {
        if (timer >= player.dashTime)
        {
            if(player.isGrounded) player.StateMachine.ChangeState(player.GroundState);
            else {
                player.isFalling=true;
                player.StateMachine.ChangeState(player.AirState);
            }
        }
        timer+=Time.deltaTime;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        player.anim.SetBool("Dash",false);
        player.rb.linearVelocityX=0f;
    }

}