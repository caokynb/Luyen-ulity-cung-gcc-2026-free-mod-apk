using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    public InputActionAsset InputActions;
    private InputAction MoveAction;   
    private InputAction JumpAction;
    private InputAction AttackAction;
    public float walkSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckDistance=1f;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
      //  InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        AttackAction = InputSystem.actions.FindAction("Attack");
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
        
    }

    void Update()
    {   
        JumpCheck();
        rb.linearVelocityX = walkSpeed * MoveAction.ReadValue<float>();
        if(AttackAction.WasPressedThisFrame()) Debug.Log("Tấn công");
    }

    void JumpCheck()
    {
        RaycastHit2D touched = Physics2D.Raycast(transform.position,Vector2.down,groundCheckDistance,groundLayer);
        Debug.DrawRay(transform.position,Vector2.down*groundCheckDistance,Color.red);
        if(JumpAction.ReadValue<float>() != 0 && touched.collider!=null) rb.linearVelocityY = jumpForce;
    }
}
