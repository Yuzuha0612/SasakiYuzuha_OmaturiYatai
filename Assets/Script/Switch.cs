using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject FirstIlllust;
    public GameObject IllustChange;
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;
    AudioSource audioSource;
    public AudioClip SwitchSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
            audioSource.PlayOneShot(SwitchSE);
            IllustChange.SetActive(true);
            FirstIlllust.SetActive(false);
            Ground1.SetActive(true);
            Ground2.SetActive(true);
            Ground3.SetActive(false);
        }
    }
}
