using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatameMachine : MonoBehaviour
{
    public int numberOfBullet;          //�e�̐�
    //public GameObject bullet;           //�e��Prefab������ϐ�
    public GameObject[] Watamecolor;
    Vector2 spawnPoint;�@�@�@�@�@//�e�������������W�A�i�����ł̓N���b�N�����ꏊ�j
    public float moveSpeed = 5f; �@//�Z�b�g���ꂽprefab���ړ�����X�s�[�h

    public float timeOut;
    private float timeElapsed;
    private CCGameAdministrator ccga;
    public GameObject Administor;

    void Start()
    {
        ccga = Administor.GetComponent<CCGameAdministrator>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            numberOfBullet = Random.Range(1, 18);
            //     �J�[�\���̈ʒu��ϐ�spawnPoint�ɓ���܂�
            spawnPoint = this.transform.position;
            SpawnBullet(numberOfBullet);
            timeElapsed = 0.0f;
        }
      
    }
    void SpawnBullet(int numberOfBullet)
    {
        //�@���������_�̕ϐ�angleStep�ɁA360��e���Ŋ������l�����܂��i�e�̕��������x���ɕ������邩�����߂�j
        float angleStep = 360f / numberOfBullet;
        float angle = 0f;                             �@�@�@�@�@�@�@  //���������_�̕ϐ�angle�ɂO�����܂��i�͂��܂�̈ʒu�ł��j

        //�@for�̌J��Ԃ��\���A�i�ϐ�i�ɖ���1�Â����Ă����A�ϐ�numberOfBullet�̐��ɒB������A�J��Ԃ��𔲂��܂��j
        for (int i = 0; i <= numberOfBullet - 1; i++)
        {
            //�@�ϐ�bulletXDir��spawnPoint��x�̒l�ɁACos�i���W�A���Ŋp�x�������̂ŁA�~���̒����i���a���Q��3.14�j��angle�̊p�x���狁�߂܂��j
            float bulletXDir = spawnPoint.x + Mathf.Cos(angle * 2 * Mathf.PI / 360f);
            float bulletYDir = spawnPoint.y + Mathf.Sin(angle * 2 * Mathf.PI / 360f);       //�@���l�ɕϐ�bullet��Dir��spawnPoint�̂��̒l��Sin()���g���ċ��߂܂�
            Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    �e�̈ʒu���W��bulletPos�ɓ���܂�
            //�@�e�̔�ԕ���bulletMoveDir�ɁA�N���b�N�����ꏊ�ƒe�̌������ꏊ�́u���v����x�N�g�����Z�o���āA�P�ʃx�N�g�������āAprefab�̈ړ��X�s�[�h�������܂�
            Vector2 bulletMoveDir = (bulletPos - spawnPoint).normalized * moveSpeed;

            //GameObject fireBall = Instantiate(bullet, spawnPoint, Quaternion.identity);�@�@//�@�e��prefab��spawnPoint �̏ꏊ�ɐ������܂�
            if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameNormal)
            {
                int randomwatame = Random.Range(0, 7);

                GameObject fireBall = Instantiate(Watamecolor[randomwatame], spawnPoint, Quaternion.identity);  //�@�e��prefab��spawnPoint �̏ꏊ�ɐ������܂�
                fireBall.transform.up = bulletMoveDir;                                                            //�@fireBall�I�u�W�F�N�g�̏������bulletMoveDir�̕����ɂ��܂�
                                                                                                                  //�@��������prefab��Rigidbody�����āA���̑��x�x�N�g������velocity�ɁAbulletMoveDir��x,y�x�N�g�����������܂�
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

                angle += angleStep;   //�ϐ�angle�Ɂ@angleStep �̒l�������܂�
                Destroy(fireBall, 3.0f);�@�@//�������ꂽObject ��3�b��ɔj�󂵂܂��@
            }
            if(ccga.CCGS == CCGameAdministrator.CCGameStatus.GameFever)
            {
                int randomwatame = 6;

                GameObject fireBall = Instantiate(Watamecolor[randomwatame], spawnPoint, Quaternion.identity);  //�@�e��prefab��spawnPoint �̏ꏊ�ɐ������܂�
                fireBall.transform.up = bulletMoveDir;                                                            //�@fireBall�I�u�W�F�N�g�̏������bulletMoveDir�̕����ɂ��܂�
                                                                                                                  //�@��������prefab��Rigidbody�����āA���̑��x�x�N�g������velocity�ɁAbulletMoveDir��x,y�x�N�g�����������܂�
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

                angle += angleStep;   //�ϐ�angle�Ɂ@angleStep �̒l�������܂�
                Destroy(fireBall, 3.0f);�@�@//�������ꂽObject ��3�b��ɔj�󂵂܂��@
            }
        }
    }
}