using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target10th : MonoBehaviour
{
    public GameObject OpenRedCapsel;
    public GameObject OpenBlueCapsel; 
    public GameObject OpenYellowCapsel;
    public GameObject OpenGreenCapsel;
    public GameObject KeihinnSheep;
    public GameObject KeihinBom;
    public GameObject KeihinnHiyoko;
    public GameObject KeihinAzarasi;
    public SpriteRenderer TargetSprite;

    void Start()
    {
        
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RedCapsel")
        {
            OpenRedCapsel.SetActive(true);
            KeihinBom.SetActive(true);
            Destroy(OpenRedCapsel,2);
            TargetSprite.enabled = false;
            //Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "BlueCapsel")
        {
            OpenBlueCapsel.SetActive(true);
            KeihinnSheep.SetActive(true);
            Destroy(OpenBlueCapsel,2);
            TargetSprite.enabled = false;
            //Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "YellowCapsel")
        {
            OpenYellowCapsel.SetActive(true);
            KeihinnHiyoko.SetActive(true);
            Destroy(OpenBlueCapsel, 2);
            TargetSprite.enabled = false;
            //Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "GreenCapsel")
        {
            OpenGreenCapsel.SetActive(true);
            KeihinAzarasi.SetActive(true);
            Destroy(OpenBlueCapsel, 2);
            TargetSprite.enabled = false;
            //Destroy(this.gameObject);
        }
    }
}
