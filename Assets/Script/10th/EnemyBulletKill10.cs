using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletKill10 : MonoBehaviour
{
    public GameObject explosion; //�@�����p�[�e�B�N�����i�[����GameObject�^�̕ϐ�������܂�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")�@//�@��������(other)��tag���hBullet�h�Ȃ��
        {
            //explosion�̏ꏊ��other�̏ꏊ�����܂�
            explosion.transform.position = other.transform.position;
            //gameObject�^�̔����̃v���n�u�𐶐����āA�ϐ�expPrefab�ɓ���܂�
            GameObject expPrefab = Instantiate(explosion, explosion.transform.position, transform.rotation);
            Destroy(expPrefab, 1.0f);                       �@//�p�[�e�B�N���������܂�
            this.gameObject.SetActive(false);      //�@���̒e�̃I�u�W�F�N�g��Scene �����\���ɂ��ď����܂�
        }
    }
}
