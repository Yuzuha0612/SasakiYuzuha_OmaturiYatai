using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keihinn : MonoBehaviour
{
    public Slider HPGift;
    public float MaxHP;
    public GameObject HPObject;
    AudioSource audioSource;
    public AudioClip KeihinGetSE;
    public bool KeihinBox;
    public bool KeihinBear;
    public GameObject DanganFinish;
    DanganRemain dr;
    void Start()
    {
        dr = DanganFinish.GetComponent<DanganRemain>();
        HPGift.maxValue = MaxHP;
        HPGift.value = MaxHP;
        HPObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (HPGift.value == 0)
        {
            if (KeihinBox == true)
            {
                dr.BoxSnack++;
                Destroy(this.gameObject);
            }
            if (KeihinBear == true) {
                dr.BearNui++;
                Destroy(this.gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dangan")
        {

            audioSource.PlayOneShot(KeihinGetSE);
            StartCoroutine(HPSlider2Coroutine());
            HPGift.value--;
        }
    }
    IEnumerator HPSlider2Coroutine()
    {
        HPObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5.0f);
        HPObject.SetActive(false);
    }

}
