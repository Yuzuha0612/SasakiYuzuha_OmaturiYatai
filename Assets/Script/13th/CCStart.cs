using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCStart : MonoBehaviour
{
    public Text StartTextTitle;
    public float timeCount;  //timeCount 制限時間
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
    public Text GameoverText;
    AudioSource audioSource;
    public Text timeLabel;
    public Text GameclearText;

    private CCGameAdministrator ccga;
    public GameObject Administor;
    public GameObject WattameMain;
    private Wattaame wattame;
    public Text KnockNinjaT;
    public TrailRenderer WataemeLine;
    void Start()
    {
        ccga = Administor.GetComponent<CCGameAdministrator>();
        wattame = WattameMain.GetComponent<Wattaame>();
        isStart = false;
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
        timeLabel.text = "残り" + timeCount.ToString("f0");
        WataemeLine.enabled = false;
        //KnockNinjaT.text = "倒した数" + KnockNinja;
    }

    void Update()
    {

        if (isStart == false&&ccga.CCGS==CCGameAdministrator.CCGameStatus.ReadyGo)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                StartCoroutine(ReadygoCoroutine6());
            }
        }
        if (isStart == true)
        {
            timeCount -= Time.deltaTime;
            timeLabel.text = "残り" + timeCount.ToString("f0");
        }
        if (timeCount < 0)
        {
            //0秒以下になったら
            //audioSource.PlayOneShot(GameOverSE);//ゲームオーバー効果音
            //「STAGE」というキーで、Int値の「StageNumber」を保存
            timeLabel.text = "残り 0";
            Time.timeScale = 0;
            GameoverText.enabled = true;
            GameoverText.text = "営業終了!" + "\n" + "作ったわたあめは..." + "\n" +wattame.Wattamemake + "こ!";
            RetryButton.SetActive(true);
            ccga.CCGS = CCGameAdministrator.CCGameStatus.Result;
        }

    }
    IEnumerator ReadygoCoroutine6()
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
        WataemeLine.enabled = true;
        audioSource.PlayOneShot(BGMSound);
        ccga.CCGS = CCGameAdministrator.CCGameStatus.GameNormal;
        isStart = true;
    }
}