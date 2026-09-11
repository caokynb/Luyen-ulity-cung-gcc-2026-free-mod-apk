using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CoinManager : MonoBehaviour
{
 
    public static int collectedCoins=0;
    private int coinStart=5;
    public static Action<int> startingCoins;

    void Awake()
    {
        collectedCoins=0;
        startingCoins?.Invoke(coinStart);
    }
    public void DepleteCoin()
    {
        collectedCoins+=8;
        Debug.Log($"Đã nạp thêm xu! hiện tại còn {collectedCoins} xu!");
    }
}
