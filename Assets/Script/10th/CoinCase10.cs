using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCase10 : MonoBehaviour
{
    public GameObject Coin;
    public SpriteRenderer Case;
    public GameObject OpenRedCapsel;
    public GameObject OpenBlueCapsel;
    public GameObject OpenYellowCapsel;
    public GameObject OpenGreenCapsel;
    public GameObject KeihinnSheep;
    public GameObject KeihinBom;
    public GameObject KeihinnHiyoko;
    public GameObject KeihinAzarasi;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "RedCapsel")
        {
            OpenRedCapsel.SetActive(true);
            KeihinBom.SetActive(true);
            Coin.SetActive(true);
            Case.enabled = false;
            Destroy(this.gameObject,10);
        }
        if (collider.gameObject.tag == "BlueCapsel")
        {
            OpenBlueCapsel.SetActive(true);
            KeihinnSheep.SetActive(true);
            Coin.SetActive(true);
            Case.enabled = false;
            Destroy(this.gameObject, 10);
        }
        if (collider.gameObject.tag == "YellowCapsel")
        {
            OpenYellowCapsel.SetActive(true);
            KeihinnHiyoko.SetActive(true);
            Coin.SetActive(true);
            Case.enabled = false;
            Destroy(this.gameObject, 10);
        }
        if (collider.gameObject.tag == "GreenCapsel")
        {
            OpenGreenCapsel.SetActive(true);
            KeihinAzarasi.SetActive(true);
            Coin.SetActive(true);
            Case.enabled = false;
            Destroy(this.gameObject, 10);
        }
    }
}
