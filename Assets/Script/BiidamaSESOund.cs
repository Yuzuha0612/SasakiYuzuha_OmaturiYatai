using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiidamaSESOund : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip WaterIceSE;
    public AudioClip SwitchSE;
    public AudioClip IceSE;
    public AudioClip GoalSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            audioSource.PlayOneShot(WaterIceSE);
        }
        if (collision.gameObject.tag == "Switch")
        {
            audioSource.PlayOneShot(SwitchSE);
        }
        if (collision.gameObject.tag == "Goal")
        {
            audioSource.PlayOneShot(GoalSE);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ice")
        {
            audioSource.PlayOneShot(IceSE);
        }

    }
}
