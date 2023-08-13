using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public GameObject Biidama1;
    public GameObject Superball1;
    public bool CupRotate;
    public bool CupRotateStart;
    public Vector3 CuptfMax;
    private Transform Cuptf;
    public float rotationSpeed = 120f;
    public float CupRotateTime;
    public Camera FirstCamera;
    public Camera SecondCamera;
    public AudioClip BoundSound;
    AudioSource audioSource;
    void Start()
    {
    Cuptf = this.gameObject.GetComponent<Transform>();
    audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        if (CupRotate == true)
        {
            
            Cuptf.Rotate(0, 0, 2.0f);
            Biidama1.SetActive(false);
           if (this.gameObject.transform.localEulerAngles.z > 120)
            {
                CupRotate = false;
                Cuptf.Rotate(0, 0, 0);
                Superball1.SetActive(true);
                FirstCamera.enabled = false;
                SecondCamera.enabled = true;
            }
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            CupRotate = false;
            Cuptf.Rotate(0, 0, 0);
            Superball1.SetActive(true);
            FirstCamera.enabled = false;
            SecondCamera.enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Biidama")
        {
            audioSource.PlayOneShot(BoundSound);
            CupRotate = true;
        }
    }

    void CupChangeSuperBall()
    {

    }
    IEnumerator CupRotateCoroutine()
    {
        CupRotate = true;
        yield return new WaitForSecondsRealtime(CupRotateTime);
        Cuptf.Rotate(0, 0, 0);
        CupRotate = false;
        Superball1.SetActive(true);

    }
}
