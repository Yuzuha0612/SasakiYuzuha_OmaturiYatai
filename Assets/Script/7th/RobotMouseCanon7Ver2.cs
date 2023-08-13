using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouseCanon7Ver2 : MonoBehaviour
{
    public GameObject ballObj;
    private Vector3 clickPos;                   // �@�}�E�X�̃J�[�\���ʒu���W
    public float rapidDelta;                    //�@���t���[���A���Ԃ�������Ă�����
    private float oriRapid;
    public float rapid;
    public bool gameOn;                              //   �Q�[�����i�s�����I����Ă邩�A��2���̃t���O
    public float speed;                              //    ��΂��͂̑傫���̒l�ł� 
    public Transform canonPos;            //�@ �e���o��ꏊ�̍��W
    public ParticleSystem clickEffect;   //�@�N���b�N�����ꏊ�ɏo���G�t�F�N�g���i�[����ϐ��ł�
    public float rotSpeed = 0.8f;
    public GameObject playerObj;           //�@ Player��object�����܂�
    private float degree;              //�@��]�p�x�i�I�C���[�p�A��ʓI�ȕ��ʂ̊p���ŕ\���j

    public SpriteRenderer RobotArm;
    public SpriteRenderer Zoukin;
    private void Start()
    {
        oriRapid = rapid;               //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
        gameOn = true;                  //gameOn��true�ɂ��܂�
    }

    void Update()
    {
        if (gameOn == true)
        {
            oriRapid -= rapidDelta;                            //���t���[���ϐ�oriRapid����ϐ�rapidDelta�̒l�������āA�܂��ϐ�oriRapid�ɖ߂��܂�
            clickPos = Input.mousePosition;
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
            //�A�[�N�^���W�F���g�ŋ��߂��p�x�i���W�A���\���j���I�C���[�p�ɕϊ����܂�
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //playerObj��z�������̉�]�p�x�i�O�C�O�A���̒l�j�ɕϐ�degree�����܂�
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime * rotSpeed));

            if (Input.GetMouseButtonDown(0))        // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            {
                clickPos.z = 10.0f;                                   //Z���̒l�ɓK����z�������Ɂ{�̒l�����܂�
                                                                      // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                clickEffect.Emit(1);
                Zoukin.enabled = false;
                RobotArm.enabled = false;
                if (oriRapid <= 0.0f == true)     //����oriRapid�̒l���O�ȉ���������A�e���o��悤�ɂȂ�܂�
                {
                    //�@�I�u�W�F�N�gcanonPos�̏ꏊ�ɁA�ϐ�ballObj�ɃZ�b�g���ꂽObject���o�������܂�
                    GameObject obj = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
                    //AddForce��rigidbody�QD��t�����ϐ�obj�̃I�u�W�F�N�g���΂��܂�
                    Vector3 canonAngle = Quaternion.Euler(playerObj.transform.eulerAngles) * new Vector3(1, 0, 0);
                    obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                    //�@ �ϐ�oriRapid�Ɍ��̒l�����Ė߂��܂�
                    oriRapid = rapid;
                    Debug.Log(canonAngle);
                }
            }
        }
        else return;
    }
}