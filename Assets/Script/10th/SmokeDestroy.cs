using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDestroy : MonoBehaviour
{
    public float lifetime = 2.0f;            //�@�ϐ�lifetime������܂�

    void Start()
    {
        Destroy(gameObject, lifetime); //�@Start���\�b�h�ŁA�������Ԃ�^���Ă����܂�
    }

}
