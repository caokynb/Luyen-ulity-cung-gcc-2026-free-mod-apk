using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed=5f;
    public int bulletDamage=1;
    public Rigidbody2D rb;
    private Transform playerTransform;
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObj.transform;
        rb.linearVelocityX=bulletSpeed*Mathf.Sign(playerTransform.localScale.x);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Đạn trúng: {collision.gameObject.name}");
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
