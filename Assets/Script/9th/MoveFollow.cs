using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollow : MonoBehaviour
{
    private Vector2 targetPos;			 //�@Vector2�^�̕ϐ�targetPos��p�ӂ��܂�
    public float power;				 //�@float�^�̕ϐ� power��p�ӂ��܂�
    public bool xDir;				//�@�������Ɍ��肵�ē����������t���u�@bool�^�̕ϐ� xDir��p�ӂ��܂�
    public bool yDir;				//�@y�����Ɍ��肵�ē����������t���u�@bool�^�̕ϐ� yDir��p�ӂ��܂�
    private Vector2 oriPos;         //�@�n�܂������̃v���C���[�I�u�W�F�N�g�̈ʒu���i�[����ϐ� oriPos��p�ӂ��܂�

    private void Start()
    {
        if (xDir == true)				 //�@�����ϐ�xDir�Ƀ`�F�b�N�������ꂽ��E�E
        {
            oriPos.y = gameObject.transform.position.y;	 //�@�͂��܂�̈ʒu�̂����W�̒l��ϐ�oriPos�̂��l�ɓ���܂�
        }

        if (yDir == true)				 //�@�����ϐ�yDir�Ƀ`�F�b�N�������ꂽ��E�E
        {
            oriPos.x = gameObject.transform.position.x;  //�@�͂��܂�̈ʒu��x���W�̒l��ϐ�oriPos��x�l�ɓ���܂�
        }
    }
    void Update()
    {
        //�@�}�E�X�J�[�\���̈ʒu�����[���h���W�ɕϊ����āA�ϐ�targetPos�ɓ���܂�
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (xDir == true)			 //�@��Dir�Ƀ`�F�b�N������ꍇ�́E�E
        {
            targetPos.y = oriPos.y; 		 //�@targetPos�̂����̒l�ɁAoriPos��y���̒l�����܂�
        }

        if (yDir == true)			 //�@��Dir�Ƀ`�F�b�N������ꍇ�́E�E
        {
            targetPos.x = oriPos.x;		 //�@targetPos�̂����̒l�ɁAoriPos��x���̒l�����܂�
        }

        transform.position = Vector2.Lerp(transform.position, targetPos, power);

    }

}
