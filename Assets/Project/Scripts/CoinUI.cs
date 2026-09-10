using UnityEngine;

public class CoinUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CoinManager.startingCoins+=CoinUpdateUI;
    }

    void OnDisable()
    {
        CoinManager.startingCoins-=CoinUpdateUI;
    }

    void CoinUpdateUI(int n)
    {
        CoinManager.collectedCoins+=n;
        Debug.Log($"Game đã bắt đầu, hiện tại có {CoinManager.collectedCoins} xu!");
    }
}
