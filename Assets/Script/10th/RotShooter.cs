using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotShooter : MonoBehaviour
{
    public GameObject ballObj;               // ����������Prefab
    public GameObject BlueballObj;
    public GameObject YellowballObj;               // ����������Prefab
    public GameObject GreenballObj;
    private Vector3 clickPos;                    // �N���b�N�����ʒu���W
    public float rapid;                                   //�@�{�[�����o����悤�ɂȂ�܂ł̎���
    private float oriRapid;                           //����rapid�ɓ�����Ă����l���i�[���Ă����ϐ�

    public float speed;                              //    ��΂��͂̑傫���̒l�ł� 
    public GameObject playerObj;               //   Player��object�����܂�
    public Transform canonPos;           // �e���o��ꏊ�̍��W
    public ParticleSystem clickEffect;   //�@�N���b�N�����ꏊ�ɏo���G�t�F�N�g���i�[����ϐ��ł�

    private float degree;                             //��]�p�x�i�I�C���[�p�A��ʓI�ȕ��ʂ̊p���ŕ\���j
    public float rotSpeed;                            //��]�̃X�s�[�h������ϐ�

    public float canonRad;       //��]�̃��W�A��������ϐ���p�ӂ��܂�
    public Vector3 canonAngle;       //��]�p������ϐ�canonAngle��p�ӂ��܂�

    public Text CoinText;
    public int CoinCount = 0;

    public int RandomBall;

    public Image Hiyokoimage;
    public Image Azarasiimage;
    public Image Hituziimage;

    private void Start()
    {
        oriRapid = rapid;               //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
    }
    void Update()
    {
        CoinText.GetComponent<Text>().text = "�~" + CoinCount;
        clickPos = Input.mousePosition;          // Vector3�Ń}�E�X���N���b�N�����ʒu���W���擾����
            clickPos.z = 10.0f;                                   // �����łɓK���Ȓl�����܂�
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
            //�A�[�N�^���W�F���g�ŋ��߂��p�x�i���W�A���\���j���I�C���[�p�ɕϊ����܂�
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree,
        Time.deltaTime * rotSpeed));

            canonRad = playerObj.transform.eulerAngles.z * Mathf.Deg2Rad; //�@��]�������W�A�������߂܂�
            canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0); //���W�A������Vector3�^�̊p�x�����߂܂�
            rapid -= 0.05f;                   //�@oriRapid����0.05�������܂�

            if (rapid <= 0)          //�@����oriRapid�̒l���O�ȉ��ɂȂ�����A�}�E�X�{�^�������������ɒe���o��悤�ɂȂ�܂�
            {
            if (Input.GetMouseButtonDown(1))        // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            {
                RandomBall = Random.Range(1, 5);
                if (RandomBall == 1)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ball�Ƃ������O�ŁA�u�e�v��canonPos�̈ʒu�ɍ��܂�
                        GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //�@ball�I�u�W�F�N�g�̏�������E�����ɂ��ē|���܂�
                                                                        // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }else if (RandomBall == 2)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ball�Ƃ������O�ŁA�u�e�v��canonPos�̈ʒu�ɍ��܂�
                        GameObject ball = Instantiate(BlueballObj, canonPos.position, BlueballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //�@ball�I�u�W�F�N�g�̏�������E�����ɂ��ē|���܂�
                                                                        // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }
                else if (RandomBall == 3)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ball�Ƃ������O�ŁA�u�e�v��canonPos�̈ʒu�ɍ��܂�
                        GameObject ball = Instantiate(YellowballObj, canonPos.position, YellowballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //�@ball�I�u�W�F�N�g�̏�������E�����ɂ��ē|���܂�
                                                                        // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }
                else if (RandomBall == 4)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ball�Ƃ������O�ŁA�u�e�v��canonPos�̈ʒu�ɍ��܂�
                        GameObject ball = Instantiate(GreenballObj, canonPos.position, GreenballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //�@ball�I�u�W�F�N�g�̏�������E�����ɂ��ē|���܂�
                                                                        // ScreenToWorldPoint(�ʒu(Vector3))�@�X�N���[�����W�����[���h���W�ɕϊ�����
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }

            }
                rapid = oriRapid;           //�@rapid�Ɍ���oriRapid�̒l�����Ė߂��܂��@
            
        }
        else return;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinCount++;
            CoinText.GetComponent<Text>().text = "�~" + CoinCount;
        }
        if (other.gameObject.tag == "Azarasi")
        {
            Azarasiimage.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Hiyoko")
        {
            Hiyokoimage.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Hituzi")
        {
            Hituziimage.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
