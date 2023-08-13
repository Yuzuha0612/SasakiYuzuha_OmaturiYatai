using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBear : MonoBehaviour
{
    public Text WhiteBeartext;
    public float MaxHP;
    public float WhiteBearHP=3;
    public bool PandaGetSound;
    AudioSource audioSource;
    public AudioClip PandaGetBrokeSE;
    public ParticleSystem BrokeEffect;
    public ParticleSystem BrokeEffect1;
    public ParticleSystem BrokeEffect2;
    public GameObject Confetti;
    public GameObject ResultPanda;
    DanganRemain dr;
    void Start()
    {
        PandaGetSound = false;
        audioSource = GetComponent<AudioSource>();
        dr = ResultPanda.GetComponent<DanganRemain>();
    }

    void Update()
    {
        if (WhiteBearHP > 0)
        {
            WhiteBeartext.text = "����" + WhiteBearHP + "��ŃQ�b�g!";
        }
        else if(WhiteBearHP == 0)
        {
            if (PandaGetSound == false)
            {
                BrokeEffect.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                BrokeEffect.Emit(0);
                BrokeEffect1.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                BrokeEffect1.Emit(0);
                BrokeEffect2.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                BrokeEffect2.Emit(0);
                StartCoroutine(ConfettiCoroutine());
                audioSource.PlayOneShot(PandaGetBrokeSE);
                PandaGetSound = true;
                dr.PandaNuiGet = true;
            }
            WhiteBeartext.text = "�Q�b�g!!";
        }

    }
    IEnumerator ConfettiCoroutine()
    {
        yield return new WaitForSecondsRealtime(7.0f);
        Confetti.SetActive(false);
    }
}
