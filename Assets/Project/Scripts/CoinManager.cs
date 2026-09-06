using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static int collectedCoins=0;

    void Awake()
    {
        collectedCoins=0;
        Debug.Log($"Xu hiện tại có {collectedCoins}");
    }
}
