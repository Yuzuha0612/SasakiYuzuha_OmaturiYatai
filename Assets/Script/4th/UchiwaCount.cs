using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UchiwaCount : MonoBehaviour
{
    public GameObject clickedUchiwa;
    public SpriteRenderer UchiwaIrust;
    public GameObject clickedUchiwa2;
    public AudioClip UchiwaSound;
    AudioSource audioSource;
    public GameObject UchiwaManagerObject;
    UchiwaCountManager UchiwaManager;
    public GameObject SyriumsAll;
 
   public float CurrentHP;
    public float OnOffNumber1;
    public float OnOffNumber2;
    public float OnOffNumber3;
    public float OnOffNumber4;
    public float OnOffNumber5;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //UchiwaManagerObject = GameObject.Find("UchiwaManager");
        UchiwaManager = UchiwaManagerObject.GetComponent <UchiwaCountManager>();
        clickedUchiwa2 = this.gameObject;
        
    }

    void Update()
    {
        StartCoroutine(UchiwaCoroutine());
        if (Input.GetMouseButtonDown(0))
        {
            //audioSource.PlayOneShot(UchiwaSound);
            clickedUchiwa = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedUchiwa = hit2d.transform.gameObject;
            }

            Debug.Log(clickedUchiwa);
        }

        if (clickedUchiwa == clickedUchiwa2)
        {
            //CurrentHP = CurrentHP + 1;
           
            UchiwaManager.UchiwaCountNumber++;
            clickedUchiwa2.SetActive(false);
            SyriumsAll.SetActive(true);
            // Destroy(this.gameObject);
        }

    }
    IEnumerator UchiwaCoroutine()
    {
        UchiwaIrust.enabled = true;
        yield return new WaitForSecondsRealtime(OnOffNumber1);
        UchiwaIrust.enabled = false;
        yield return new WaitForSecondsRealtime(OnOffNumber2);
        UchiwaIrust.enabled = true;
        yield return new WaitForSecondsRealtime(OnOffNumber3);
        UchiwaIrust.enabled = false;
        yield return new WaitForSecondsRealtime(OnOffNumber4);
        UchiwaIrust.enabled = true;
        yield return new WaitForSecondsRealtime(OnOffNumber5);
    }
}
