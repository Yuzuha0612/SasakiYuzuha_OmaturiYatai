using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint6 : MonoBehaviour
{
    Vector3 mousePos;           //�@Vector3�^�̕ϐ�mousePos��p�ӂ��܂�

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // �@�J��������̃}�E�X�J�[�\���̈ʒu���W���擾����
        mousePos.z = 10.0f;                                       // �@z�̒l�ɓK���Ȓl�����܂�
        Debug.Log(mousePos);                               //�@Debug.Log�Œl��\�������܂�
    }
}