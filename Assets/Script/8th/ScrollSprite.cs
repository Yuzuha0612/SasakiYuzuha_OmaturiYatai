using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSprite : MonoBehaviour
{
    public bool xDir;			//　ｘ方向に移動するときは、これをonにします
    public bool yDir;			//　y方向に移動するときは、これをonにします
    private Transform oriPos;		 //　元の位置を格納しておく変数
    private float xPos;			//　x方向の値を格納しておく変数
    private float yPos;			//　y方向の値を格納しておく変数
    public bool random = false;		//　ランダムな位置に出現させたい場合にonにします
    public float xspriteSpeed = -0.05f;	//　x方向の移動スピードを格納しておく変数
    public float yspriteSpeed = -0.05f;	//　y方向の移動スピードを格納しておく変数

    void Start()
    {
        oriPos = this.transform;		//　元のx方向の移動スピードを格納しておく変数
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ReadygoCoroutine8());
            
        }
            if (xDir == true)				 //　ｘDirフラグがon（横方向に移動）ならば・・
        {
            transform.Translate(xspriteSpeed, 0, 0);	 //　Translate関数でｘ方向に変数xspriteSpeedの値だけ毎フレーム移動させます
            if (transform.position.x < -10.0f)		 //　もしｘの位置が―10以下になったら・・
            {
                if (random == true)			 //　そして、randomフラグがonになっていたら・・
                {
                    yPos = Random.Range(-2.8f, 4.2f);		//　ｙPos（縦方向）の出現位置を（－４～４、＊ここは各自変更可）のどれかにします
                }

                else if (random == false)			//　でなくて、randomフラグがoffになっていたら・・
                {
                    yPos = oriPos.position.y;		 //　ｙPos（縦方向）の出現位置をもとの位置にします
                }

                transform.position = new Vector3(10.0f, yPos, 0);　　//　このオブジェクトの位置を（10、ｙ位置変数値、０）にセットします
            }
        }
        if (yDir == true)					 //　yDirフラグがon（縦方向に移動）ならば・・
        {
            transform.Translate(0f, yspriteSpeed, 0f);	 //　Translate関数でy方向に変数yspriteSpeedの値だけ毎フレーム移動させます
            if (transform.position.y < -10.0f)		 //　もしyの位置が―10以下になったら・・
            {
                if (random == true)			 //　そして、randomフラグがonになっていたら・・
                {
                    xPos = Random.Range(-10.0f, 10.0f);	 //　xPos（縦方向）の出現位置を（－10～10、＊ここは各自変更可）のどれかにします
                }
                else if (random == false)			 //　でなくて、randomフラグがoffになっていたら・・
                {
                    xPos = oriPos.position.x;		 //　xPos（横方向）の出現位置をもとの位置にします
                }
                transform.position = new Vector3(xPos, 10.0f, 0); //　このオブジェクトの位置を（x位置変数値、 10、 ０）にセットします
            }
        }
      }
    IEnumerator ReadygoCoroutine8()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        xDir = true;
    }
    }
