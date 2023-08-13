using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetterSlush : MonoBehaviour
{
    public GameObject ballObjOpen;
    public GameObject ballObj;        // ����������Prefab
    private Vector3 clickPos;             // �N���b�N�����ʒu���W
    public int rapid;                              //�@�{�[�����o����悤�ɂȂ�܂ł̎���
    private int oriRapid;                       //   ����rapid�ɓ�����Ă����l���i�[���Ă����ϐ�
    public bool gameOn;          //   �Q�[�����i�s�����I����Ă邩�A��2���̃t���O
    public float speed;                //�@��΂��͂̑傫���̒l�ł�
    public GameObject NowLetter;
    public Vector2 objDir;
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    public bool FirstStage;
    void Start()
    {
        FirstStage = true;
       // NowLetter = ballObj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FirstStage = false;
        }
        if (FirstStage == true)
        {
            NowLetter = ballObjOpen;
        }else if(FirstStage == false)
        {
            NowLetter = ballObj;
        }
        if (Input.GetMouseButtonDown(0))        // �����}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
        {
            clickPos = Input.mousePosition;          // Vector3�^�̕ϐ��ɁA�}�E�X���N���b�N�����ʒu���W���擾����
                                                     //�f�o�b�OLog�FclickPos�̒l�������o���܂��@
            Debug.Log(clickPos);
            // Z���̒l���O���ƕ\������܂���A�iScreenToWorldPoint�ɕK�v�j�A�����łɓK���Ȓl�i�����ł�10f�j��z�l�ɓ���܂�
            clickPos.z = 10.0f;
            ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
            ClickEffect.Play();�@		//�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
            ClickEffect.Emit(0);
            ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
            ClickEffectOutline.Play();�@		//�@��A�̃p�[�e�B�N���̏ꍇ�APlay()���\�b�h�ōĐ����܂�
            ClickEffectOutline.Emit(0);
            GameObject obj = Instantiate(NowLetter, Camera.main.ScreenToWorldPoint(clickPos), NowLetter.transform.rotation);
            //�o��������obj��Rigidbody������AddForce�ŕ����I�ȗ͂������܂�
            obj.GetComponent<Rigidbody2D>().AddForce (objDir * speed);	
            oriRapid = rapid;   //�@oriRapid�Ɍ���rapid�̒l�����Ė߂��܂��@
            Destroy(NowLetter, 3.0f);

        }
        else return;
    }
    }

