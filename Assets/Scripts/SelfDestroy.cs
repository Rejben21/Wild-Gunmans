using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
