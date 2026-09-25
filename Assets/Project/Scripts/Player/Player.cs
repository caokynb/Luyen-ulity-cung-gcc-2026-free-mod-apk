using NUnit.Framework.Interfaces;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public StateMachine StateMachine {get; private set;}
    public GroundState GroundState {get; private set;}
    public AirState AirState {get; private set;}
    public AttackState AttackState {get; private set;}
    public DashState DashState {get; private set;}
    public HitState HitState {get; private set;}
    public DeathState DeathState {get; private set;}
    [field:SerializeField] public Animator anim {get; private set;}
    [field:SerializeField] public Rigidbody2D rb {get; private set;}
    [field:SerializeField] public BoxCollider2D cd {get; private set;}
    [field:SerializeField] public InputActionAsset InputActions {get; private set;}
    public InputAction MoveAction {get; private set;}
    public InputAction JumpAction {get; private set;}
    public InputAction AttackAction {get; private set;}
    public InputAction DashAction {get; private set;}
    [field:SerializeField] public float walkSpeed {get; private set;}
    [field:SerializeField] public float jumpForce {get; private set;}
    [field:SerializeField] public int attackDamage {get; private set;}
    [field:SerializeField] public int hp {get; set;}
    [field:SerializeField] public float dashSpeed {get; private set;}
    [field:SerializeField] public float dashTime {get; private set;}

    public bool isGrounded;
    public bool isFalling;
    public bool isAttacking;
    public float boxSizeX=1f;
    public float boxSizeY=1f;
    public float castDist=1f;
    [SerializeField] LayerMask groundLayer;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void Awake()
    {
        StateMachine = new StateMachine();
        GroundState = new GroundState(this);
        AirState = new AirState(this);
        AttackState = new AttackState(this);
        DashState = new DashState(this);
        HitState = new HitState(this);
        DeathState = new DeathState(this);
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        AttackAction = InputSystem.actions.FindAction("Attack");
        DashAction = InputSystem.actions.FindAction("Dash");
    }

    private void Start()
    {
        StateMachine.ForceSetState(GroundState);
    }

    private void Update()
    {
        StateMachine.Tick();
        Flip();
        CheckGround();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedTick();
    }
    private void Flip()
    {
        Vector3 currentDir=transform.localScale;
        if(rb.linearVelocityX>0) currentDir.x=1;
        else if(rb.linearVelocityX<0) currentDir.x=-1;
        transform.localScale=currentDir;
    }
    void CheckGround()
    {
        RaycastHit2D touched = Physics2D.BoxCast(transform.position - new Vector3(0,boxSizeY-1,0),new Vector2(boxSizeX,boxSizeY),0f,Vector2.zero,castDist,groundLayer);
        if(touched.collider!=null) isGrounded=true;
        else isGrounded=false;
    }
   /* void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - new Vector3(0,boxSizeY-1,0), new Vector2(boxSizeX,boxSizeY));
    }*/
}
