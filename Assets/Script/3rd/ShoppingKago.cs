using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingKago : MonoBehaviour
{
    public GameObject clickedShoppingKago;
    public GameObject ShoppingKago01;
    public GameObject ShoppingKago02;
    public GameObject ShoppingKago03;
    public GameObject ShoppingKago01Null;
    public GameObject ShoppingKago02Null;
    public GameObject ShoppingKago03Null;

    public AudioClip KagoSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(KagoSound);
            clickedShoppingKago = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedShoppingKago = hit2d.transform.gameObject;
            }

            Debug.Log(clickedShoppingKago);
        }
        if(clickedShoppingKago == ShoppingKago01Null)
        {
            ShoppingKago01.SetActive(true);
            ShoppingKago02.SetActive(false);
            ShoppingKago03.SetActive(false);
        }
        if (clickedShoppingKago == ShoppingKago02Null)
        {
            ShoppingKago01.SetActive(false);
            ShoppingKago02.SetActive(true);
            ShoppingKago03.SetActive(false);
        }
        if (clickedShoppingKago == ShoppingKago03Null)
        {
            ShoppingKago01.SetActive(false);
            ShoppingKago02.SetActive(false);
            ShoppingKago03.SetActive(true);
        }
    }
}
