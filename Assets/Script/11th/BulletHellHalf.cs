using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellHalf : MonoBehaviour
{
    public int bulletNum = 5;               //　同時に撃ち出す弾の数
    private Vector3 clickPos;                    // クリックした位置座標
    public GameObject bullet;                        //　弾のオブジェクトを格納する変数
    public GameObject playerObj;            　//　プレイヤーオブジェクト（自機）を格納します
    public Transform canonPos;　　　　　//　弾が生成される座標、（ロケットの弾の出る場所のオブジェクト）
    public ParticleSystem clickEffect;   　　//　クリックした場所に出すエフェクトを格納する変数です
    private float degree;                             　//回転角度（オイラー角、一般的な普通の角°で表す）
    public float rotSpeed;                            　//回転のスピードを入れる変数
    public float moveSpeed = 5.0f;      　　//　弾の移動速度を入れます

    public float startAngle = 45.0f; 　　　//　はじまりの角度
    public float endAngle = 135.0f;   　  　//　おわりの角度
    private float angleStep;		 //　弾の間隔の角度	
    private Vector3 shipAngle;  　　　    //　プレイヤーオブジェクトの傾きを格納します


    void Start()
    {
        angleStep = (endAngle - startAngle) / (bulletNum - 1); 　　　　　 //　始まりと終わりの角度を引いて、弾数-1で割ることで弾間隔を得ます
       
    }
    private void Update()
    {
            clickPos = Input.mousePosition;          // Vector3でマウスの位置座標を取得する
            clickPos.z = 10.0f;                                   　　// そこのz値に適当な値を入れます
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //アークタンジェントで求めた角度（ラジアン表示）をオイラー角に変換します
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime * rotSpeed));

            if (Input.GetMouseButtonDown(0))                // もしマウスボタンが押されたら・・
            {
                shipAngle = playerObj.transform.eulerAngles;    //　このプレイヤー機の現在の傾き（オイラー角度）を（Vector3型）を格納します
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                clickEffect.Emit(1);
                Shot(bulletNum);             //　Shotメソッドに飛びます、同時に引数bulletNum（何発同時に撃つのか？の値）を送ります
            }
        
    }
    private void Shot(int bulletNumber)         //　Shot（引数は整数の「弾」の値）メソッドです（新たに定義しますが、値は送られた元の値を引き継いでいます）
    {
        if (bulletNumber > 1) 　　　//　弾の値が1より大きければ・・
        {
            float angle = startAngle;          //　変数angle変数に一発目の角度を入れ、位置を初期化します

            for (int i = 0; i < bulletNumber; i++)      //　forの繰り返し構文、（変数iに毎回1づつ足していき、変数bulletNumの数に達したら、繰り返しを抜けます）
            {

                //弾の発射地点から、はじまりの角度＋このプレイヤーオブジェクトの傾き角（ｚ軸）を足し、オブジェクトが90度寝ているので、それを差し引いた場所になります
                float bulletXDir = canonPos.transform.localPosition.x + Mathf.Cos((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);
                float bulletYDir = canonPos.transform.localPosition.y + Mathf.Sin((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);

                Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    弾の位置座標をbulletPosに入れます
                                                                                                     //　弾の飛ぶ方向bulletMoveDirに、発射場所と弾の角度の場所の差からベクトルを算出して単位ベクトル化して、prefabの移動スピードをかけます
                Vector2 bulletMoveDir = (bulletPos - (Vector2)canonPos.transform.localPosition).normalized * moveSpeed;

                //　弾のprefabをspawnPoint の場所に生成します
                GameObject fireBall = Instantiate(bullet, (Vector2)canonPos.transform.position, Quaternion.identity);
                //　生成したprefabにRigidbodyを入れて、その速度ベクトル成分velocityに、bulletMoveDirのx,yベクトル成分を入れます
                fireBall.transform.up = bulletMoveDir;  		//　fireBallオブジェクトの上方向をbulletMoveDirの方向にします
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);
                angle += angleStep;    			//　変数angleにangleStep の値を足して次の弾の位置を計算して繰り返し生成します

                Destroy(fireBall, 4.0f);    			//生成されたObject は4秒後に破壊します
            }
        }
        else //　もしそれ以外なら（「弾」の数が1つ以下の場合・・）
        {
            float angle = 90.0f;    //　変数angleに90.0fを入れます（オブジェクトのy軸方向にまっすぐ）

            //弾の発射地点から、はじまりの角度＋このプレイヤーオブジェクトの傾き角（ｚ軸）を足し、オブジェクトが90度寝ているので、それを差し引いた場所になります
            float bulletXDir = canonPos.transform.localPosition.x + Mathf.Cos((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);
            float bulletYDir = canonPos.transform.localPosition.y + Mathf.Sin((angle + shipAngle.z - 90.0f) * 2f * Mathf.PI / 360f);

            Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    弾の位置座標をbulletPosに入れます
                                                                                                 //　弾の飛ぶ方向bulletMoveDirに、発射場所と弾の角度の場所の差からベクトルを算出して単位ベクトル化して、prefabの移動スピードをかけます
            Vector2 bulletMoveDir = (bulletPos - (Vector2)canonPos.transform.localPosition).normalized * moveSpeed;

            //　弾のprefabをspawnPoint の場所に生成します
            GameObject fireBall = Instantiate(bullet, (Vector2)canonPos.transform.position, Quaternion.identity);
            fireBall.transform.up = bulletMoveDir; 		//　fireBallオブジェクトの上方向をbulletMoveDirの方向にします
            //　生成したprefabにRigidbodyを入れて、その速度ベクトル成分velocityに、bulletMoveDirのx,yベクトル成分を入れます
            fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

            Destroy(fireBall, 4.0f);     //生成されたObject は4秒後に破壊します
        }
    }

}
