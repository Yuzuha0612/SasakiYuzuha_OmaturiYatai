using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotTest : MonoBehaviour
{
    public GameObject ballObj;              // �@����������Prefab
    private Vector3 clickPos;                   // �@�}�E�X�̃J�[�\���ʒu���W
    public float rapidDelta;                    //�@���t���[���A���Ԃ�������Ă�����
    public float rapid;                                     //�@�{�[�����o����悤�ɂȂ�܂ł̎��ԁ@float�^�̕ϐ���p�ӂ��܂�
    private float oriRapid;                             //�@����rapid�ɓ�����Ă����l���i�[���Ă����ϐ��@ float�^�̕ϐ���p�ӂ��܂�
    public bool gameOn;                             //   �Q�[�����i�s�����I����Ă邩�A��2���̃t���O
    public float speed;                             //    ��΂��͂̑傫���̒l�ł� 
    public Transform canonPos;          //�@ �e���o��ꏊ�̍��W
    public ParticleSystem clickEffect;      //�@�N���b�N�����ꏊ�ɏo���G�t�F�N�g���i�[����ϐ��ł�
    public GameObject playerObj;        //�@ Player��object�����܂�
    private float degree;       //�@��]�p�x�i�I�C���[�p�A��ʓI�ȕ��ʂ̊p���ŕ\���j
    public float rotSpeed = 0.8f;           //�@�񓪂̃X�s�[�h������ϐ��@0.8f���炢���悢
    private float oriRotSpeed;      //   ���Ƃ̉�]���x���i�[����ϐ���p�ӂ��܂�

    private void Start()
    {
        oriRapid = rapid;                       //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
        gameOn = true;                          //gameOn��true�ɂ��܂�
        oriRotSpeed = this.GetComponent<GunRotTest>().rotSpeed;   // �J�n���ɃC���X�y�N�^�[�ɓ��ꂽrotSpeed���l�����܂�
    }
    void Update()
    {
        if (gameOn == true)
        {
            rapid -= rapidDelta;               //oriRapid����0.05�������܂�
            clickPos = Input.mousePosition;          // Vector3�Ń}�E�X�̈ʒu���W���擾����
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;

            //�@ �ϐ�bulletDir�@ muzzle�ƃJ�[�\���̈ʒu���A���A�������x�N�g�������ē���܂�
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //�}�E�X�J�[�\���̕����ɖ{�̂�������X�N���v�g
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);   //�@�J�[�\���ʒu���Q�[���X�N���[���̍��W�ɂ��܂�

            //�@�C���I�u�W�F�N�g�̊p�x�i�O�C�O�A���̒l�j�ɁAVector3�̌^�i�O�C�O�A�C����z���̊p�x����A�񂷖ڕW�p�x�܂ł��ALearpAngle
            if (mouseWorldPos.y >= canonPos.position.y)        // �}�E�X�J�[�\���̂��̍��W��canonPos�����i�C��̒��S�ʒu���j��Ȃ�΁E�E
            {
                rotSpeed = oriRotSpeed;      //�@���Ƃ�rotSpeed�i�C����]���x�j�����Ė߂��܂�

                //�i�p�x��⊮���Ȃ���܂킷�֐��j�ŁA���t���[��rotSpeed�̒l�̑����ŉ񓪂��܂�
                playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime *
             rotSpeed));
            }
            if (Input.GetMouseButtonDown(0))                // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            {
                clickPos.z = 1.0f;                                   //Z���̒l�ɓK����z�����Ɂ{�̒l�����܂�
                                                                     // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                //�G�t�F�N�g�����������W��1��\�����܂�
                clickEffect.Emit(1);


                if (rapid <= 0)          //����oriRapid�̒l���O�ȉ��ɂȂ�����A�}�E�X�{�^�������������ɒe���o��悤�ɂȂ�܂�
                {
                    //�v���C���[�I�u�W�F�N�g�i�C���j�X������A�e�̔�ԕ��������߂܂�
                    float canonRad = playerObj.transform.eulerAngles.z * Mathf.Deg2Rad;        // canon�̌X�����烉�W�A�������߂܂�
                    //canonRad�̑傫����������x�N�g�������߂܂�
                    Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
                    //���߂�ꂽcanonRad�̒l����ASin�֐��̒l���v�Z���܂��@
                    float sin = Mathf.Sin(canonRad);
                    //�@�����A�ϐ�sin�̒l��0.2f���傫���āA�e�̏o��ꏊ�����}�E�X����ɂ��鎞�́E�E
                    if (sin > 0.2f && (mouseWorldPos.y >= canonPos.position.y))
                    {
                        rotSpeed = oriRotSpeed;         //�@�ϐ�rotSpeed�ɁA�n�߂̒l�����܂�

                        /////////////////////////////////////////////////////////////
                        // �@�{�[���𐶐����Ĕ��˂���X�N���v�g
                        /////////////////////////////////////////////////////////////
                        //�@muzzle�̈ʒu�Ƀ{�[���𐶐����܂�
                        GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);

                        //�@�{�[����rigidbody2D������āAcanonAngle�̕����ɗ͂������܂�
                        ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                        //�@rapid�Ɍ���oriRapid�̒l�����Ė߂��܂��@
                        rapid = oriRapid;

                    }
                }
            }
        }
        else return;
    }


}
