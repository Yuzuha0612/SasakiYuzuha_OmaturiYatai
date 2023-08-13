using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WataameColor11 : MonoBehaviour
{
    public bool pinkWataame;
    public bool greenWataame;
    public bool blueWataame;
    public bool bluckWattame;
    public bool BWWattame;
    private CCGameAdministrator ccga;
    public GameObject Administor;
    Wattaame Wata;
    GameObject Gunall;
    void Start()
    {
        Gunall = GameObject.Find("Gun");
        Wata = Gunall.GetComponent<Wattaame>();
        Administor = GameObject.Find("GameAdministor");
        ccga = Administor.GetComponent<CCGameAdministrator>();
        StartCoroutine(DanganCoroutine());
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Wata.WataameCount++;
            if (pinkWataame == true)
            {
                Wata.PinkWataame = true;
                Wata.BlueWataame = false;
                Wata.GreenWataame = false;
                Destroy(this.gameObject);
            }
            if (blueWataame == true)
            {
                Wata.PinkWataame = false;
                Wata.BlueWataame = true;
                Wata.GreenWataame = false;
                Destroy(this.gameObject);
            }
            if (greenWataame == true)
            {
                Wata.PinkWataame = false;
                Wata.BlueWataame = false;
                Wata.GreenWataame = true;
                Destroy(this.gameObject);
            }
            if (bluckWattame == true)
            {
                Wata.PinkWataame = false;
                Wata.BlueWataame = false;
                Wata.GreenWataame = false;
                Wata.WataameCount--;
                Destroy(this.gameObject);
            }
            if (BWWattame == true)
            {
                if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameNormal)
                {
                    Wata.WattameBWCount++;
                    Destroy(this.gameObject);
                }
                if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameFever)
                {
                    Wata.PandaWataame = true;
                    Wata.WataameCount++;
                    Destroy(this.gameObject);
                }
            }
        }
    }
    IEnumerator DanganCoroutine()
    {
        yield return new WaitForSecondsRealtime(10.0f);
        Destroy(this.gameObject);
    }
}
