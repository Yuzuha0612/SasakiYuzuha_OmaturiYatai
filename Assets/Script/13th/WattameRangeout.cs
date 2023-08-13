using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WattameRangeout : MonoBehaviour
{
    public BoxCollider2D Wobj;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Wobj.enabled = true;
            Debug.Log("‚í‚½‚ ‚ß‹@");
        }
    }
}
