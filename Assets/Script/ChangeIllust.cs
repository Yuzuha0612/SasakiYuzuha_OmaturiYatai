using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIllust : MonoBehaviour
{
    public GameObject FirstIlllust;
    public GameObject IllustChange;
    AudioSource audioSource;
    public AudioClip IceSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
            audioSource.PlayOneShot(IceSE);
            IllustChange.SetActive(true);
            FirstIlllust.SetActive(false);
        }
    }
}
