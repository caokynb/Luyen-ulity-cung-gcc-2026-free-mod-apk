using UnityEngine;

public class Phuc : MonoBehaviour
{
    private int direction=-1;
    [SerializeField] public float moveSpeed=5f;
    [SerializeField] public Rigidbody2D rb;
    void Update()
    {
        rb.linearVelocityX=moveSpeed*direction;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        direction*=-1;
    }
}
