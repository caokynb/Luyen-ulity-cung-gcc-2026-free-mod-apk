using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowState : IState
{
    private Zombie zombie;
    private int dir;
    public FollowState(Zombie zombie)
    {
        this.zombie = zombie;
    }
    public void Enter()
    {
        Debug.Log("Following!");
        zombie.anim.Play("ZombieWalk");
        
    }

    public void Tick()
    {   
        if(zombie.player.transform.position.x>zombie.transform.position.x) dir=1;
        else dir=-1;     
        zombie.rb.linearVelocityX=zombie.walkSpeed*dir;
    }

    public void FixedTick()
    {
      
    }

    public void Exit()
    {
        zombie.rb.linearVelocityX=0f;
    }
}
