using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragEffect : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;              // 変数mousePosにマウスのカーソル位置を入れます
        mousePos.z = 10f;                                                                 //mousePosのｚ値は10です

        //mousePosの値をスクリーンのポジションに変換して変数corsorPosに入れます
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(mousePos);
        //このオブジェクトの位置をcusorPosの位置にします
        transform.position = cursorPos;
    }

}
