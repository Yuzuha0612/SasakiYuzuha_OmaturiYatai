using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBear : MonoBehaviour
{
    WhiteBear Wbear;
    public GameObject WhiteBearUI;
    public SpriteRenderer PandaDish;
    public SpriteRenderer PandaDishBroke;
    AudioSource audioSource;
    public AudioClip PandaDIshBrokeSE;
    public ScrollSprite ss13;
    public CircleCollider2D PandaDishCollider;
    void Start()
    {
        Wbear = WhiteBearUI.GetComponent<WhiteBear>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dangan")
        {
            audioSource.PlayOneShot(PandaDIshBrokeSE);
            PandaDish.enabled = false;
            ss13.enabled = false;
            PandaDishCollider.enabled = false;
            PandaDishBroke.enabled = true;
            Destroy(collision.gameObject);
            Wbear.WhiteBearHP--;
    }
    }
}
