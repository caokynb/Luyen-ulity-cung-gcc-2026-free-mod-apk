using UnityEngine;

public class rayTest : MonoBehaviour
{

    private Vector2 rayOrigin; //Bắt đầu
	private Vector2 rayDir = Vector2.up; // Hướng
	private float dist=5; //Khoảng cách
	private LayerMask targetLayer; //LayerMask

    void Update()
    {
        rayOrigin = transform.position;
        CheckRay();
    
    }
    void CheckRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDir, dist); //Vẽ một ray
        Debug.DrawRay(rayOrigin,rayDir*5,Color.red); // Vẽ một ray Debug có thể thấy được
        if (hit.collider != null)
        {
            Debug.Log("Đã đụng gì đó!");
        }
    }

}
