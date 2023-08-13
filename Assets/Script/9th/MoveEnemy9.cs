using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy9 : MonoBehaviour
{
    public GameObject enemy; //�@�G�l�~�[�̃I�u�W�F�N�g������ϐ���p�ӂ��܂�
    private Vector2 enePos; //�@���݂̃|�W�V�������i�[����ϐ���p�ӂ��܂�
    private Vector3 targetPos; //�@Player�I�u�W�F�N�g�̃|�W�V�������i�[����ϐ���p�ӂ��܂�
    private float rad; //�@�����������̃��W�A�����i�[����ϐ���p�ӂ��܂�
    public float speed;      //�@�G�l�~�[�̈ړ����x(������l)���i�[����ϐ���p�ӂ��܂�
    public float addSpeed;       //�@�ăZ�b�g���ɑ�����鑬�x������ϐ���p�ӂ��܂�
    public GameObject playerObj;              // player�̈ʒu���i�[����GameObject�^�̕ϐ�playerPos��p�ӂ��܂� 

    MoveClick9 MoveClick9Sc;
    void Start()
    {
        //�@�ϐ�targetPos�Ƀv���C���[�I�u�W�F�N�g���̈ʒu�f�[�^��T���ē���܂�
        targetPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        //�@�ڕW�ƂȂ�I�u�W�F�N�g�̂����W�̍���x���W�̍���p���āA����2�̐��̍��p�x�̃��W�A�������߂܂�
        rad = Mathf.Atan2(targetPos.y - enemy.transform.position.y, targetPos.x - enemy.transform.position.x);
        MoveClick9Sc = playerObj.GetComponent<MoveClick9>();
    }
    void FixedUpdate()
    {
        if (MoveClick9Sc.isKunoitiRun == false)
        {
            enePos = enemy.transform.position;          //�@�ϐ�enePos�Ɍ��݂̃G�l�~�[�̈ʒu�����܂� 
            enePos.x += speed * Mathf.Cos(rad);         //�@�ϐ�enePos��x�l�Ɂux�������̑傫���~speed�v�����܂�  
            enePos.y += speed * Mathf.Sin(rad);    //�@�ϐ�enePos��x�l�Ɂuy�������̑傫���~speed�v�����܂� 
            enemy.transform.position = enePos;   //�@���݂̈ʒu�ɁA�v�Z���ē���ꂽposition�l�����܂�
                                                 //�@�����A�G�l�~�[�I�u�W�F�N�g�̂����W��-�P�Q.0���ȉ��ɂȂ�����E�E
            if (enemy.transform.position.y < -12.0f)
            {
                speed += addSpeed;           //�@�G�l�~�[�̑��x�ɕϐ�addSpeed�̒l�𑫂��ĕϐ��ɖ߂��܂�
                ResetEnemy();            //�@ResetEnemy()���\�b�h�ɔ�т܂�
            }
        }
        else
        {

        }
    }
    void ResetEnemy()
    {
        //Tag��"Player"�̃I�u�W�F�N�g��T���āA�ϐ�player�ɓ���܂�
        GameObject player = GameObject.FindWithTag("Player");
        //�@x���̒l���i�|10.0�`10.0�̃����_���Ȓl�j�A y���̒l���i8.0�`10.0�̃����_���Ȓl�j�Ƃ���V�����|�W�V������^���܂�
        enemy.gameObject.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(8.0f, 10.0f));
        //�@���̒l��ϐ�enePos�Ɋi�[���܂�
        enePos = enemy.gameObject.transform.position;

        if (player == null)            //�@�����A�ϐ�player���ɉ����Ȃ���΁E�E�inull�@�͕ϐ��Ɂu���������ĂȂ��v���Ƃ������܂��j
        {
            speed = 0.0f;       //�ϐ�speed�̒l���O�ɂ��܂��i�G�l�~�[�̓������~�܂�܂��j
            enemy.gameObject.SetActive(false);        //�@�G�l�~�[�̃I�u�W�F�N�g�̕\�����~�߂܂�
            return;
        }
        if (player != null)            //�@�����A�ϐ�player���ɉ���������E�E�inull�@�͕ϐ��Ɂu���������ĂȂ��v���Ƃ������܂��j
        {
            rad = Mathf.Atan2(targetPos.y - enemy.transform.position.y, targetPos.x - enemy.transform.position.x);
            enePos = enemy.transform.position;          //�@�ϐ�enePos�Ɍ��݂̃G�l�~�[�̈ʒu�����܂� 
            enePos.x += speed * Mathf.Cos(rad);         //�@�ϐ�enePos��x�l�Ɂux�������̑傫���~speed�v�����܂� 
            enePos.y += speed * Mathf.Sin(rad);           //�@�ϐ�enePos��x�l�Ɂuy�������̑傫���~speed�v�����܂� 
            enemy.transform.position = enePos;          //�@���݂̈ʒu�ɁA�v�Z���ē���ꂽposition�l�����܂�
            enemy.gameObject.SetActive(true);           //�@���̕ϐ�enemy�ɓ����Ă���I�u�W�F�N�g��\�����܂�
        }
    }


}
