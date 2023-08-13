using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouseCanon7 : MonoBehaviour
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

    public float rotSpeed = 0.8f;

    public SpriteRenderer RobotArm;
    public SpriteRenderer Zoukin;

    public GameObject PlayerObject;
    private float Degreee;
    void Start()
    {
        oriRapid = rapid;             //editor��rapid�ɓ��ꂽ�l��oriRapid�Ɋi�[���܂�
        audioSource = GetComponent<AudioSource>();
        RobotMouseMove = true;
    }

    void Update()
    {

        oriRapid -= rapidTime;
       clickPos = Input.mousePosition;
        if (RobotMouseMove == true)
        {

            //�r�̉�]
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
            Degreee = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
            PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));

            // if (Input.GetMouseButtonDown(0))        // �}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
            if (Input.GetMouseButtonDown(0))
            {
                //clickPos = Input.mousePosition;          // Vector3�^�ϐ���lickPos�ɁA�}�E�X�̌��݈ʒu���W���擾����
                clickPos.z = 10.0f;                                   //Z���̒l�ɓK���Ȓl�����܂�
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffect.Emit(0);
                ClickEffectOutline.Play();      //�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(RobotArmSE);
                Zoukin.enabled = false;
                RobotArm.enabled = false;
                if (oriRapid <= 0.0f == true)     //����rapid�̒l���O�ȉ��ɂȂ�����A�}�E�X�{�^�������������ɒe���o��悤�ɂȂ�܂�
                {
                    /*  GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                      Vector3 bulletDir2 = Vector3.Scale((ClickEffect.transform.position - canonPos.position), new Vector3(1, 1, 0)).normalized;
                      obj.GetComponent<Rigidbody2D>().AddForce(bulletDir2 * speed); //AddForce��rigidbody��t����ball���΂��܂�*/
                    GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                    Vector3 canonAngle = Quaternion.Euler(PlayerObject.transform.eulerAngles) * new Vector3(1, 0, 0) ;
                    //AddForce��rigidbody�QD��t�����ϐ�obj�̃I�u�W�F�N�g���΂��܂�
                    obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);

                    oriRapid = rapid;               //�@ rapid�Ɍ��̒l�����Ė߂��܂�
                    Debug.Log(canonAngle);
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
