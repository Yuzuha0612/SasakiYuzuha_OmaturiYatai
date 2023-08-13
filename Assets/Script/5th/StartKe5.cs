using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartKe5 : MonoBehaviour
{
    public SpriteRenderer StartBackground;
    public Text StartTextTitle;
    //public Text timeLabel;
    public float timeCount;  //timeCount ��������
    public Text StartText3;
    public Text StartText2;
    public Text StartText1;
    public Text StartText;
    public bool isStart;
    public Text StartTextFirst;
    //public Text GameoverText;
    public GameObject RetryButton;

    public AudioClip TimeCountSound;
    public AudioClip BGMSound;
    public GameObject MoziAll;
    AudioSource audioSource;
    void Start()
    {
        isStart = false;
    }

    void Update()
    {
        if (isStart == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                StartCoroutine(ReadygoCoroutine5());
            }
        }
    }
    IEnumerator ReadygoCoroutine5()
    {
        MoziAll.SetActive(true);
        StartBackground.enabled=false;
        StartTextFirst.enabled = false;
        StartText3.enabled = true;
        //yield return new WaitForSecondsRealtime(0.5f);
        audioSource.PlayOneShot(TimeCountSound);
        Time.timeScale = 0;
        Debug.Log("3");
        yield return new WaitForSecondsRealtime(1.0f);
        StartText3.enabled = false;
        StartText2.enabled = true;
        Debug.Log("2");
        yield return new WaitForSecondsRealtime(1.0f);
        StartText2.enabled = false;
        StartText1.enabled = true;
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(1.0f);
        StartText1.enabled = false;
        StartText.enabled = true;
        isStart = true;
        Debug.Log("0");
        yield return new WaitForSecondsRealtime(0.5f);
        StartText.enabled = false;
        Time.timeScale = 1;
        audioSource.PlayOneShot(BGMSound);
        isStart = true;
    }
}