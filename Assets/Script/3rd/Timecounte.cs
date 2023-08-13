using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecounte : MonoBehaviour
{
    //カウントダウン、3,2,1,Startを入れたい(作成するものを表示させる)
    //
    public Text timeLabel;
    public float timeCount;  //timeCount 制限時間
    public Text StartText3;
    public Text StartText2;
    public Text StartText1;
    public Text StartText;
    public bool isStart;
    public Text StartTextFirst;
    public Text GameoverText;

    public AudioClip TimeCountSound;
    public AudioClip BGMSound;
    AudioSource audioSource;
    void Start()
    {
        timeLabel.text = "Time:" + timeCount; //fixapdate
        isStart = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            StartCoroutine(ReadygoCoroutine());
        }
        if (isStart == true)
        {
            timeCount -= Time.deltaTime;
            timeLabel.text = "Time:" + timeCount.ToString("0");
        }
        if (timeCount < 0)
        {
         //0秒以下になったら
         //audioSource.PlayOneShot(GameOverSE);//ゲームオーバー効果音
         //「STAGE」というキーで、Int値の「StageNumber」を保存
            timeLabel.text = "Time:0";
            Time.timeScale = 0;
            GameoverText.enabled = true;
        }
    }
    IEnumerator ReadygoCoroutine()
    {
        audioSource.PlayOneShot(TimeCountSound);
        StartTextFirst.enabled = false;
        Time.timeScale = 0;
        StartText3.enabled = true;
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
    }
}
