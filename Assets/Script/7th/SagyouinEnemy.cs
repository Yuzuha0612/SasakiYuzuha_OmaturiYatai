using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SagyouinEnemy : MonoBehaviour
{
    public Slider HPRobot;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RobotHand")
        {
            HPRobot.value++;
        }
    }
 }
