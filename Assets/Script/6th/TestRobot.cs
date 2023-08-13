using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRobot : MonoBehaviour
{
    public int points;         	 //�@�S�[���ɓ����{�[���̐�
    GameObject gameCtrl;	//�@GameObject�^�̕ϐ�gameCtrl��p�ӂ��܂�
    RobotMouse scriptShooting;	//�@Shooting�X�N���v�g�^�̕ϐ�scriptShooting��p�ӂ��܂�
    public ParticleSystem explosion;�@//ParticleSystem�^�̕ϐ�explosion��p�ӂ��܂�

    private void Start()
    {
        gameCtrl = GameObject.Find("GameController");	�@�@�@//�@�hGameController�h�Ƃ������O��object��scene����T���ē���܂�
        
        scriptShooting = gameCtrl.GetComponent<RobotMouse>();  //�@GameController�I�u�W�F�N�g��Shooting�X�N���v�g���i�[���܂�
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")	�@�@�@�@�@�@�@�@�@ //�@�����A������������̂s������Player�Ȃ�΁E�E 
        {
            points -= 1;				�@�@�@�@ //�@point����1�������āA���̒l���|�C�����ɂ܂��߂��܂� 
            explosion.transform.position = other.transform.position;    //�@explosion�̃|�W�V������player�̃|�W�V���������܂�            �@�@
            explosion.Play();		�@�@�@�@ //�@explosion�G�t�F�N�g���Đ����܂��@explosion.Emit(1)���ƂP�����o�܂���

            if (points <= 0)				//�@����points�̒l���O�ȉ��Ȃ��
            {
                Destroy(this.gameObject);       //�@���̃Q�[���I�u�W�F�N�g��j�󂵂܂�         
            }
            else return;
        }
    }
}
