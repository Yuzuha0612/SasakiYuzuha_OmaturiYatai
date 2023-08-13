using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm7 : MonoBehaviour
{
    private float heightPos;
    private bool turnPoint;
    void Start()
    {
        heightPos = 0;
        turnPoint = false;
    }

    void Update()
    {
        if (transform.localScale.x > 5.0f)
        {
            turnPoint = true;
        }
        else if (transform.localScale.x < 0.1f)
        {
            turnPoint = false;
        }

        if (!turnPoint)
        {
            transform.localScale = new Vector3(heightPos,0.2f, 1);
            heightPos += 0.1f;
        }
        if (turnPoint)
        {
            transform.localScale = new Vector3(heightPos,0.2f, 1);
            heightPos -= 0.1f;
        }
    }
}
