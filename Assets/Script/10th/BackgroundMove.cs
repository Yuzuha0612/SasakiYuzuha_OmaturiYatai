using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public GameObject player;	 // プレイヤーを入れる変数を用意します
    public Vector2 movelimit; 	// 背景の移動範囲　どれだけ移動させられるか
    private int screenX;           	// ゲームスクリーンの横ドット数
    private int screenY;            	// ゲームスクリーンの縦ドット数

    private void Start()
    {
        screenX = Screen.width;         //現在のスクリーンの横ドット数を変数screenXに格納します、16：9なら768ドット
        screenY = Screen.height;        //現在のスクリーンの縦ドット数を変数screenYに格納します、16：9なら432ドット
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;                  //プレイヤーの現在地を取得する
        Vector2 limit = new Vector2(screenX / 200, screenY / 200);        // スクリーン画面ドット数を半分の値にして格納する　　//　（100pixel＝１なので、1/2、さらに100で割ってます、つまり２００で割ってます）

        // InverseLerp：　プレイヤーが画面のどこの位置に存在するのかを、0 から 1 の%値で出します、それを１から引いて、「背景」の位置を％で得ます
        float dx = 1 - Mathf.InverseLerp(-limit.x, limit.x, playerPos.x);           //768ドットを半分に割って、ー384から+384までがポジションの範囲
        float dy = 1 - Mathf.InverseLerp(-limit.y, limit.y, playerPos.y);           //432を半分に割って、ー216から+216までがポジションの範囲

        float x = Mathf.Lerp(-movelimit.x, movelimit.x, dx);        　// プレイヤーの現在地から背景の表示位置座標を算出する
        float y = Mathf.Lerp(-movelimit.y, movelimit.y, dy);      // プレイヤーの現在地から背景の表示位置座標を算出する

        transform.position = new Vector3(x, y, 0);		 // 背景の表示位置を更新する
    }
}

