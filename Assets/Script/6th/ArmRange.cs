using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRange : MonoBehaviour
{
    public bool ArmMaxRange;//�A�[���ő�
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RobotHand")
        {
            ArmMaxRange = true;
            /*Debug.Log(collision);
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.isKinematic = true;*/
        }
    }
    }
