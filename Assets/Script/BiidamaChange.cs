using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiidamaChange : MonoBehaviour
{
    public SpriteRenderer WhiteBiidama;
    public SpriteRenderer BlueBiidama;
    public SpriteRenderer RedBiidama;
    public GameObject IceEffect;
    public GameObject FireEffect;
    AudioSource audioSource;
    public AudioClip FireSE;
    public AudioClip IceSE;
    public AudioClip WaterSE;
    //ビー玉の本来のBounceは、Friction0.4 Bounciness0
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Snow")
        {
            BlueBiidama.enabled=true;
            WhiteBiidama.enabled=false;
            RedBiidama.enabled=false;
            IceEffect.SetActive(true);
            FireEffect.SetActive(false);
            audioSource.PlayOneShot(IceSE);
        }
        if (other.gameObject.tag == "Candle")
        {
            BlueBiidama.enabled = false;
            WhiteBiidama.enabled = false;
            RedBiidama.enabled = true;
            IceEffect.SetActive(false);
            FireEffect.SetActive(true);
            audioSource.PlayOneShot(FireSE);
        }
        if (other.gameObject.tag == "Normal")
        {
            BlueBiidama.enabled = false;
            WhiteBiidama.enabled = true;
            RedBiidama.enabled = false;
            IceEffect.SetActive(false);
            FireEffect.SetActive(false);
            audioSource.PlayOneShot(WaterSE);
        }
       

    }
}
