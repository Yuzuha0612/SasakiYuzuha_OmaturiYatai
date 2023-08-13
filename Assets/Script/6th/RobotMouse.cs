using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouse : MonoBehaviour
{
    public GameObject RobotHand;        // 生成したいPrefab
    private Vector3 clickPos;             // クリックした位置座標
    public float rapid;                              //　ボールを出せるようになるまでの時間
    public float rapidTime;
    public Transform canonPos;	//　 弾が出る場所の座標
    private float oriRapid;                       //   元のrapidに入れられていた値を格納しておく変数
    public float speed;                //　飛ばす力の大きさの値です
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    AudioSource audioSource;
    public bool RobotMouseMove;
    public AudioClip RobotArmSE;
    void Start()
    {
        oriRapid = rapid;             //editorでrapidに入れた値をoriRapidに格納します
        audioSource = GetComponent<AudioSource>();
        RobotMouseMove = true;
    }

    void Update()
    {

        oriRapid -= rapidTime;
        if (RobotMouseMove == true)
        {
            if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            {
                clickPos = Input.mousePosition;          // Vector3型変数ｃlickPosに、マウスの現在位置座標を取得する
                clickPos.z = 10.0f;                                   //Z軸の値に適当な値を入れます
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffect.Emit(0);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.Play();      //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(RobotArmSE);
                if (oriRapid <= 0.0f == true)     //もしrapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
                {
                    GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                    //弾の飛ぶ方向ベクトルbulletDirに、弾の出るcanonPosの位置とマウスのクリックした位置を引き算した値に、
                    //(1,1,0)をかけて（Scale）、Z軸の値を0にします、それをnormalizedで「単位ベクトル」に直します
                    Vector3 bulletDir = Vector3.Scale((ClickEffect.transform.position - canonPos.position), new Vector3(1, 1, 0)).normalized;
                    obj.GetComponent<Rigidbody2D>().AddForce(bulletDir * speed); //AddForceでrigidbodyを付けたballを飛ばします
                    oriRapid = rapid;               //　 rapidに元の値を入れて戻します　
                }
            }
            else return;
        }
    }
    IEnumerator RobotArmMouseCoroutine()
    {
        yield return new WaitForSecondsRealtime(5.0f);

    }

 }

