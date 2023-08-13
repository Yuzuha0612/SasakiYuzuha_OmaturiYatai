using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject FirstIlllust;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Biidama")
        {

            FirstIlllust.SetActive(false);
        }
    }
}
