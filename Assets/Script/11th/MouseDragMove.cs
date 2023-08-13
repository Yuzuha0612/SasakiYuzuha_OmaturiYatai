using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragMove : MonoBehaviour
{
    GameObject gameCtrl; //�@GameController��T���Ă��ē����ϐ���p�ӂ��܂�
    private bool gameOn;  //�@bool�^�̕ϐ�gameOn��p�ӂ��܂�
    private Vector2 targetPos;   //�@Vector2�^�̕ϐ�targetPos��p�ӂ��܂�
    private Vector2 lastMousePos;        //�@�u�Ō�Ƀ}�E�X�̂������ꏊ�v���i�[����ϐ���p�ӂ��܂�
    public GameObject dragPointObj;          //  dragPoint�̃I�u�W�F�N�g�������ϐ�
    public GameObject WataameAll;

    void Start()
    {
        gameCtrl = GameObject.Find("GameController");        //�@GameController�I�u�W�F�N�g��T���Ċi�[���܂�
      
    }
    void Update()
    {
            lastMousePos = Input.mousePosition;             // ���̃}�E�X�̈ʒu�̍��W���擾����
            targetPos = Camera.main.ScreenToWorldPoint(lastMousePos);  // �}�E�X�J�[�\���̈ʒu�����[���h���WtargetPos�ɕϊ����ē���܂�

            if (Input.GetMouseButton(0))// �����A�^�񒆂̃}�E�X�{�^���������ꂽ��i������������Ԃ��܂ށj
            {
                WataameAll.SetActive(true);
                dragPointObj.transform.position = targetPos;  //�@dragPointObj�̈ʒu��targetPos�̈ʒu�ɂ��܂�
                                                              // dragPointObj�I�u�W�F�N�g�𐶐����܂��i�}�E�X�J�[�\���̈ʒu�ɃX�v���C�g��u���čs���܂��j
                Instantiate(dragPointObj, targetPos, dragPointObj.transform.rotation);
        }else
        { 
            WataameAll.SetActive(false); 
        }
        
        //else return;
    }
}