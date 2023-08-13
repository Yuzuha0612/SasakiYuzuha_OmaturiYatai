using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRot : MonoBehaviour
{
    public GameObject GunDnagan;        // ����������Prefab
    private Vector3 clickPos;             // �N���b�N�����ʒu���W
    public float rapidDelta;                  	//�@���t���[���A���Ԃ�������Ă�����
    public float rapid;                              //�@�{�[�����o����悤�ɂȂ�܂ł̎���
    public float rapidTime;
    public Transform canonPos;	//�@ �e���o��ꏊ�̍��W
    private float oriRapid;                       //   ����rapid�ɓ�����Ă����l���i�[���Ă����ϐ�
    public float speed;                //�@��΂��͂̑傫���̒l�ł�
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    AudioSource audioSource;
    public bool GunMouseMove;
    public AudioClip GunSE;

    public float rotSpeed = 0.8f;
    private float oriRotSpeed;
    // public SpriteRenderer RobotArm;
    //public SpriteRenderer Zoukin;

    public GameObject PlayerObject;
    private float Degreee;
    void Start()
    {
        oriRapid = rapid;             //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
        audioSource = GetComponent<AudioSource>();
        GunMouseMove = true;
        oriRotSpeed = this.GetComponent<GunRot>().rotSpeed;
    }

    void Update()
    {
        rapid -= rapidDelta;               //oriRapid����0.05�������܂�
        //oriRapid -= rapidTime;
        clickPos = Input.mousePosition;
        //�r�̉�]
        Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
        Degreee = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
        // PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));
        //�}�E�X�J�[�\���̕����ɖ{�̂�������X�N���v�g
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
        if (GunMouseMove == true)
        {
            if (mouseWorldPos.y >= canonPos.position.y)        // �}�E�X�J�[�\���̂��̍��W��canonPos�����i�C��̒��S�ʒu���j��Ȃ�΁E�E
            {
                rotSpeed = oriRotSpeed;      //�@���Ƃ�rotSpeed�i�C����]���x�j�����Ė߂��܂�

                //�i�p�x��⊮���Ȃ���܂킷�֐��j�ŁA���t���[��rotSpeed�̒l�̑����ŉ񓪂��܂�
                PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));
            }
            if (Input.GetMouseButtonDown(0))        // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            {
                //clickPos = Input.mousePosition;          // Vector3�^�ϐ���lickPos�ɁA�}�E�X�̌��݈ʒu���W���擾����
                clickPos.z = 1.0f;                                   //Z���̒l�ɓK���Ȓl�����܂�
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffect.Emit(0);
                ClickEffectOutline.Play();      //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(GunSE);
                if (oriRapid <= 0)     //����rapid�̒l���O�ȉ��ɂȂ�����A�}�E�X�{�^�������������ɒe���o��悤�ɂȂ�܂�
                {
                    // GameObject obj = Instantiate(GunDnagan, canonPos.position, GunDangan.transform.rotation);
                    //Vector3 canonAngle = Quaternion.Euler(PlayerObject.transform.eulerAngles) * new Vector3(1, 0, 0);
                    //AddForce��rigidbody�QD��t�����ϐ�obj�̃I�u�W�F�N�g���΂��܂�
                    //obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                    //�v���C���[�I�u�W�F�N�g�i�C���j�X������A�e�̔�ԕ��������߂܂�
                    float canonRad = PlayerObject.transform.eulerAngles.z * Mathf.Deg2Rad;        // canon�̌X�����烉�W�A�������߂܂�
                                                                                               //canonRad�̑傫����������x�N�g�������߂܂�
                    Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
                    //���߂�ꂽcanonRad�̒l����ASin�֐��̒l���v�Z���܂��@
                    float sin = Mathf.Sin(canonRad);

                   // oriRapid = rapid;               //�@ rapid�Ɍ��̒l�����Ė߂��܂�
                    Debug.Log(canonAngle);
                    //�@�����A�ϐ�sin�̒l��0.2f���傫���āA�e�̏o��ꏊ�����}�E�X����ɂ��鎞�́E�E
                    if (sin > 0.2f && (mouseWorldPos.y >= canonPos.position.y))
                    {
                        rotSpeed = oriRotSpeed;
                        //�@muzzle�̈ʒu�Ƀ{�[���𐶐����܂�
                        GameObject ball = Instantiate(GunDnagan, canonPos.position, GunDnagan.transform.rotation);
                        //�@�{�[����rigidbody2D������āAcanonAngle�̕����ɗ͂������܂�
                        ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                        //�@rapid�Ɍ���oriRapid�̒l�����Ė߂��܂��@
                        rapid = oriRapid;
                    }
                }
                else return;
            }
        }
        IEnumerator RobotArmMouseCoroutine()
        {
            yield return new WaitForSecondsRealtime(5.0f);

        }
        //�����ɂԂ�������A1�b��ɂԂ������ꏊ�̍��W���擾���āA��������L�k
    }
}
