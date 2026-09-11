using System;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public void Shoot()
    {
        if (CoinManager.collectedCoins > 0)
        {
            CoinManager.collectedCoins--;
            Instantiate(bulletPrefab,transform.position,Quaternion.identity);
            Debug.Log($"Đã bắn, còn {CoinManager.collectedCoins} xu!");
        } 
        else
        {
            Debug.Log("Hết xu!");
        }
        
    }
}
