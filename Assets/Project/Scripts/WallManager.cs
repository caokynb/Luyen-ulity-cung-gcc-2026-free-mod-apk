using System.Collections;
// using System.Numerics;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] public Vector3 moveTo;
    private Vector3 startPos;
    private Coroutine active;
    public float moveSpeed=2f;
    void Start()
    {
        startPos=transform.position;
    }
    public void OnLeverPressed(bool state)
    {
        if(active!=null) StopAllCoroutines();
        if(state) active=StartCoroutine(MoveWall(moveTo));
        else active=StartCoroutine(MoveWall(startPos));
    }
    private IEnumerator MoveWall(Vector3 target)
    {
        Vector3 currPos=transform.position;
        float dist = Vector3.Distance(currPos,target);
        float duration = dist/moveSpeed;
        float elapsed=0f;
        while (elapsed < duration)
        {
            elapsed+=Time.deltaTime;
            float t=elapsed/duration; //0 -> 1
            transform.position=Vector3.Lerp(currPos,target,t);
            yield return null;
        }
    }
}
