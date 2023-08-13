using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouseDrag : MonoBehaviour
{
    public Rigidbody2D rbPlayer;          //rigidbody���i�[����ϐ���p�ӂ��܂�
    public Vector2 startPos;     //�@�����͂��߂̃I�u�W�F�N�g�̈ʒu�iVector2�j���i�[����ϐ���p�ӂ܂��@
    public Vector2 pullPos; 	�@    //�@�����I���̃J�[�\���ʒu�iVector2�j���i�[����ϐ���p�ӂ��܂�
    public float pullPower = 6.0f;              //��΂��͂̑傫���𒲐�����ϐ���p�ӂ��܂�

    public Camera mainCamera;           //  Camera�^�̕ϐ�mainCamera��p�ӂ��܂� 


    public void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();           //�@rigidbody�ϐ��ɁA����object��rigidbody�����܂�
        mainCamera = Camera.main;                                              �@//�@�ϐ�mainCamera�ɂ���Scene�̃��C���J���������܂�
    }
    public void OnMouseDown()
    {
        startPos = Input.mousePosition;                                          	   �@//   �}�E�X�{�^�������������̈ʒu��statPos�ϐ��Ɋi�[���܂�
        startPos = mainCamera.ScreenToWorldPoint(startPos);       //   ���̈ʒu�����[���h���W�ɕϊ����ē��꒼���܂�
    }

    public void OnMouseDrag()
    {
        Vector2 position = Input.mousePosition;                                  �@	 �@//   �����Ă���}�E�X�{�^���̈ʒu��position�ϐ��Ɋi�[���܂�
        position = this.mainCamera.ScreenToWorldPoint(position); �@�@//   ���̈ʒu�����[���h���W�ɕϊ����ē��꒼���܂�
        pullPos = position - startPos;                                                            //   ���̃}�E�X�ʒu����X�^�[�g�����ʒu�������ƕ����x�N�g���������܂������܂�
    }

    public void OnMouseUp()
    {
        Pull(pullPos * -1 * pullPower);                       �@�@�@�@�@�@�@�@�@�@�@//�@�}�E�X�𗣂������APull�֐��Ɉ����upullPos�̕����ց\�i�}�C�i�X�j���������l�v��n���܂�
    }

    public void Pull(Vector2 shotPower)			�@ //�@Pull�֐��@�@����������ϐ�shotPower��p�ӂ��Ă����Ɏ󂯎��܂�
    {
        this.rbPlayer.AddForce(shotPower, ForceMode2D.Impulse);�@ //�@rigidbody��AddForce�Ŏ󂯎�����x�N�g���֏Ռ��͂�^���܂�
    }
}