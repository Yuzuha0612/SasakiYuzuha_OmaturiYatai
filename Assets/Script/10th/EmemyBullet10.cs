using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyBullet10 : MonoBehaviour
{
    public GameObject explosion;       //�p�[�e�B�N���̕ϐ���p�ӂ��܂�

    void Start()
    {
        Invoke("SelfKill", 5.0f);       //�������ꂽ10�b��ɔj�󂵂܂�
    }

    void Update()
    {
        transform.position += new Vector3(0, -2.5f, 0) * Time.deltaTime;  //�@���t���[�����̒l�������čs���܂��i�}�C�i�X�𑫂��Ă���j
    }

    private void OnTriggerEnter2D(Collider2D other)   //�����蔻��ł��@�g���K�[���g���܂�
    {
        if (other.gameObject.tag == "Bullet" && gameObject != null)        //�����A�������������tag��Bullet�Ȃ�
        {
            SelfKill();
        }
    }

    void SelfKill()
    {
        explosion.transform.position = gameObject.transform.position;    //explosion�̏ꏊ�ɂ��̃I�u�W�F�N�g�̏ꏊ�����܂�
                                                                         //GameObject�^�̃p�[�e�B�N���v���n�u�ɁAexplosion�̃v���n�u�𐶐����ē���܂�
        GameObject expPrefab = Instantiate(explosion, explosion.transform.position, transform.rotation);
        Destroy(expPrefab, 1.0f);                       //1�b��Ƀp�[�e�B�N���������܂�
        Destroy(gameObject, 0.1f);                   //���̃I�u�W�F�N�g�i�G�l�~�[�̒e�j�������܂�
    }
}


