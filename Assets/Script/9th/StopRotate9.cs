using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotate9 : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
