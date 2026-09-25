using UnityEngine;

public class IdleStateZombie : IState
{
    private Zombie zombie;
    [SerializeField] float idleTime=2f;
    private float timer=0f;
    public IdleStateZombie(Zombie zombie)
    {
        this.zombie = zombie;
    }
    public void Enter()
    {
        Debug.Log("Idling..");
        zombie.anim.Play("ZombieIdle");
        zombie.rb.linearVelocityX=0f;
    }

    public void Tick()
    {
        if(timer>=idleTime){
            zombie.StateMachine.ChangeState(zombie.SearchingState);
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