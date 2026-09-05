using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]  private Rigidbody2D rb;
    public InputActionAsset InputActions;
    private InputAction MoveAction;   
    private InputAction JumpAction;
    private InputAction AttackAction;
    public float walkSpeed = 5f;
    public float jumpForce = 5f;
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
        rb.linearVelocityX = walkSpeed * MoveAction.ReadValue<float>();
        if(JumpAction.ReadValue<float>() != 0) rb.linearVelocityY = jumpForce;
        if(AttackAction.WasPressedThisFrame()) Debug.Log("Tấn công");
    }
}
