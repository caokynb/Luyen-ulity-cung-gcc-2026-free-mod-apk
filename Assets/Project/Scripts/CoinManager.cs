using System;
using UnityEngine;

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
}
