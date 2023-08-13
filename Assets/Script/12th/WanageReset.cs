using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanageReset : MonoBehaviour
{
    public GameObject WanagePrefab;
    public int WanageBounceCount;
    public ParticleSystem WanageRestartEffect;
    void Start()
    {
        
    }
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (WanageBounceCount > 3)
        {
            Destroy(collision.gameObject);
        }
            if (collision.gameObject.tag == "Wanage")
        {
            WanageBounceCount++;
            if (WanageBounceCount > 3)
            {
                Destroy(collision.gameObject);
                Instantiate(WanagePrefab, new Vector3(0.0f, -4.0f, 0.0f), Quaternion.identity);
                WanageRestartEffect.transform.position = new Vector3(0.0f, -4.0f, 0.0f);
                WanageRestartEffect.Play();
                WanageBounceCount = 0;
            }
        }
    }

    }
