using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResporn : MonoBehaviour
{
    public GameObject enemy;            //enemy��Prefab���i�[����ϐ�enemy��p�ӂ��܂�
    GameObject gameCtrl;    //GameController�I�u�W�F�N�g���i�[����ϐ�gameCtrl��p�ӂ��܂�
    //GameBool gameBool;    //GameBool�X�N���v�g���i�[����ϐ�gameBool��p�ӂ��܂�

    private void Start()
    {
        gameCtrl = GameObject.Find("GameController");   //GameController�I�u�W�F�N�g��T���Ċi�[���܂�
        //gameBool = gameCtrl.GetComponent<GameBool>(); //GameController����GameBool�R���|�l���g���i�[���܂�
        enemy.gameObject.SetActive(false);            //�@�i�����Ă���ꍇ��z�肵�āj���̃I�u�W�F�N�g��Scene �ɏ����܂��@�@
        InvokeRepeating("EnemySet", 2.0f, 4.0f);       //�@�֐����J��Ԃ��Ăяo�����\�b�h�A2�b��ɁA4�b���ƂɁhEnemySet�h�֐����Ăяo���܂�
    }

    void EnemySet()       //�G�l�~�[���Z�b�g���郁�\�b�h�A�@�͂��߂���J��Ԃ��ČĂяo����܂�
    {
        //��������ʒu�����߂܂��A���̒l�Ƃ��̒l���ARandam.Range(A,B)�Ŕ͈͂����߂ă����_���ɐݒ肵�܂�
        Vector3 setPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(9.0f, 11.0f), 0);
        enemy = Instantiate(enemy, setPos, transform.rotation);     //Instantiate�֐��iprefab�A�ꏊ�A��]�p�x�j�ŁA�������܂�
        enemy.transform.position = setPos;                  //�@���݂̈ʒu�ɁA�v�Z���ē���ꂽposition�l�����܂�
        enemy.gameObject.SetActive(true);
    }
    private void Update()
    {/*
       if (gameBool.gameOn != true) //�@������GameManager��gameOn�t���O���^�itrue�j�łȂ����
        {
            CancelInvoke("EnemySet");       //�@EnemySet���\�b�h���Ăяo�����Ƃ��~�߂܂�
        }*/
    }
}
