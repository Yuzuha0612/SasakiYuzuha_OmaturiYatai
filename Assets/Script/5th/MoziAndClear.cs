using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoziAndClear : MonoBehaviour
{
    public Image  MoziText;
    void Start()
    {
        
    }

    void Update()
    {
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LoveLetter")
        {
            MoziText.enabled = true;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

}
