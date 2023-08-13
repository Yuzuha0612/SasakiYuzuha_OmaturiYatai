using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellHalf : MonoBehaviour
{
    public int bulletNum = 5;               //�@�����Ɍ����o���e�̐�
    private Vector3 clickPos;                    // �N���b�N�����ʒu���W
    public GameObject bullet;                        //�@�e�̃I�u�W�F�N�g���i�[����ϐ�
    public GameObject playerObj;            �@//�@�v���C���[�I�u�W�F�N�g�i���@�j���i�[���܂�
    public Transform canonPos;�@�@�@�@�@//�@�e�������������W�A�i���P�b�g�̒e�̏o��ꏊ�̃I�u�W�F�N�g�j
    public ParticleSystem clickEffect;   �@�@//�@�N���b�N�����ꏊ�ɏo���G�t�F�N�g���i�[����ϐ��ł�
    private float degree;                             �@//��]�p�x�i�I�C���[�p�A��ʓI�ȕ��ʂ̊p���ŕ\���j
    public float rotSpeed;                            �@//��]�̃X�s�[�h������ϐ�
    public float moveSpeed = 5.0f;      �@�@//�@�e�̈ړ����x�����܂�

    public float startAngle = 45.0f; �@�@�@//�@�͂��܂�̊p�x
    public float endAngle = 135.0f;   �@  �@//�@�����̊p�x
    private float angleStep;		 //�@�e�̊Ԋu�̊p�x	
    private Vector3 shipAngle;  �@�@�@    //�@�v���C���[�I�u�W�F�N�g�̌X�����i�[���܂�


    void Start()
    {
        angleStep = (endAngle - startAngle) / (bulletNum - 1); �@�@�@�@�@ //�@�n�܂�ƏI���̊p�x�������āA�e��-1�Ŋ��邱�ƂŒe�Ԋu�𓾂܂�
       
    }
    private void Update()
    {
            clickPos = Input.mousePosition;          // Vector3�Ń}�E�X�̈ʒu���W���擾����
            clickPos.z = 10.0f;                                   �@�@// ������z�l�ɓK���Ȓl�����܂�
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //�A�[�N�^���W�F���g�ŋ��߂��p�x�i���W�A���\���j���I�C���[�p�ɕϊ����܂�
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime * rotSpeed));

            if (Input.GetMouseButtonDown(0))                // �����}�E�X�{�^���������ꂽ��E�E
            {
                shipAngle = playerObj.transform.eulerAngles;    //�@���̃v���C���[�@�̌��݂̌X���i�I�C���[�p�x�j���iVector3�^�j���i�[���܂�
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                clickEffect.Emit(1);
                Shot(bulletNum);             //�@Shot���\�b�h�ɔ�т܂��A�����Ɉ���bulletNum�i���������Ɍ��̂��H�̒l�j�𑗂�܂�
            }
        
    }
    private void Shot(int bulletNumber)         //�@Shot�i�����͐����́u�e�v�̒l�j���\�b�h�ł��i�V���ɒ�`���܂����A�l�͑���ꂽ���̒l�������p���ł��܂��j
    {
        if (bulletNumber > 1) �@�@�@//�@�e�̒l��1���傫����΁E�E
        {
            float angle = startAngle;          //�@�ϐ�angle�ϐ��Ɉꔭ�ڂ̊p�x�����A�ʒu�����������܂�

            for (int i = 0; i < bulletNumber; i++)      //�@for�̌J��Ԃ��\���A�i�ϐ�i�ɖ���1�Â����Ă����A�ϐ�bulletNum�̐��ɒB������A�J��Ԃ��𔲂��܂��j
            {

                //�e�̔��˒n�_����A�͂��܂�̊p�x�{���̃v���C���[�I�u�W�F�N�g�̌X���p�i�����j�𑫂��A�I�u�W�F�N�g��90�x�Q�Ă���̂ŁA����������������ꏊ�ɂȂ�܂�
                float bulletXDir = canonPos.transform.localPosition.x + Mathf.Cos((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);
                float bulletYDir = canonPos.transform.localPosition.y + Mathf.Sin((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);

                Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    �e�̈ʒu���W��bulletPos�ɓ���܂�
                                                                                                     //�@�e�̔�ԕ���bulletMoveDir�ɁA���ˏꏊ�ƒe�̊p�x�̏ꏊ�̍�����x�N�g�����Z�o���ĒP�ʃx�N�g�������āAprefab�̈ړ��X�s�[�h�������܂�
                Vector2 bulletMoveDir = (bulletPos - (Vector2)canonPos.transform.localPosition).normalized * moveSpeed;

                //�@�e��prefab��spawnPoint �̏ꏊ�ɐ������܂�
                GameObject fireBall = Instantiate(bullet, (Vector2)canonPos.transform.position, Quaternion.identity);
                //�@��������prefab��Rigidbody�����āA���̑��x�x�N�g������velocity�ɁAbulletMoveDir��x,y�x�N�g�����������܂�
                fireBall.transform.up = bulletMoveDir;  		//�@fireBall�I�u�W�F�N�g�̏������bulletMoveDir�̕����ɂ��܂�
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);
                angle += angleStep;    			//�@�ϐ�angle��angleStep �̒l�𑫂��Ď��̒e�̈ʒu���v�Z���ČJ��Ԃ��������܂�

                Destroy(fireBall, 4.0f);    			//�������ꂽObject ��4�b��ɔj�󂵂܂�
            }
        }
        else //�@��������ȊO�Ȃ�i�u�e�v�̐���1�ȉ��̏ꍇ�E�E�j
        {
            float angle = 90.0f;    //�@�ϐ�angle��90.0f�����܂��i�I�u�W�F�N�g��y�������ɂ܂������j

            //�e�̔��˒n�_����A�͂��܂�̊p�x�{���̃v���C���[�I�u�W�F�N�g�̌X���p�i�����j�𑫂��A�I�u�W�F�N�g��90�x�Q�Ă���̂ŁA����������������ꏊ�ɂȂ�܂�
            float bulletXDir = canonPos.transform.localPosition.x + Mathf.Cos((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);
            float bulletYDir = canonPos.transform.localPosition.y + Mathf.Sin((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);

            Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    �e�̈ʒu���W��bulletPos�ɓ���܂�
                                                                                                 //�@�e�̔�ԕ���bulletMoveDir�ɁA���ˏꏊ�ƒe�̊p�x�̏ꏊ�̍�����x�N�g�����Z�o���ĒP�ʃx�N�g�������āAprefab�̈ړ��X�s�[�h�������܂�
            Vector2 bulletMoveDir = (bulletPos - (Vector2)canonPos.transform.localPosition).normalized * moveSpeed;

            //�@�e��prefab��spawnPoint �̏ꏊ�ɐ������܂�
            GameObject fireBall = Instantiate(bullet, (Vector2)canonPos.transform.position, Quaternion.identity);
            fireBall.transform.up = bulletMoveDir; 		//�@fireBall�I�u�W�F�N�g�̏������bulletMoveDir�̕����ɂ��܂�
            //�@��������prefab��Rigidbody�����āA���̑��x�x�N�g������velocity�ɁAbulletMoveDir��x,y�x�N�g�����������܂�
            fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

            Destroy(fireBall, 4.0f);     //�������ꂽObject ��4�b��ɔj�󂵂܂�
        }
    }

}
