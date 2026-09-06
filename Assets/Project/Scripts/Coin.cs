using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.collectedCoins+=1;
            Debug.Log($"Đã nhặt 1 xu!, hiện tại có {CoinManager.collectedCoins} xu!");
            Destroy(this.gameObject);
        }
    }
}
