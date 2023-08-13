using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSprite : MonoBehaviour
{
    public bool xDir;			//�@�������Ɉړ�����Ƃ��́A�����on�ɂ��܂�
    public bool yDir;			//�@y�����Ɉړ�����Ƃ��́A�����on�ɂ��܂�
    private Transform oriPos;		 //�@���̈ʒu���i�[���Ă����ϐ�
    private float xPos;			//�@x�����̒l���i�[���Ă����ϐ�
    private float yPos;			//�@y�����̒l���i�[���Ă����ϐ�
    public bool random = false;		//�@�����_���Ȉʒu�ɏo�����������ꍇ��on�ɂ��܂�
    public float xspriteSpeed = -0.05f;	//�@x�����̈ړ��X�s�[�h���i�[���Ă����ϐ�
    public float yspriteSpeed = -0.05f;	//�@y�����̈ړ��X�s�[�h���i�[���Ă����ϐ�

    void Start()
    {
        oriPos = this.transform;		//�@����x�����̈ړ��X�s�[�h���i�[���Ă����ϐ�
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ReadygoCoroutine8());
            
        }
            if (xDir == true)				 //�@��Dir�t���O��on�i�������Ɉړ��j�Ȃ�΁E�E
        {
            transform.Translate(xspriteSpeed, 0, 0);	 //�@Translate�֐��ł������ɕϐ�xspriteSpeed�̒l�������t���[���ړ������܂�
            if (transform.position.x < -10.0f)		 //�@�������̈ʒu���\10�ȉ��ɂȂ�����E�E
            {
                if (random == true)			 //�@�����āArandom�t���O��on�ɂȂ��Ă�����E�E
                {
                    yPos = Random.Range(-2.8f, 4.2f);		//�@��Pos�i�c�����j�̏o���ʒu���i�|�S�`�S�A�������͊e���ύX�j�̂ǂꂩ�ɂ��܂�
                }

                else if (random == false)			//�@�łȂ��āArandom�t���O��off�ɂȂ��Ă�����E�E
                {
                    yPos = oriPos.position.y;		 //�@��Pos�i�c�����j�̏o���ʒu�����Ƃ̈ʒu�ɂ��܂�
                }

                transform.position = new Vector3(10.0f, yPos, 0);�@�@//�@���̃I�u�W�F�N�g�̈ʒu���i10�A���ʒu�ϐ��l�A�O�j�ɃZ�b�g���܂�
            }
        }
        if (yDir == true)					 //�@yDir�t���O��on�i�c�����Ɉړ��j�Ȃ�΁E�E
        {
            transform.Translate(0f, yspriteSpeed, 0f);	 //�@Translate�֐���y�����ɕϐ�yspriteSpeed�̒l�������t���[���ړ������܂�
            if (transform.position.y < -10.0f)		 //�@����y�̈ʒu���\10�ȉ��ɂȂ�����E�E
            {
                if (random == true)			 //�@�����āArandom�t���O��on�ɂȂ��Ă�����E�E
                {
                    xPos = Random.Range(-10.0f, 10.0f);	 //�@xPos�i�c�����j�̏o���ʒu���i�|10�`10�A�������͊e���ύX�j�̂ǂꂩ�ɂ��܂�
                }
                else if (random == false)			 //�@�łȂ��āArandom�t���O��off�ɂȂ��Ă�����E�E
                {
                    xPos = oriPos.position.x;		 //�@xPos�i�������j�̏o���ʒu�����Ƃ̈ʒu�ɂ��܂�
                }
                transform.position = new Vector3(xPos, 10.0f, 0); //�@���̃I�u�W�F�N�g�̈ʒu���ix�ʒu�ϐ��l�A 10�A �O�j�ɃZ�b�g���܂�
            }
        }
      }
    IEnumerator ReadygoCoroutine8()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        xDir = true;
    }
    }
