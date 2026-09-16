using UnityEngine;

public class Phuc : MonoBehaviour
{
    private int direction=-1;
    public int realHp=5;
    private int hp;
    [SerializeField] public float moveSpeed=5f;
    [SerializeField] public Rigidbody2D rb;
    void Awake()
    {
        hp=realHp;
    }
    void Update()
    {
        rb.linearVelocityX=moveSpeed*direction;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        direction*=-1;
    }
    public void TakeDamage(int damage)
    {
        hp-=damage;
        if(hp<=0){
            Debug.Log("Phúc đã chết!");
            Destroy(this.gameObject);
        }
        Debug.Log($"Đã bắn trúng Phúc! Máu còn {hp}");
    }
}
