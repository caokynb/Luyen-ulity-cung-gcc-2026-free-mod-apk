using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.collectedCoins+=1;
            Debug.Log($"Đã nhặt 1 xu!, hiện tại có {CoinManager.collectedCoins} xu!");
            //Instantiate(coinPrefab,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
