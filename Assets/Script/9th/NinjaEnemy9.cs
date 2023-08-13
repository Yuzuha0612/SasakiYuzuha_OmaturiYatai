using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaEnemy9 : MonoBehaviour
{
    public Slider HPNinja;
    public float MaxHP;
    public GameObject HPObject;
    public Slider HPPlayer;
    StartCountdown6 SC6;
    public GameObject PlayerNinja;
    void Start()
    {
        HPNinja.maxValue = MaxHP;
        HPNinja.value = MaxHP;
        HPObject.SetActive(false);
       SC6 = PlayerNinja.GetComponent<StartCountdown6>();
    }

    void Update()
    {

        if (HPNinja.value == 0)
        {
            SC6.KnockNinja++;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dangan")
        {
            StartCoroutine(HPSlider2Coroutine());
            HPNinja.value--;
        }
        if (collision.gameObject.tag == "Player")
        {
            HPPlayer.value--;
        }
    }
    IEnumerator HPSlider2Coroutine()
    {
        HPObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5.0f);
        HPObject.SetActive(false);
    }
}
