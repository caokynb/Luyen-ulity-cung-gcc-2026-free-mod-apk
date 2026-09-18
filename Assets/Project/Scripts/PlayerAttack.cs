using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction AttackAction;
    [SerializeField] private PlayerAnimation anim;
    [SerializeField] private PlayerMovement playerMove;
    private Coroutine attack;
    public float waitTime = 0.25f;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void Awake()
    {
        AttackAction = InputSystem.actions.FindAction("Attack");
    }
    void Update()
    {
        if (AttackAction.WasPressedThisFrame())
        {
            if(attack==null){
                attack=StartCoroutine(StartAttack());
                Debug.Log("Đấm!");
            }
        }
    }
    private IEnumerator StartAttack()
    {
        playerMove.isAttacking=true;
        yield return null;
        int combo=1;
        float timer=0f;
        bool pressed=false;
        anim.SetAttack(combo);
        while (timer <= waitTime)
        {
            if (AttackAction.WasPressedThisFrame() && timer>=waitTime/2)
            {
                pressed=true;
            }
            timer+=Time.deltaTime;
            yield return null;
        }
        if(pressed){
            combo++;
            anim.SetAttack(combo); 
            Debug.Log("Đấm 2!");
            yield return new WaitForSeconds(waitTime-0.45f);
        } 
        combo=0;
        anim.SetAttack(combo);
        attack=null;
        playerMove.isAttacking=false;
        yield return null;
    }
}
