using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragEffect : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;              // �ϐ�mousePos�Ƀ}�E�X�̃J�[�\���ʒu�����܂�
        mousePos.z = 10f;                                                                 //mousePos�̂��l��10�ł�

        //mousePos�̒l���X�N���[���̃|�W�V�����ɕϊ����ĕϐ�corsorPos�ɓ���܂�
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(mousePos);
        //���̃I�u�W�F�N�g�̈ʒu��cusorPos�̈ʒu�ɂ��܂�
        transform.position = cursorPos;
    }

}
