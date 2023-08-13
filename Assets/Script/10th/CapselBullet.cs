using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapselBullet : MonoBehaviour
{
    private Vector3 veloDir; �@// �@�i�ޕ���������ϐ���p�ӂ��܂�
    public float speed;  �@�@�@//�@ ���x�̑傫�������܂�
    GameObject gameCtrl;   //�@ GameController�I�u�W�F�N�g������ϐ���p�ӂ��܂�
    RotShooter rotShoot;      //�@RotShoot�X�N���v�g������ϐ�rotShoot��p�ӂ��܂��@�����Ŏg���Ă�ϐ����g�����߂ł�
    public GameObject OpenCapsel;
    public SpriteRenderer CloseCapsel;
 

    private void Start()
    {
        gameCtrl = GameObject.Find("Gun");      //�@scene������"GameController "�Ƃ������O��Object ��T���ĕϐ��ɓ���܂�        �@
        rotShoot = gameCtrl.GetComponent<RotShooter>();  //�@�ϐ�rotShoot�ɕϐ�gameCtrl�ɓ����ꂽRotShooter�X�N���v�g�����܂�
        veloDir = rotShoot.canonAngle * speed;            // ���˕�����rotShooter����canonAngle�������Ă��܂�
        Destroy(gameObject, 3.5f);                                       // �������ꂽ�̂��A3.5�b�ŏ����܂�
    }

    private void Update()
    {
        transform.localPosition += veloDir;                 // Update���ŁA���t���[���A�u�e�v�̃|�W�V������velDir�𑫂��Ă����܂�
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mato")
        {
            //OpenCapsel.SetActive(true);
            CloseCapsel.enabled = false;
          
            //Vector3 tmp = this.gameObject.transform.position;
            //heightArmpos = tmp.x;
        }
    }
}