using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject FireGoal;
    public SpriteRenderer GoalObject;
    public GameObject ConfettiEffect;
    public GameObject FireEffect;
    public GameObject FireText;
    public SpriteRenderer BiidamaRed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
            collision.rigidbody.velocity = Vector3.zero;
            ConfettiEffect.SetActive(true);
            FireEffect.SetActive(true);
            FireText.SetActive(true);
            GoalObject.enabled = false;
            BiidamaRed.enabled = false;
            FireGoal.SetActive(true);
        }
    }
}
