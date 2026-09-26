using UnityEngine;
public class HitState : IState
{
    private Player player;
    private float timer=0f;
    private float iFrame=0.2f;
    public HitState(Player player)
    {
        this.player = player;
    }
    public void Enter()
    {
        Debug.Log("Ựa");
        timer=0f;
        iFrame=0.2f;
        player.anim.SetBool("Hit",true);
        player.hp--;
        if(player.hp>0) player.rb.linearVelocity=new Vector2(player.knockbackVelocity.x*player.transform.localScale.x*-1f,player.knockbackVelocity.y);
        else player.StateMachine.ChangeState(player.DeathState);
    }
    public void Tick()
    {
        if(player.isGrounded && timer>=iFrame){
            player.StateMachine.ChangeState(player.GroundState);
        }
        timer+=Time.deltaTime;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        player.anim.SetBool("Hit",false);
    }

}