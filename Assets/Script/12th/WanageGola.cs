using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanageGola : MonoBehaviour
{
    public bool RedGoal;
    public bool BlueGoal;
    public bool GreenGoal;
    public GameObject WanagePrefab;
   private GameObject WanageAll;
    public bool Wanagepredestroy;
    WanageCountText wct;
    public GameObject WanageCountCanvas;
    public int WanageColorCount;
    public SpriteRenderer[] WanageImages;
    public ParticleSystem WanageRestartEffect;
    void Start()
    {
        wct= WanageCountCanvas.GetComponent<WanageCountText>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        WanageAll = collision.gameObject;
       
        Debug.Log(collision.gameObject);
        if (RedGoal == true)
        {
            if (collision.gameObject.tag == "WanageRed")
            {
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
        if (BlueGoal == true)
        {
            if (collision.gameObject.tag == "WanageBlue")
            {
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
        if (GreenGoal == true)
        {
            if (collision.gameObject.tag == "WanageGreen")
            {
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
       
        if (RedGoal == true)
        {
            if (other.gameObject.tag == "WanageRed")
            {
                Debug.Log(other.gameObject);
                wct.WanageCount++;
                WanageColorCount++;
                WanageImages[WanageColorCount-1].enabled = true;
                Destroy(other.gameObject);
                Wanagepredestroy = true;
                Instantiate(WanagePrefab, new Vector3(0.0f,-4.0f, 0.0f), Quaternion.identity);
                WanageRestartEffect.transform.position = new Vector3(0.0f, -4.0f, 0.0f);
                WanageRestartEffect.Play();
            }
        }
        if (BlueGoal == true)
        {
            if (other.gameObject.tag == "WanageBlue")
            {
                Debug.Log(other.gameObject);
                Wanagepredestroy = true;
                wct.WanageCount++;
                WanageColorCount++;
                WanageImages[WanageColorCount - 1].enabled = true;
                Destroy(other.gameObject);
                Wanagepredestroy = true;
                Instantiate(WanagePrefab, new Vector3(0.0f, -4.0f, 0.0f), Quaternion.identity);
                WanageRestartEffect.transform.position = new Vector3(0.0f, -4.0f, 0.0f);
                WanageRestartEffect.Play();
            }
        }
        if (GreenGoal == true)
        {
            if (other.gameObject.tag == "WanageGreen")
            {
                Debug.Log(other.gameObject);
                wct.WanageCount++;
                WanageColorCount++;
                WanageImages[WanageColorCount - 1].enabled = true;
                Destroy(other.gameObject);
                Wanagepredestroy = true;
                Instantiate(WanagePrefab, new Vector3(0.0f, -4.0f, 0.0f), Quaternion.identity);
                WanageRestartEffect.transform.position = new Vector3(0.0f, -4.0f, 0.0f);
                WanageRestartEffect.Play();
            }
        }
    }
}
