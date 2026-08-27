using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float sizeX=5f,sizeY=5f,boxSizeX=1f,boxSizeY=1f,spacing=0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        
        float distFromZeroY=sizeY/2+spacing*(sizeY-1f)/2f+sizeY*((boxSizeY-1)/2f);
        Gizmos.color = Color.red;
        for(int i = 0; i < sizeY; i++)
        {   
            float distFromZeroX=sizeX/2+spacing*(sizeX-1f)/2f+sizeX*((boxSizeX-1)/2f);
            for(int j = 0; j < sizeX; j++)
            {
                Gizmos.DrawWireCube(new Vector2(j-distFromZeroX+boxSizeX/2,i-distFromZeroY+boxSizeY/2), new Vector2(boxSizeX,boxSizeY));
                distFromZeroX-=spacing+boxSizeX-1;
            }
            distFromZeroY-=spacing+boxSizeY-1;
        }
    }
}
