using UnityEngine;
public class LayerMaskTest : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer; //chọn layer trong inspector luôn

    
    void Start()
    {
        targetLayer = LayerMask.GetMask("Ground"); // Hoặc có thể gọi hẳn tên ra
    }
    void Update()
    {
        
    }
}
