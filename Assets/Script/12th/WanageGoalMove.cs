using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanageGoalMove : MonoBehaviour
{
    private Transform oriPos;
    public float MoveShelfx;
    public bool isStartShelf;
    void Start()
    {
        isStartShelf = false;
        oriPos = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(MoveShelfx, 0, 0);  //�@�ʒu�����������ĕ\������transform.translate()�֐��ł�������0.05f���炵�܂��@
        if (transform.position.x > 2.7f)  //�@x���̈ʒu��-10f��菬�����Ȃ�����E�E
        {
            transform.position = new Vector3(-2.7f, oriPos.position.y, 0); //�@���̈ʒu�ɖ߂��܂��i���̒l�����Ƃ̍����ɂ��Ă��܂��j     
        }

    }
}