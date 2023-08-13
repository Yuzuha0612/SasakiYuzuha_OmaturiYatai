using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public GameObject FirstIlllust;
    public GameObject IllustChange;
    AudioSource audioSource;
    public AudioClip IceSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      

        if (other.gameObject.tag == "Biidama")
        {
            audioSource.PlayOneShot(IceSE);
            FirstIlllust.SetActive(false);
            IllustChange.SetActive(true);
        }
    }
}
