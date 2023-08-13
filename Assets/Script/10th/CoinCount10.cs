using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount10 : MonoBehaviour
{
    public GameObject GunObj;
    public RotShooter RS;
    void Start()
    {
        GunObj = GameObject.Find("Gun");
        RS = GunObj.GetComponent<RotShooter>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            RS.CoinCount++;
            Destroy(this.gameObject);
        }
    }
    }
