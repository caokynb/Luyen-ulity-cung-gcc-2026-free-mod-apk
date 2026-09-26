using UnityEngine;
public class DeathState : IState
{
    private Player player;
    public DeathState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.rb.linearVelocityX=0;
        player.anim.SetTrigger("Death");
    }
    public void Tick()
    {
        
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        
    }

}