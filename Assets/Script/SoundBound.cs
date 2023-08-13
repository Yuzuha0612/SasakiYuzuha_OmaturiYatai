using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip BoundSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
                audioSource.PlayOneShot(BoundSound);
        }

    }
}
