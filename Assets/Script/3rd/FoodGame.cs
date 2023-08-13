using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGame : MonoBehaviour
{
    public GameObject[] FoodinKago;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            StartCoroutine(FoodCoroutine());
        }
    }
    IEnumerator FoodCoroutine()
    {
       
        FoodinKago[0].SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        FoodinKago[1].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        FoodinKago[2].SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        FoodinKago[3].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        FoodinKago[4].SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        FoodinKago[5].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        FoodinKago[6].SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        FoodinKago[7].SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        FoodinKago[8].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        FoodinKago[9].SetActive(true);
       // FoodinKago[10].SetActive(true);


    }
}
