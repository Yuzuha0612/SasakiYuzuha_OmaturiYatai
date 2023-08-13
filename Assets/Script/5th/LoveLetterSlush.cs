using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetterSlush : MonoBehaviour
{
    public GameObject ballObjOpen;
    public GameObject ballObj;        // 生成したいPrefab
    private Vector3 clickPos;             // クリックした位置座標
    public int rapid;                              //　ボールを出せるようになるまでの時間
    private int oriRapid;                       //   元のrapidに入れられていた値を格納しておく変数
    public bool gameOn;          //   ゲームが進行中か終わってるか、の2択のフラグ
    public float speed;                //　飛ばす力の大きさの値です
    public GameObject NowLetter;
    public Vector2 objDir;
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    public bool FirstStage;
    void Start()
    {
        FirstStage = true;
       // NowLetter = ballObj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FirstStage = false;
        }
        if (FirstStage == true)
        {
            NowLetter = ballObjOpen;
        }else if(FirstStage == false)
        {
            NowLetter = ballObj;
        }
        if (Input.GetMouseButtonDown(0))        // もしマウスで左クリック("0"が左クリックに初期設定してあります)したら・・
        {
            clickPos = Input.mousePosition;          // Vector3型の変数に、マウスがクリックした位置座標を取得する
                                                     //デバッグLog：clickPosの値を書き出します　
            Debug.Log(clickPos);
            // Z軸の値が０だと表示されません、（ScreenToWorldPointに必要）、そこでに適当な値（ここでは10f）をz値に入れます
            clickPos.z = 10.0f;
            ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
            ClickEffect.Play();　		//　一連のパーティクルの場合、Play()メソッドで再生します
            ClickEffect.Emit(0);
            ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
            ClickEffectOutline.Play();　		//　一連のパーティクルの場合、Play()メソッドで再生します
            ClickEffectOutline.Emit(0);
            GameObject obj = Instantiate(NowLetter, Camera.main.ScreenToWorldPoint(clickPos), NowLetter.transform.rotation);
            //出現させたobjにRigidbodyを入れてAddForceで物理的な力を加えます
            obj.GetComponent<Rigidbody2D>().AddForce (objDir * speed);	
            oriRapid = rapid;   //　oriRapidに元のrapidの値を入れて戻します　
            Destroy(NowLetter, 3.0f);

        }
        else return;
    }
    }

