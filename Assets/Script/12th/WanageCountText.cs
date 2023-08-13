using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WanageCountText : MonoBehaviour
{
    public Text WanageText;
    public int WanageCount;
    public Text StartTextTitle;
    public float timeCount;  //timeCount 制限時間
    public Text StartText3;
    public Text StartText2;
    public Text StartText1;
    public Text StartText;
    public bool isStart;
    public Text StartTextFirst;
    public GameObject RetryButton;

    public AudioClip TimeCountSound;
    public AudioClip BGMSound;
    public Text GameoverText;
    AudioSource audioSource;
    public Text timeLabel;
    public Text GameclearText;

    void Start()
    {
        isStart = false;
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
        timeLabel.text = "残り" + timeCount.ToString("f0");
    }

    void Update()
    {

        if (isStart == false)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                StartCoroutine(ReadygoCoroutine12());
            }
        }
        if (isStart == true)
        {
            timeCount -= Time.deltaTime;
            timeLabel.text = "残り" + timeCount.ToString("f0");
            WanageText.text = "わなげの数：" + WanageCount;
        }
        if (timeCount < 0)
        {
            //0秒以下になったら
            //audioSource.PlayOneShot(GameOverSE);//ゲームオーバー効果音
            //「STAGE」というキーで、Int値の「StageNumber」を保存
            timeLabel.text = "残り 0";
            Time.timeScale = 0;
            GameclearText.enabled = true;
            GameclearText.text = "終了!\nあなたの得点は…\n" + WanageCount+"点!";
            RetryButton.SetActive(true);
        }

    }
    IEnumerator ReadygoCoroutine12()
    {
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
        Debug.Log("0");
        yield return new WaitForSecondsRealtime(0.5f);
        StartText.enabled = false;
        Time.timeScale = 1;
        audioSource.PlayOneShot(BGMSound);
        isStart = true;
    }
}