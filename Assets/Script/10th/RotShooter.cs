using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotShooter : MonoBehaviour
{
    public GameObject ballObj;               // 生成したいPrefab
    public GameObject BlueballObj;
    public GameObject YellowballObj;               // 生成したいPrefab
    public GameObject GreenballObj;
    private Vector3 clickPos;                    // クリックした位置座標
    public float rapid;                                   //　ボールを出せるようになるまでの時間
    private float oriRapid;                           //元のrapidに入れられていた値を格納しておく変数

    public float speed;                              //    飛ばす力の大きさの値です 
    public GameObject playerObj;               //   Playerのobjectを入れます
    public Transform canonPos;           // 弾が出る場所の座標
    public ParticleSystem clickEffect;   //　クリックした場所に出すエフェクトを格納する変数です

    private float degree;                             //回転角度（オイラー角、一般的な普通の角°で表す）
    public float rotSpeed;                            //回転のスピードを入れる変数

    public float canonRad;       //回転のラジアンを入れる変数を用意します
    public Vector3 canonAngle;       //回転角を入れる変数canonAngleを用意します

    public Text CoinText;
    public int CoinCount = 0;

    public int RandomBall;

    public Image Hiyokoimage;
    public Image Azarasiimage;
    public Image Hituziimage;

    private void Start()
    {
        oriRapid = rapid;               //editorでrapidに入れた値をoriRapidに格納します
    }
    void Update()
    {
        CoinText.GetComponent<Text>().text = "×" + CoinCount;
        clickPos = Input.mousePosition;          // Vector3でマウスがクリックした位置座標を取得する
            clickPos.z = 10.0f;                                   // そこでに適当な値を入れます
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
            degree = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
            //アークタンジェントで求めた角度（ラジアン表示）をオイラー角に変換します
            playerObj.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(playerObj.transform.eulerAngles.z, degree,
        Time.deltaTime * rotSpeed));

            canonRad = playerObj.transform.eulerAngles.z * Mathf.Deg2Rad; //　回転したラジアンを求めます
            canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0); //ラジアンからVector3型の角度を求めます
            rapid -= 0.05f;                   //　oriRapidから0.05を引きます

            if (rapid <= 0)          //　もしoriRapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
            {
            if (Input.GetMouseButtonDown(1))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            {
                RandomBall = Random.Range(1, 5);
                if (RandomBall == 1)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ballという名前で、「弾」をcanonPosの位置に作ります
                        GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //　ballオブジェクトの上方向を右方向にして倒します
                                                                        // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }else if (RandomBall == 2)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ballという名前で、「弾」をcanonPosの位置に作ります
                        GameObject ball = Instantiate(BlueballObj, canonPos.position, BlueballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //　ballオブジェクトの上方向を右方向にして倒します
                                                                        // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }
                else if (RandomBall == 3)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ballという名前で、「弾」をcanonPosの位置に作ります
                        GameObject ball = Instantiate(YellowballObj, canonPos.position, YellowballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //　ballオブジェクトの上方向を右方向にして倒します
                                                                        // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }
                else if (RandomBall == 4)
                {
                    if (CoinCount > 0)
                    {
                        CoinCount--;
                        // ballという名前で、「弾」をcanonPosの位置に作ります
                        GameObject ball = Instantiate(GreenballObj, canonPos.position, GreenballObj.transform.rotation);
                        ball.transform.up = playerObj.transform.right;  //　ballオブジェクトの上方向を右方向にして倒します
                                                                        // ScreenToWorldPoint(位置(Vector3))　スクリーン座標をワールド座標に変換する
                        clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                        clickEffect.Emit(1);
                    }
                    else if (CoinCount <= 0)
                    {
                        CoinCount = 0;
                    }
                }

            }
                rapid = oriRapid;           //　rapidに元のoriRapidの値を入れて戻します　
            
        }
        else return;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinCount++;
            CoinText.GetComponent<Text>().text = "×" + CoinCount;
        }
        if (other.gameObject.tag == "Azarasi")
        {
            Azarasiimage.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Hiyoko")
        {
            Hiyokoimage.enabled = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Hituzi")
        {
            Hituziimage.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
