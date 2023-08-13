using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRot : MonoBehaviour
{
    public GameObject GunDnagan;        // 生成したいPrefab
    private Vector3 clickPos;             // クリックした位置座標
    public float rapidDelta;                  	//　毎フレーム、時間から引いていく数
    public float rapid;                              //　ボールを出せるようになるまでの時間
    public float rapidTime;
    public Transform canonPos;	//　 弾が出る場所の座標
    private float oriRapid;                       //   元のrapidに入れられていた値を格納しておく変数
    public float speed;                //　飛ばす力の大きさの値です
    public ParticleSystem ClickEffect;
    public ParticleSystem ClickEffectOutline;
    AudioSource audioSource;
    public bool GunMouseMove;
    public AudioClip GunSE;

    public float rotSpeed = 0.8f;
    private float oriRotSpeed;
    // public SpriteRenderer RobotArm;
    //public SpriteRenderer Zoukin;

    public GameObject PlayerObject;
    private float Degreee;
    void Start()
    {
        oriRapid = rapid;             //editorでrapidに入れた値をoriRapidに格納します
        audioSource = GetComponent<AudioSource>();
        GunMouseMove = true;
        oriRotSpeed = this.GetComponent<GunRot>().rotSpeed;
    }

    void Update()
    {
        rapid -= rapidDelta;               //oriRapidから0.05を引きます
        //oriRapid -= rapidTime;
        clickPos = Input.mousePosition;
        //腕の回転
        Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
        Degreee = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
        // PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));
        //マウスカーソルの方向に本体を向けるスクリプト
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
        if (GunMouseMove == true)
        {
            if (mouseWorldPos.y >= canonPos.position.y)        // マウスカーソルのｙの座標がcanonPosよりも（砲台の中心位置より）上ならば・・
            {
                rotSpeed = oriRotSpeed;      //　もとのrotSpeed（砲塔回転速度）を入れて戻します

                //（角度を補完しながらまわす関数）で、毎フレームrotSpeedの値の速さで回頭します
                PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));
            }
            if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            {
                //clickPos = Input.mousePosition;          // Vector3型変数ｃlickPosに、マウスの現在位置座標を取得する
                clickPos.z = 1.0f;                                   //Z軸の値に適当な値を入れます
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffect.Emit(0);
                ClickEffectOutline.Play();      //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(GunSE);
                if (oriRapid <= 0)     //もしrapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
                {
                    // GameObject obj = Instantiate(GunDnagan, canonPos.position, GunDangan.transform.rotation);
                    //Vector3 canonAngle = Quaternion.Euler(PlayerObject.transform.eulerAngles) * new Vector3(1, 0, 0);
                    //AddForceでrigidbody２Dを付けた変数objのオブジェクトを飛ばします
                    //obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                    //プレイヤーオブジェクト（砲塔）傾きから、弾の飛ぶ方向を求めます
                    float canonRad = PlayerObject.transform.eulerAngles.z * Mathf.Deg2Rad;        // canonの傾きからラジアンを求めます
                                                                                               //canonRadの大きさから方向ベクトルを求めます
                    Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
                    //求められたcanonRadの値から、Sin関数の値を計算します　
                    float sin = Mathf.Sin(canonRad);

                   // oriRapid = rapid;               //　 rapidに元の値を入れて戻します
                    Debug.Log(canonAngle);
                    //　もし、変数sinの値が0.2fより大きくて、弾の出る場所よりもマウスが上にある時は・・
                    if (sin > 0.2f && (mouseWorldPos.y >= canonPos.position.y))
                    {
                        rotSpeed = oriRotSpeed;
                        //　muzzleの位置にボールを生成します
                        GameObject ball = Instantiate(GunDnagan, canonPos.position, GunDnagan.transform.rotation);
                        //　ボールにrigidbody2Dをいれて、canonAngleの方向に力を加えます
                        ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);
                        //　rapidに元のoriRapidの値を入れて戻します　
                        rapid = oriRapid;
                    }
                }
                else return;
            }
        }
        IEnumerator RobotArmMouseCoroutine()
        {
            yield return new WaitForSecondsRealtime(5.0f);

        }
        //何かにぶつかったら、1秒後にぶつかった場所の座標を取得して、そこから伸縮
    }
}
