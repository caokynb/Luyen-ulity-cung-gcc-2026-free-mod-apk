using System;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField] public CircleCollider2D cd;
    [SerializeField] public GameObject box;
    [SerializeField] public float timeDelay=3f;
    private float time;

    void Awake()
    {
        box.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        time=timeDelay;
        box.SetActive(true);
        Debug.Log("Phuc gay");
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(time>0) time-=Time.deltaTime;
        else box.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        box.SetActive(false);
    }
}
