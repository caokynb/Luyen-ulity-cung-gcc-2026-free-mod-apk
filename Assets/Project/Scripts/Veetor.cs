using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Veetor : MonoBehaviour
{
    [SerializeField] private float sizeX=10f;
    [SerializeField] private float sizeY=10f;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255,0,0);
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                Gizmos.DrawWireCube(new Vector2(i-sizeX/2,j-sizeY/2), Vector3.one);
            }
        }
        
    }
}
