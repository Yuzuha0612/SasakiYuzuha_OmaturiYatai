using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotTest : MonoBehaviour
{
    public GameObject ballObj;              // 　生成したいPrefab
    private Vector3 clickPos;                   // 　マウスのカーソル位置座標
    public float rapidDelta;                    //　毎フレーム、時間から引いていく数
    public float rapid;                                     //　ボールを出せるようになるまでの時間　float型の変数を用意します
    private float oriRapid;                             //　元のrapidに入れられていた値を格納しておく変数　 float型の変数を用意します
    public bool gameOn;                             //   ゲームが進行中か終わってるか、の2択のフラグ
    public float speed;                             //    飛ばす力の大きさの値です 
    public Transform canonPos;          //　 弾が出る場所の座標
    public ParticleSystem clickEffect;      //　クリックした場所に出すエフェクトを格納する変数です
    public GameObject playerObj;        //　 Playerのobjectを入れます
    private float degree;       //　回転角度（オイラー角、一般的な普通の角°で表す）
    public float rotSpeed = 0.8f;           //　回頭のスピードを入れる変数　0.8fくらいがよい
    private float oriRotSpeed;      //   もとの回転速度を格納する変数を用意します

    private void Start()
    {
        oriRapid = rapid;                       //editorでrapidに入れた値をoriRapidに格納します
        gameOn = true;                          //gameOnをtrueにします
        oriRotSpeed = this.GetComponent<GunRotTest>().rotSpeed;   // 開始時にインスペクターに入れたrotSpeed数値を入れます
    }
    void Update()
    {
        if (gameOn == true)
        {
            rapid -= rapidDelta;               //oriRapidから0.05を引きます
            clickPos = Input.mousePosition;          // Vector3でマウスの位置座標を取得する
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;

            //　 変数bulletDir　 muzzleとカーソルの位置を、ｘ、ｙ方向ベクトル化して入れます
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //マウスカーソルの方向に本体を向けるスクリプト
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);   //　カーソル位置をゲームスクリーンの座標にします

            //　砲塔オブジェクトの角度（０，０、ｚの値）に、Vector3の型（０，０、砲塔のz軸の角度から、回す目標角度までを、LearpAngle
            if (mouseWorldPos.y >= canonPos.position.y)        // マウスカーソルのｙの座標がcanonPosよりも（砲台の中心位置より）上ならば・・
            {
                rotSpeed = oriRotSpeed;      //　もとのrotSpeed（砲塔回転速度）を入れて戻します

                //（角度を補完しながらまわす関数）で、毎フレームrotSpeedの値の速さで回頭します
                playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime *
             rotSpeed));
            }
            if (Input.GetMouseButtonDown(0))                // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            {
                clickPos.z = 1.0f;                                   //Z軸の値に適当なz方向に＋の値を入れます
                                                                     // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                //エフェクトを押した座標に1回表示します
                clickEffect.Emit(1);


                if (rapid <= 0)          //もしoriRapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
                {
                    //プレイヤーオブジェクト（砲塔）傾きから、弾の飛ぶ方向を求めます
                    float canonRad = playerObj.transform.eulerAngles.z * Mathf.Deg2Rad;        // canonの傾きからラジアンを求めます
                    //canonRadの大きさから方向ベクトルを求めます
                    Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
                    //求められたcanonRadの値から、Sin関数の値を計算します　
                    float sin = Mathf.Sin(canonRad);
                    //　もし、変数sinの値が0.2fより大きくて、弾の出る場所よりもマウスが上にある時は・・
                    if (sin > 0.2f && (mouseWorldPos.y >= canonPos.position.y))
                    {
                        rotSpeed = oriRotSpeed;         //　変数rotSpeedに、始めの値を入れます

                        /////////////////////////////////////////////////////////////
                        // 　ボールを生成して発射するスクリプト
                        /////////////////////////////////////////////////////////////
                        //　muzzleの位置にボールを生成します
                        GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);

                        //　ボールにrigidbody2Dをいれて、canonAngleの方向に力を加えます
                        ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                        //　rapidに元のoriRapidの値を入れて戻します　
                        rapid = oriRapid;

                    }
                }
            }
        }
        else return;
    }


}
