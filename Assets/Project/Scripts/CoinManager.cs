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
        if(collectedCoins>0){
            collectedCoins-=1;
            Debug.Log($"Đã từ thiện cho Độ Mixi! hiện tại còn {collectedCoins} xu!");
        } 
        else
        {
            Debug.Log("Hổng còn xu nào!");
        }
    }
}
