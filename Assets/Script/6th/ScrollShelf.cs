using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollShelf : MonoBehaviour
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
           
            transform.Translate(MoveShelfx, 0, 0);  //　位置を書き換えて表示するtransform.translate()関数でｘ方向に0.05fずらします　
            if (transform.position.x < -16.0f)  //　x軸の位置が-10fより小さくなったら・・
            {
                transform.position = new Vector3(0f, oriPos.position.y, 0); //　元の位置に戻します（ｙの値をもとの高さにしています）     
            }
        
    }
    }
