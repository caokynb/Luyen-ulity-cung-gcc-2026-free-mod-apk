using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    public InputActionAsset InputActions;
    private InputAction MoveAction;   
    private InputAction JumpAction;
    private InputAction SwapAction;
    public float walkSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckDistance=1f;
    public float boxSizeX=1f;
    public float boxSizeY=1f;
    public float castDist=1f;
    private bool isRecoiled=false;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        SwapAction = InputSystem.actions.FindAction("SwapPlayer");
    }
    void Update()
    {   
        JumpCheck();
        Flip();
        if(isRecoiled) return;
        rb.linearVelocityX = walkSpeed * MoveAction.ReadValue<float>();
    }

    void JumpCheck()
    {
        RaycastHit2D touched = Physics2D.BoxCast(transform.position - new Vector3(0,boxSizeY-1,0),new Vector2(boxSizeX,boxSizeY),0f,Vector2.zero,castDist,groundLayer);
        if(JumpAction.ReadValue<float>() != 0 && touched.collider!=null) rb.linearVelocityY = jumpForce;
    }
    public void Recoil()
    {
        StartCoroutine(RecoilRoutine());
    }

    void Flip()
    {
        Vector3 currentDir=transform.localScale;
        if(MoveAction.ReadValue<float>()>0) currentDir.x=1;
        else if(MoveAction.ReadValue<float>()<0) currentDir.x=-1;
        transform.localScale=currentDir;
    }
    private IEnumerator RecoilRoutine()
    {
        isRecoiled = true;
        rb.linearVelocityX = -Mathf.Sign(transform.localScale.x)*PlayerShoot.shootRecoil;
        yield return new WaitForSeconds(0.15f);
        isRecoiled = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - new Vector3(0,boxSizeY-1,0), new Vector2(boxSizeX,boxSizeY));
    }

    public void Log()
    {
        Debug.Log(gameObject.name);
    }
}
