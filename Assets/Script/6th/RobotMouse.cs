using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouse : MonoBehaviour
{
    public GameObject RobotHand;        // ����������Prefab
    private Vector3 clickPos;             // �N���b�N�����ʒu���W
    public float rapid;                              //�@�{�[�����o����悤�ɂȂ�܂ł̎���
    public float rapidTime;
    public Transform canonPos;	//�@ �e���o��ꏊ�̍��W
    private float oriRapid;                       //   ����rapid�ɓ�����Ă����l���i�[���Ă����ϐ�
    public float speed;                //�@��΂��͂̑傫���̒l�ł�
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    AudioSource audioSource;
    public bool RobotMouseMove;
    public AudioClip RobotArmSE;
    void Start()
    {
        oriRapid = rapid;             //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
        audioSource = GetComponent<AudioSource>();
        RobotMouseMove = true;
    }

    void Update()
    {

        oriRapid -= rapidTime;
        if (RobotMouseMove == true)
        {
            if (Input.GetMouseButtonDown(0))        // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            {
                clickPos = Input.mousePosition;          // Vector3�^�ϐ���lickPos�ɁA�}�E�X�̌��݈ʒu���W���擾����
                clickPos.z = 10.0f;                                   //Z���̒l�ɓK���Ȓl�����܂�
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffect.Emit(0);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.Play();      //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(RobotArmSE);
                if (oriRapid <= 0.0f == true)     //����rapid�̒l���O�ȉ��ɂȂ�����A�}�E�X�{�^�������������ɒe���o��悤�ɂȂ�܂�
                {
                    GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                    //�e�̔�ԕ����x�N�g��bulletDir�ɁA�e�̏o��canonPos�̈ʒu�ƃ}�E�X�̃N���b�N�����ʒu�������Z�����l�ɁA
                    //(1,1,0)�������āiScale�j�AZ���̒l��0�ɂ��܂��A�����normalized�Łu�P�ʃx�N�g���v�ɒ����܂�
                    Vector3 bulletDir = Vector3.Scale((ClickEffect.transform.position - canonPos.position), new Vector3(1, 1, 0)).normalized;
                    obj.GetComponent<Rigidbody2D>().AddForce(bulletDir * speed); //AddForce��rigidbody��t����ball���΂��܂�
                    oriRapid = rapid;               //�@ rapid�Ɍ��̒l�����Ė߂��܂��@
                }
            }
            else return;
        }
    }
    IEnumerator RobotArmMouseCoroutine()
    {
        yield return new WaitForSecondsRealtime(5.0f);

    }

 }

