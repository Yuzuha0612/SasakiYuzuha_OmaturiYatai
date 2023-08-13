using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint6 : MonoBehaviour
{
    Vector3 mousePos;           //　Vector3型の変数mousePosを用意します

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // 　カメラからのマウスカーソルの位置座標を取得する
        mousePos.z = 10.0f;                                       // 　zの値に適当な値を入れます
        Debug.Log(mousePos);                               //　Debug.Logで値を表示させます
    }
}