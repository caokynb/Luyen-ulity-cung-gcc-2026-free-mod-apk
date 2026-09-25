using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    [SerializeField] public Player player;
    public void FirstAttackEnd()
    {
        player.waitForAttack=true;
    }
    public void SecondAttackEnd()
    {
        player.StateMachine.ChangeState(player.GroundState);
    }
}
