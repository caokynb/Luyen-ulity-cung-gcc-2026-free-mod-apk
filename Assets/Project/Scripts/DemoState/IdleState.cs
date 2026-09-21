

using UnityEngine;

public class IdleState : IState
{
    private Player player;
    private float horizontal;
    
    public IdleState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.Anim.SetBool("IsIdle",true);
    }

    public void Tick()
    {        
        horizontal = player.MoveInput.action.ReadValue<float>();
        if (horizontal != 0)
        {
            player.StateMachine.ChangeState(player.RunState);
            return;
        }
        player.Rigi.linearVelocity = Vector2.zero;
    }

    public void FixedTick()
    {
      
    }

    public void Exit()
    {
        player.Anim.SetBool("IsIdle",false);
    }
}