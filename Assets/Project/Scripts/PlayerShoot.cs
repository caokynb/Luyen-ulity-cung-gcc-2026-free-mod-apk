using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction ShootAction;
    public UnityEvent onShoot;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Transform playerTransform;
    [SerializeField] public static float shootRecoil=2f;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void Awake()
    {
        ShootAction = InputSystem.actions.FindAction("Shoot");
    }
    void Update()
    {
        if(ShootAction.WasPressedThisFrame() && CoinManager.collectedCoins>0)
        {
            onShoot?.Invoke();
        }
    }
}
