using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public InputActionAsset InputActions;   
    public InputAction coinDepleteAction;
    public UnityEvent coinDeplete;
    void OnEnable()
    {
        InputActions.FindActionMap("Player");
    }
    void Awake()
    {
        coinDepleteAction = InputSystem.actions.FindAction("DepleteCoin");
    }
    void Update()
    {
        if (coinDepleteAction.WasPressedThisFrame())
        {
            coinDeplete?.Invoke();
        }
    }
}
