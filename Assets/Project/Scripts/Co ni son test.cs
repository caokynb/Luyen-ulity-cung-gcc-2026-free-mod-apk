using UnityEngine;

public class Conisontest : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D cd;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Đã vào!");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Đã xuất!");
    }
}
