

using UnityEngine;

public class RunState : IState
{
    private Player player;
    private float horizontal;
    public RunState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.Anim.SetBool("IsRun",true);
    }

    public void Tick()
    {
        horizontal = player.MoveInput.action.ReadValue<float>();
        if (horizontal == 0)
        {
            player.StateMachine.ChangeState(player.IdleState);
            return;
        }
        player.Rigi.linearVelocity = new Vector2(horizontal * 20, player.Rigi.linearVelocityY);
    }

    public void FixedTick()
    {
        
    }

    public void Exit()
    {
        player.Anim.SetBool("IsRun",false);
    }
}