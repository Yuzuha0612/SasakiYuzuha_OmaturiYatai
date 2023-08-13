using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove10 : MonoBehaviour
{
    float enePos;                //enemy�̉��ړ��̊J�n�ʒu�����߂郉�W�A���l������ϐ���p�ӂ��܂�
    public GameObject bullet;

    void Start()
    {
        enePos = Random.Range(0, Mathf.PI);  //�ϐ�enePos�ɁA�O����3.14�iMathf.PI�͉~�������o���֐��j�̃����_���l�����܂�
        InvokeRepeating("EneShot", 1.0f, 3.0f);  //EneShot�֐���InvokeRepeating��3�b�����ɌĂяo�������܂�
    }

    void FixedUpdate()
    {    //�I�u�W�F�N�g�̈ʒu���疈�t���[���Ay���̒l��Time.deltaTime�������炵�����܂�
         //�@x�̒l�́A�o�߂����t���[������0�C05���������l�ɁA�����_���œ���ꂽ�l�𑫂��āACos�̒l�����߁A���̐U���𒲐����A���t���[���̈ʒu�����߂܂�
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount * 0.05f + enePos) * 0.05f, Time.deltaTime, 0f);
    }

    void EneShot() 	 //enemy����e�𔭎˂���֐��uEneShot()�v�����܂�
    {
        Instantiate(bullet, transform.position, transform.rotation);   //bullet�Ɋi�[���ꂽPrefab�����̃I�u�W�F�N�g�̈ʒu�ɐ������܂�
    }
}

