using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalseGoods : MonoBehaviour
{
    public Text GameOverText;
    public GameObject Retrybutton;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RobotHand")
        {
            GameOverText.enabled = true;
            Retrybutton.SetActive(true);
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.isKinematic = true;
            Time.timeScale = 0;
        }
    }
}
