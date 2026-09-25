using UnityEngine;
using System.Collections;
public class AttackState : IState
{
    private Player player;
    private Coroutine attack=null;
    private float waitTime = 0.7f;
    float timer=0f;
    public AttackState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.isAttacking=true;
        player.rb.linearVelocity=Vector2.zero;
        timer=0f;
        waitTime=0.7f;
        player.anim.SetInteger("Combo",1);
    }
    public void Tick()
    {
        if(attack==null){
            attack=player.StartCoroutine(StartAttack());
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        player.isAttacking=false;
        attack=null;
    }
    private IEnumerator StartAttack()
    {
        yield return null;
        Debug.Log("Đấm 1!");
        bool pressed=false;
        while (timer <= waitTime)
        {
            if (player.AttackAction.WasPressedThisFrame() && timer>=waitTime/2)
            {
                pressed=true;
            }
            timer+=Time.deltaTime;
            yield return null;
        }
        if(pressed){
            player.anim.SetInteger("Combo",2); 
            Debug.Log("Đấm 2!");
            yield return new WaitForSeconds(waitTime-0.45f);
        } 
        player.anim.SetInteger("Combo",0);
        yield return null;
        player.StateMachine.ChangeState(player.GroundState);
    }

}