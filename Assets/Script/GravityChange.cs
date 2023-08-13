
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 LocalGravity;
    void Start()
    {
       
    }

    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Biidama")
        {
           // Physics.gravity = new Vector3(0, 10,0);
            
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("èdóÕîΩì]!");
            rb.gravityScale = 0;
            rb.gravityScale = -1;
            /*
            Vector2 myGravity = new Vector2(0, 9.81f * 2);
            rb.AddForce(myGravity);*/

        }
    }
}
