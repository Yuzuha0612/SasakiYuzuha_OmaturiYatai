using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMove : MonoBehaviour
{
    GameObject gameCtrl;         //�@GameController��T���Ă��ē����ϐ�gameCtrl��p�ӂ��܂�
    private bool gameOn; �@�@�@�@�@//�@bool�^�̕ϐ�gameOn��p�ӂ��܂�
    private Vector2 targetPos;  �@�@�@ //�@Vector2�^�̕ϐ�targetPos��p�ӂ��܂�
    public float power;     �@�@�@�@�@�@//�@float�^�̕ϐ� power��p�ӂ��܂�
    private Vector2 clickPos;       �@�@�@ //�@�u�Ō�Ƀ}�E�X�̂������ꏊ�v���i�[����ϐ���p�ӂ��܂�
    public GameObject smokeObj;      //�@���̃X�v���C�g������ϐ���p�ӂ��܂�
    public float waitTime = 0.2f; �@�@�@//�@�����o���܂ł̎��ԊԊu�ł�
    public GameObject exhaust;     �@  //�@���̃X�v���C�g���o���ꏊ�̃I�u�W�F�N�g�ł�
    public GameObject clickPoint;       //�@�N���b�v�����ꏊ�ɕ\������GameObject���i�[����ϐ���p�ӂ��܂�

    void Start()
    {
        gameCtrl = GameObject.Find("GameController"); //�@GameController�I�u�W�F�N�g��T���ĕϐ�gameCtrl�Ɋi�[���܂�

        StartCoroutine("SmokeObj");              //�@StartCoroutine�ŁA"SmokeObj"�֐����Ăяo���܂�
    }
    void Update()
    {
            if (Input.GetMouseButtonDown(0)) 	// �����A�E�̃}�E�X�{�^���������ꂽ��i������������Ԃ��܂ށj
            {
                //�@clickPoint�O���t�B�b�N���\���ɂ��܂��i���̈ړ��ꏊ�ɕ\�������邽�߁A��U�����܂��j
                clickPoint.SetActive(false);

                clickPos = Input.mousePosition; // ���̃}�E�X�̈ʒu�̍��W���擾����
                targetPos = Camera.main.ScreenToWorldPoint(clickPos);  // �}�E�X�J�[�\���̈ʒu�����[���h���W�ɕϊ�����

                //�@�Q�[���I�u�W�F�N�gclickPoint�O���t�B�b�N�̈ʒu�ɃN���b�N���ꂽ�ʒu�����܂�
                //�@(position��Vector3�^�ł����A�ÖٓI�ɃL���X�g���Ă���܂�)
                clickPoint.transform.position = targetPos;
                clickPoint.SetActive(true);                   //�@clickPoint�̃O���t�B�b�N�����̒n�_�ɕ\�����܂�
            }
        transform.position = Vector2.Lerp(transform.position, targetPos, power);
       
       // else return;�@�@�@�@�@�@�@ // �o�����Ă��ǂ��ł��p
    }

    IEnumerator SmokeObj() // ���𔭐�������R���[�`���ł�
    {
        while (true) // ���̂܂܉��x���������������ꍇ�Awhile(true)�Ə����܂�
        {
            //�@smokeObj��exhaust�̈ʒu�ɐ��������܂�
            Instantiate(smokeObj, exhaust.transform.position, smokeObj.transform.rotation);
            yield return new WaitForSeconds(waitTime);  //�@�ϐ�waitTime�̎��Ԃ����������ɖ߂�܂��uwhile(true)�v�Ƌ��Ɏg���܂�
        }
    }
}