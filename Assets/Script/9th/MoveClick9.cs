using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveClick9 : MonoBehaviour
{

    private Vector2 targetPos;  			//�@Vector2�^�̕ϐ�targetPos��p�ӂ��܂�
    public float power;                 //�@float�^�̕ϐ� power��p�ӂ��܂�
    private Vector2 clickPos;		                       //    �N���b�N�������A�����W���i�[����Vector�Q�^�̕ϐ���p�ӂ��܂�
    public GameObject clickPoint;           //�@�N���b�v�����ꏊ�ɕ\������GameObject���i�[����ϐ���p�ӂ��܂�

    public bool isKunoitiRun;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))�@�@//�@�����}�E�X�́umiddle�{�^���v�������ꂽ��E�E�@�@�i�E�{�^���Ȃ�i�P�j�A���{�^���Ȃ�i�O�j�Ƃ��܂��j
        {
            Debug.Log(targetPos);
            //�@clickPoint�O���t�B�b�N���\���ɂ��܂��i���̈ړ��ꏊ�ɕ\�������邽�߁A��U�����܂��j
            clickPoint.SetActive(false);
            clickPos = Input.mousePosition; 				//�@ Vector�Q�Ń}�E�X�J�[�\���̈ʒu���W���擾����
            targetPos = Camera.main.ScreenToWorldPoint(clickPos);       // �}�E�X�J�[�\���̈ʒu�����[���h���W�ɕϊ�����

            //�@�Q�[���I�u�W�F�N�gclickPoint�O���t�B�b�N�̈ʒu�ɃN���b�N���ꂽ�ʒu�����܂��@(position��Vector3�^�ł����A�ÖٓI�ɃL���X�g���Ă���܂�)
            clickPoint.transform.position = targetPos;
            clickPoint.SetActive(true);                                 //�@clickPoint�̃O���t�B�b�N�����̒n�_�ɕ\�����܂�
            isKunoitiRun = true;

        }
            //�@���̃I�u�W�F�N�g��position�̒l�ɁAtargetPos�̈ʒu�܂ŁA�⊮���Ȃ��疈�t���[��power�ϐ��̒l�����A
            //�@�������ʒu�����������Ă����܂�
 �@�@transform.position = Vector2.Lerp(transform.position, targetPos, power);

            //�@targetPos�̏[���߂��i����0.2�ȓ��Ȃ�j�܂Ŗ{�̂��ړ��ł�����E�E�E�@
            //�@�iVector3�^��Vector2�^�ł͌v�Z���ł��Ȃ��̂ŁA�@targetPos�̑O�ɁiVector3�j�Ə�����Vector3�^�ɕύX�L���X�g���܂��@
            //�@sqrMagnitude�̓x�N�g����2�悵�đ傫���̒l���o���֐��ł��j
            if ((transform.position - (Vector3)targetPos).sqrMagnitude <= 0.2f)
            {
                clickPoint.SetActive(false);                      //�@clickPoint�O���t�B�b�N�������܂�
            isKunoitiRun = false;
            }
    }
}
    


