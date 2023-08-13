using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFloor : MonoBehaviour
{
    public float SpeadX;
    public float SpeadY;
    private Rigidbody2D rb;
    AudioSource audioSource;
    public AudioClip BoundSound;
    public bool TrueBoundSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
            Debug.Log("‰Á‘¬‚·‚é‚æ!");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(SpeadX, SpeadY));
            if (TrueBoundSound == true)
            {
                audioSource.PlayOneShot(BoundSound);
            }
        }
        
    }
}
