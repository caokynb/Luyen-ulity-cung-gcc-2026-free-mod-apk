using UnityEngine;

public class Zombie : MonoBehaviour
{
    public StateMachine StateMachine {get; private set;}
    [field:SerializeField] public Animator anim {get; private set;}
    [field:SerializeField] public Rigidbody2D rb {get; private set;}
    [field:SerializeField] public BoxCollider2D cd {get; private set;}
    [field:SerializeField] public BoxCollider2D playerCd {get; private set;}
    [field:SerializeField] public CircleCollider2D findArea {get; private set;}
    public IdleStateZombie IdleState {get; private set;}
    public SearchingState SearchingState {get; private set;}
    public FollowState FollowState {get; private set;}
    [field:SerializeField] public PlayerMovement player {get; private set;}
    [field:SerializeField] public float walkSpeed {get; private set;}
    [field:SerializeField] public float maxWalkTime {get; private set;}
    private void Awake()
    {
        StateMachine = new StateMachine();
        IdleState = new IdleStateZombie(this);
        SearchingState = new SearchingState(this);
        FollowState = new FollowState(this);
        maxWalkTime=Random.Range(maxWalkTime-4,maxWalkTime);
    }

    private void Start()
    {
        Physics2D.IgnoreCollision(cd,playerCd,true);
        StateMachine.ForceSetState(IdleState);
    }

    private void Update()
    {
        StateMachine.Tick();
        Flip();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) StateMachine.ChangeState(FollowState);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) StateMachine.ChangeState(IdleState);
    }
}
