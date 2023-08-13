using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouseDrag : MonoBehaviour
{
    public Rigidbody2D rbPlayer;          //rigidbodyを格納する変数を用意します
    public Vector2 startPos;     //　引きはじめのオブジェクトの位置（Vector2）を格納する変数を用意ます　
    public Vector2 pullPos; 	　    //　引き終わりのカーソル位置（Vector2）を格納する変数を用意します
    public float pullPower = 6.0f;              //飛ばす力の大きさを調整する変数を用意します

    public Camera mainCamera;           //  Camera型の変数mainCameraを用意します 


    public void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();           //　rigidbody変数に、このobjectのrigidbodyを入れます
        mainCamera = Camera.main;                                              　//　変数mainCameraにこのSceneのメインカメラを入れます
    }
    public void OnMouseDown()
    {
        startPos = Input.mousePosition;                                          	   　//   マウスボタンを押した時の位置をstatPos変数に格納します
        startPos = mainCamera.ScreenToWorldPoint(startPos);       //   その位置をワールド座標に変換して入れ直します
    }

    public void OnMouseDrag()
    {
        Vector2 position = Input.mousePosition;                                  　	 　//   押しているマウスボタンの位置をposition変数に格納します
        position = this.mainCamera.ScreenToWorldPoint(position); 　　//   その位置をワールド座標に変換して入れ直します
        pullPos = position - startPos;                                                            //   今のマウス位置からスタートした位置を引くと方向ベクトルが得られますがきます
    }

    public void OnMouseUp()
    {
        Pull(pullPos * -1 * pullPower);                       　　　　　　　　　　　//　マウスを離した時、Pull関数に引数「pullPosの方向へ―（マイナス）をかけた値」を渡します
    }

    public void Pull(Vector2 shotPower)			　 //　Pull関数　　引数を入れる変数shotPowerを用意してそこに受け取ります
    {
        this.rbPlayer.AddForce(shotPower, ForceMode2D.Impulse);　 //　rigidbodyにAddForceで受け取ったベクトルへ衝撃力を与えます
    }
}