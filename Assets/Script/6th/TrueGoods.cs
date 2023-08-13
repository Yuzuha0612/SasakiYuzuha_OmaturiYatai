using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueGoods : MonoBehaviour
{
    public GameObject RedBookInKago;
    public GameObject DrinkSparkInKago;
    public GameObject KumaInKago;
    public GameObject RedBook1;
    public GameObject RedBook2;
    public GameObject RedBook3;
    public GameObject DrinkSpark;
    public GameObject DrinkSpark1;
    public GameObject DrinkSpark2;
    public GameObject DrinkSpark3;
    public GameObject Kuma;
    public GameObject Kuma1;
    public GameObject Kuma2;
    public GameObject Kuma3;
    public Image RedBookImage;
    public Image DrinkSparkImage;
    public Image KumaImage;
    public Text ClearText;
    public ParticleSystem GetEffect1;
    public ParticleSystem GetEffect2;
    public ParticleSystem GetEffect3;
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
            if (this.gameObject.tag == "RedBook")
            {
                GetEffect1.Play();
                RedBookInKago.SetActive(true);
               Kuma.SetActive(true);
                Kuma1.SetActive(true);
                Kuma2.SetActive(true);
                Kuma3.SetActive(true);
                RedBook1.SetActive(false);
                RedBook2.SetActive(false);
                RedBook3.SetActive(false);
                RedBookImage.enabled = false;
                KumaImage.enabled = true;
                collision.rigidbody.velocity = Vector3.zero;
                collision.rigidbody.isKinematic = true;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
           
            if (this.gameObject.tag == "Bear")
            {
                GetEffect3.Play();
                KumaInKago.SetActive(true);
                DrinkSpark.SetActive(true);
                DrinkSpark1.SetActive(true);
                DrinkSpark2.SetActive(true);
                DrinkSpark3.SetActive(true);
                Kuma.SetActive(false);
                Kuma1.SetActive(false);
                Kuma2.SetActive(false);
                Kuma3.SetActive(false);
                KumaImage.enabled = false;
                DrinkSparkImage.enabled = true;
                collision.rigidbody.velocity = Vector3.zero;
                collision.rigidbody.isKinematic = true;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            if (this.gameObject.tag == "SprkringDrink")
            {
                GetEffect2.Play();
                DrinkSparkInKago.SetActive(true);
                ClearText.enabled = true;
                collision.rigidbody.velocity = Vector3.zero;
                collision.rigidbody.isKinematic = true;
                Time.timeScale = 0;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
