using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouseCanon7Ver2 : MonoBehaviour
{
    public GameObject ballObj;
    private Vector3 clickPos;                   // 　マウスのカーソル位置座標
    public float rapidDelta;                    //　毎フレーム、時間から引いていく数
    private float oriRapid;
    public float rapid;
    public bool gameOn;                              //   ゲームが進行中か終わってるか、の2択のフラグ
    public float speed;                              //    飛ばす力の大きさの値です 
    public Transform canonPos;            //　 弾が出る場所の座標
    public ParticleSystem clickEffect;   //　クリックした場所に出すエフェクトを格納する変数です
    public float rotSpeed = 0.8f;
    public GameObject playerObj;           //　 Playerのobjectを入れます
    private float degree;              //　回転角度（オイラー角、一般的な普通の角°で表す）

    public SpriteRenderer RobotArm;
    public SpriteRenderer Zoukin;
    private void Start()
    {
        oriRapid = rapid;               //editorでrapidに入れた値をoriRapidに格納します
        gameOn = true;                  //gameOnをtrueにします
    }

    void Update()
    {
        if (gameOn == true)
        {
            oriRapid -= rapidDelta;                            //毎フレーム変数oriRapidから変数rapidDeltaの値を引いて、また変数oriRapidに戻します
            clickPos = Input.mousePosition;
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
            //アークタンジェントで求めた角度（ラジアン表示）をオイラー角に変換します
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;

            //playerObjのz軸方向の回転角度（０，０、ｚの値）に変数degreeを入れます
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree, Time.deltaTime * rotSpeed));

            if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            {
                clickPos.z = 10.0f;                                   //Z軸の値に適当なz軸方向に＋の値を入れます
                                                                      // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                clickEffect.Emit(1);
                Zoukin.enabled = false;
                RobotArm.enabled = false;
                if (oriRapid <= 0.0f == true)     //もしoriRapidの値が０以下だったら、弾が出るようになります
                {
                    //　オブジェクトcanonPosの場所に、変数ballObjにセットされたObjectを出現させます
                    GameObject obj = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
                    //AddForceでrigidbody２Dを付けた変数objのオブジェクトを飛ばします
                    Vector3 canonAngle = Quaternion.Euler(playerObj.transform.eulerAngles) * new Vector3(1, 0, 0);
                    obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                    //　 変数oriRapidに元の値を入れて戻します
                    oriRapid = rapid;
                    Debug.Log(canonAngle);
                }
            }
        }
        else return;
    }
}