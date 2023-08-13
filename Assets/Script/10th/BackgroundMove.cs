using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public GameObject player;	 // �v���C���[������ϐ���p�ӂ��܂�
    public Vector2 movelimit; 	// �w�i�̈ړ��͈́@�ǂꂾ���ړ��������邩
    private int screenX;           	// �Q�[���X�N���[���̉��h�b�g��
    private int screenY;            	// �Q�[���X�N���[���̏c�h�b�g��

    private void Start()
    {
        screenX = Screen.width;         //���݂̃X�N���[���̉��h�b�g����ϐ�screenX�Ɋi�[���܂��A16�F9�Ȃ�768�h�b�g
        screenY = Screen.height;        //���݂̃X�N���[���̏c�h�b�g����ϐ�screenY�Ɋi�[���܂��A16�F9�Ȃ�432�h�b�g
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;                  //�v���C���[�̌��ݒn���擾����
        Vector2 limit = new Vector2(screenX / 200, screenY / 200);        // �X�N���[����ʃh�b�g���𔼕��̒l�ɂ��Ċi�[�����@�@//�@�i100pixel���P�Ȃ̂ŁA1/2�A�����100�Ŋ����Ă܂��A�܂�Q�O�O�Ŋ����Ă܂��j

        // InverseLerp�F�@�v���C���[����ʂ̂ǂ��̈ʒu�ɑ��݂���̂����A0 ���� 1 ��%�l�ŏo���܂��A������P��������āA�u�w�i�v�̈ʒu�����œ��܂�
        float dx = 1 - Mathf.InverseLerp(-limit.x, limit.x, playerPos.x);           //768�h�b�g�𔼕��Ɋ����āA�[384����+384�܂ł��|�W�V�����͈̔�
        float dy = 1 - Mathf.InverseLerp(-limit.y, limit.y, playerPos.y);           //432�𔼕��Ɋ����āA�[216����+216�܂ł��|�W�V�����͈̔�

        float x = Mathf.Lerp(-movelimit.x, movelimit.x, dx);        �@// �v���C���[�̌��ݒn����w�i�̕\���ʒu���W���Z�o����
        float y = Mathf.Lerp(-movelimit.y, movelimit.y, dy);      // �v���C���[�̌��ݒn����w�i�̕\���ʒu���W���Z�o����

        transform.position = new Vector3(x, y, 0);		 // �w�i�̕\���ʒu���X�V����
    }
}

