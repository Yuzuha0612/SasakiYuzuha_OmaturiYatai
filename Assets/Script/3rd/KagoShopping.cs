using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KagoShopping : MonoBehaviour
{
    public Image Currot;
    public Image Potato;
    public Image Meet;
    public Image Onion;
    public Image Curryru;
    public Image SoySauce;
    public Image Sirataki;
    public GameObject WtitelineAll;

    public Text ClearText;
    public Text ClearGameoverText;
    public Image CurryFinish;
    public Image NikujagaFinish;

    public AudioClip FoodGetSound;
    public AudioClip ClearSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Currot.enabled == true && Potato.enabled == true && Meet.enabled == true && Onion.enabled == true && Curryru.enabled == true)
        {
            Debug.Log("ÉNÉäÉA!");
            ClearText.enabled = true;
            CurryFinish.enabled = true;
            WtitelineAll.SetActive(false);
            Time.timeScale = 0;
            //audioSource.PlayOneShot(ClearSound);
        }
        if (Currot.enabled == true && Potato.enabled == true && Meet.enabled == true && Onion.enabled == true && Sirataki.enabled == true)
        {
            ClearGameoverText.enabled = true;
            NikujagaFinish.enabled = true;
            WtitelineAll.SetActive(false);
            Time.timeScale = 0;
            //audioSource.PlayOneShot(ClearSound);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Currot")
        {
            Currot.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "Onion")
        {
            Onion.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "Potato")
        {
            Potato.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "Meet")
        {
            Meet.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "Curryru")
        {
            Curryru.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "SoySauce")
        {
            SoySauce.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
        if (collision.gameObject.tag == "Sirataki")
        {
            Sirataki.enabled = true;
            audioSource.PlayOneShot(FoodGetSound);
        }
    }
}
