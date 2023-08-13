using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMouseCanon7 : MonoBehaviour
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

    public float rotSpeed = 0.8f;

    public SpriteRenderer RobotArm;
    public SpriteRenderer Zoukin;

    public GameObject PlayerObject;
    private float Degreee;
    void Start()
    {
        oriRapid = rapid;             //editorでrapidに入れた値をoriRapidに格納します
        audioSource = GetComponent<AudioSource>();
        RobotMouseMove = true;
    }

    void Update()
    {

        oriRapid -= rapidTime;
       clickPos = Input.mousePosition;
        if (RobotMouseMove == true)
        {

            //腕の回転
            Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
            Degreee = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
            PlayerObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.z, Degreee, Time.deltaTime * rotSpeed));

            // if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
            if (Input.GetMouseButtonDown(0))
            {
                //clickPos = Input.mousePosition;          // Vector3型変数ｃlickPosに、マウスの現在位置座標を取得する
                clickPos.z = 10.0f;                                   //Z軸の値に適当な値を入れます
                ClickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffectOutline.transform.position = Camera.main.ScreenToWorldPoint(clickPos);
                ClickEffect.Play();         //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffect.Emit(0);
                ClickEffectOutline.Play();      //　一連のパーティクルの場合、Play()メソッドで再生します
                ClickEffectOutline.Emit(0);
                RobotArmMouseCoroutine();
                audioSource.PlayOneShot(RobotArmSE);
                Zoukin.enabled = false;
                RobotArm.enabled = false;
                if (oriRapid <= 0.0f == true)     //もしrapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
                {
                    /*  GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                      Vector3 bulletDir2 = Vector3.Scale((ClickEffect.transform.position - canonPos.position), new Vector3(1, 1, 0)).normalized;
                      obj.GetComponent<Rigidbody2D>().AddForce(bulletDir2 * speed); //AddForceでrigidbodyを付けたballを飛ばします*/
                    GameObject obj = Instantiate(RobotHand, canonPos.position, RobotHand.transform.rotation);
                    Vector3 canonAngle = Quaternion.Euler(PlayerObject.transform.eulerAngles) * new Vector3(1, 0, 0) ;
                    //AddForceでrigidbody２Dを付けた変数objのオブジェクトを飛ばします
                    obj.GetComponent<Rigidbody2D>().AddForce(canonAngle * speed);

                    oriRapid = rapid;               //　 rapidに元の値を入れて戻します
                    Debug.Log(canonAngle);
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
