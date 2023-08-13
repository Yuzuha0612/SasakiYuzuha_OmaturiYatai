using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearBoyGIrl : MonoBehaviour
{
    public Text MoziText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LoveLetter")
        {
            MoziText.enabled = true;
            Time.timeScale = 0;
            Destroy(other.gameObject);
        }
    }
}
