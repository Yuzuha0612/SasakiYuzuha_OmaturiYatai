using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount4t : MonoBehaviour
{
    //�J�E���g�_�E���A3,2,1,Start����ꂽ��(�쐬������̂�\��������)
    //
    public Text timeLabel;
    public float timeCount;  //timeCount ��������
    public Text StartText3;
    public Text StartText2;
    public Text StartText1;
    public Text StartText;
    public bool isStart;
    public Text StartTextFirst;
    public Text GameoverText;
    public GameObject RetryButton;

    public AudioClip TimeCountSound;
    public AudioClip BGMSound;
    AudioSource audioSource;
    void Start()
    {
        timeLabel.text = "�c��̃��C�u����:" + timeCount; //fixapdate
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
            timeLabel.text = "�c��̃��C�u����:" + timeCount.ToString("0") +"�b";
        }
        if (timeCount < 0)
        {
            //0�b�ȉ��ɂȂ�����
            //audioSource.PlayOneShot(GameOverSE);//�Q�[���I�[�o�[���ʉ�
            //�uSTAGE�v�Ƃ����L�[�ŁAInt�l�́uStageNumber�v��ۑ�
            timeLabel.text = "�c��̃��C�u����:0";
            Time.timeScale = 0;
            GameoverText.enabled = true;
            RetryButton.SetActive(true);
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
