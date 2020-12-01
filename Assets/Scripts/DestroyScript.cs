using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float destroyTime = 10f; 
    
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
