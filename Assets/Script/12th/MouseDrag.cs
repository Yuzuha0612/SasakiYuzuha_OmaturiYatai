using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Rigidbody2D rbPlayer;          //rigidbody���i�[����ϐ���p�ӂ��܂�
    public LineRenderer lineDir;         �@  //�@LineRenderer�^�̕ϐ�lineDir��p�ӂ��܂��i��������������Line�������܂��j
    private Vector2 startPos;     //�@�����͂��߂̃I�u�W�F�N�g�̈ʒu�iVector2�j���i�[����ϐ���p�ӂ܂��@
    private Vector2 pullPos; 	�@    //�@�����I���̃J�[�\���ʒu�iVector2�j���i�[����ϐ���p�ӂ��܂�
    public float pullPower = 6.0f;              //��΂��͂̑傫���𒲐�����ϐ���p�ӂ��܂�
    public float maxPower = 2.0f;        �@  //�@������͂̍ő�l�𒲐�����ϐ���p�ӂ��܂��@

    private Camera mainCamera;           //  Camera�^�̕ϐ�mainCamera��p�ӂ��܂� 
    public GameObject[] WanageAll;
    private int WanageRandom;
    private CircleCollider2D CollWanage;
    public GameObject wgobjRed;
    public WanageGola wgRed;
    public GameObject wgobjBlue;
    public WanageGola wgBlue;
    public GameObject wgobjGreen;
    public WanageGola wgGreen;
    public void Start()
    {
        WanageRandom= Random.Range(0, 3);
        WanageAll[WanageRandom].SetActive(true);
        CollWanage = WanageAll[WanageRandom].GetComponent<CircleCollider2D>();
        rbPlayer = this.GetComponent<Rigidbody2D>();           //�@rigidbody�ϐ��ɁA����object��rigidbody�����܂�
        mainCamera = Camera.main;                                              �@//�@�ϐ�mainCamera�ɂ���Scene�̃��C���J���������܂�
        rbPlayer.bodyType = RigidbodyType2D.Kinematic;//�d�͖���
        
        wgobjRed = GameObject.Find("WanageRedGoal");
        wgRed = wgobjRed.GetComponent<WanageGola>();
        wgobjBlue = GameObject.Find("WanageBlueGoal");
        wgBlue = wgobjBlue.GetComponent<WanageGola>();
        wgobjGreen = GameObject.Find("WanageGreenGoal");
        wgGreen = wgobjGreen.GetComponent<WanageGola>();

    }
    void Update()
    {
        if (wgRed.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgRed.Wanagepredestroy = false;
        }
        if (wgBlue.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgBlue.Wanagepredestroy = false;
        }
        if (wgBlue.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgBlue.Wanagepredestroy = false;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("�}�E�X�N���b�N");
        startPos = Input.mousePosition;                                          	   �@//   �}�E�X�{�^�������������̈ʒu��statPos�ϐ��Ɋi�[���܂�
        startPos = mainCamera.ScreenToWorldPoint(startPos);       //   ���̈ʒu�����[���h���W�ɕϊ����ē��꒼���܂�
        this.lineDir.enabled = true;             //�@�}�E�X�������ꂽ���Ƀ��C�������_���[��On�ɂ��܂�
        this.lineDir.SetPosition(0, rbPlayer.position);      //�@���C�������_���[�̊J�n�ʒu�u�O�Ԗځv��rigidbody�ϐ��̈ʒu�ɂ��܂�
        this.lineDir.SetPosition(1, rbPlayer.position);	//�@���C�������_���[�̏I���̈ʒu�u�P�Ԗځv��rigidbody�ϐ��̈ʒu�ɂ��܂�

    }

    public void OnMouseDrag()
    {
        Debug.Log("�}�E�X�h���b�O");
        Vector2 position = Input.mousePosition;                                  �@	 �@//   �����Ă���}�E�X�{�^���̈ʒu��position�ϐ��Ɋi�[���܂�
        position = this.mainCamera.ScreenToWorldPoint(position); �@�@//   ���̈ʒu�����[���h���W�ɕϊ����ē��꒼���܂�
        pullPos = position - startPos;                                                            //   ���̃}�E�X�ʒu����X�^�[�g�����ʒu�������ƕ����x�N�g���������܂������܂�
        if (pullPos.magnitude > maxPower)		�@ //   ���̒���(magnitude)��maxPower��蒷����΁E�E
        {
            pullPos *= maxPower / pullPos.magnitude;		 //   maxPower�����̒���(magnitude)�Ŋ������l��pullPos �ɂ������l�����܂�
        }

        this.lineDir.SetPosition(0, this.rbPlayer.position);        //�@���C�������_���[�̊J�n�ʒu�u�O�Ԗځv��rbPlayer�ϐ��̈ʒu�ɂ��܂�
        this.lineDir.SetPosition(1, this.rbPlayer.position + this.pullPos);�@ //�@���C�������_���[�̏I���̈ʒu�u�P�Ԗځv��rbPlayer�ϐ��̈ʒu��pullPos�𑫂����ʒu�ɂ��܂�

    }

    public void OnMouseUp()
    {
        Debug.Log("�}�E�X�𗣂�");
        rbPlayer.bodyType = RigidbodyType2D.Dynamic;//�d�͗L��
        CollWanage.enabled = true;
        this.lineDir.enabled = false;			// �@���C�������_���[��Off�ɂ��āA���C���������܂�
        Pull(pullPos * -1 * pullPower);                       �@�@�@�@�@�@�@�@�@�@�@//�@�}�E�X�𗣂������APull�֐��Ɉ����upullPos�̕����ց\�i�}�C�i�X�j���������l�v��n���܂�
    }

    public void Pull(Vector2 shotPower)			�@ //�@Pull�֐��@�@����������ϐ�shotPower��p�ӂ��Ă����Ɏ󂯎��܂�
    {
        Debug.Log("��Ȃ��𓊂���!");
        this.rbPlayer.AddForce(shotPower, ForceMode2D.Impulse);�@ //�@rigidbody��AddForce�Ŏ󂯎�����x�N�g���֏Ռ��͂�^���܂�
    }
    
}


