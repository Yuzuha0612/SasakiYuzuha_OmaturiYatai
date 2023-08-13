using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragMove : MonoBehaviour
{
    GameObject gameCtrl; //　GameControllerを探してきて入れる変数を用意します
    private bool gameOn;  //　bool型の変数gameOnを用意します
    private Vector2 targetPos;   //　Vector2型の変数targetPosを用意します
    private Vector2 lastMousePos;        //　「最後にマウスのあった場所」を格納する変数を用意します
    public GameObject dragPointObj;          //  dragPointのオブジェクトをいれる変数
    public GameObject WataameAll;

    void Start()
    {
        gameCtrl = GameObject.Find("GameController");        //　GameControllerオブジェクトを探して格納します
      
    }
    void Update()
    {
            lastMousePos = Input.mousePosition;             // そのマウスの位置の座標を取得する
            targetPos = Camera.main.ScreenToWorldPoint(lastMousePos);  // マウスカーソルの位置をワールド座標targetPosに変換して入れます

            if (Input.GetMouseButton(0))// もし、真ん中のマウスボタンが押されたら（押し続けた状態も含む）
            {
                WataameAll.SetActive(true);
                dragPointObj.transform.position = targetPos;  //　dragPointObjの位置をtargetPosの位置にします
                                                              // dragPointObjオブジェクトを生成します（マウスカーソルの位置にスプライトを置いて行きます）
                Instantiate(dragPointObj, targetPos, dragPointObj.transform.rotation);
        }else
        { 
            WataameAll.SetActive(false); 
        }
        
        //else return;
    }
}