using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LeverManager : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction Interact;
    public UnityEvent<bool> onPress;
    // true = on, false = off
    private bool state=true;
    private bool playerIsInside=false;
    void Awake()
    {
        Interact = InputSystem.actions.FindAction("Interact");
    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.CompareTag("Player")) playerIsInside=true;        
    }
    void OnTriggerExit2D()
    {
        playerIsInside=false;
    }
    void Update()
    {
        if (Interact.WasPressedThisFrame() && playerIsInside)
        {
            Debug.Log("Đã gạt!");
            onPress?.Invoke(state);
            state=!state;
        }
    }
}
