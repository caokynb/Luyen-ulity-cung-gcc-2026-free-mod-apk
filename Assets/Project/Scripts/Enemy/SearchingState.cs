using UnityEngine;

public class SearchingState : IState
{
    private Zombie zombie;
    private int choose;
    private int[] dir = {-1, 1};
    private float timer=0f;
    public SearchingState(Zombie zombie)
    {
        this.zombie = zombie;
    }
    public void Enter()
    {
        Debug.Log("Searching..");
        zombie.anim.Play("ZombieWalk");
        choose=Random.Range(0,2);
    }

    public void Tick()
    {        
        zombie.rb.linearVelocityX=zombie.walkSpeed*dir[choose];
        if(timer>=zombie.maxWalkTime) 
        {
            zombie.StateMachine.ChangeState(zombie.IdleState);
            return;
        }
        timer+=Time.deltaTime;
    }

    public void FixedTick()
    {
      
    }

    public void Exit()
    {
        timer=0f;
    }
}
