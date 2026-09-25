using UnityEngine;
public class AttackState : IState
{
    private Player player;
    private float timer=0f;
    private float waitTime=0.5f;
    public AttackState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        timer=0f;
        waitTime=0.5f;
        player.waitForAttack=false;
        player.isAttacking=true;
        player.attackCombo=1;
        player.anim.SetBool("Attack",player.isAttacking);
        player.anim.SetInteger("Combo",player.attackCombo);
        player.rb.linearVelocity=Vector2.zero;
    }
    public void Tick()
    {
        if(player.waitForAttack)
        {
            player.anim.SetBool("Attack",player.isAttacking);
            if (timer <= waitTime)
            {
                if (player.AttackAction.WasPressedThisFrame())
                {
                    //Debug.Log("Đã đánh đòn 2");
                    player.attackCombo=2;
                    player.isAttacking=true;
                }
            } else
            {
                if (player.attackCombo == 2)
                {
                    player.anim.SetBool("Attack",player.isAttacking);
                    player.anim.SetInteger("Combo",player.attackCombo);
                } else player.StateMachine.ChangeState(player.GroundState);
            }
            timer+=Time.deltaTime;
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        player.isAttacking=false;
        player.anim.SetBool("Attack",player.isAttacking);
        player.attackCombo=0;
        player.anim.SetInteger("Combo",player.attackCombo);
    }

}