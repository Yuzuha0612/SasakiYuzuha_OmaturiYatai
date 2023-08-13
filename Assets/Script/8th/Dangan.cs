using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangan : MonoBehaviour
{
   
    void Start()
    {

        StartCoroutine(DanganCoroutine());
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bear")
        {
            Destroy(this.gameObject);
        }
             if (collision.gameObject.tag == "NinjaEnemy")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "ArrowEnemy")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator DanganCoroutine()
    {
        yield return new WaitForSecondsRealtime(10.0f);
        Destroy(this.gameObject);
    }
}
