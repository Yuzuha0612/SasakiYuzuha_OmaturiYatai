using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapselBullet : MonoBehaviour
{
    private Vector3 veloDir; 　// 　進む方向を入れる変数を用意します
    public float speed;  　　　//　 速度の大きさを入れます
    GameObject gameCtrl;   //　 GameControllerオブジェクトを入れる変数を用意します
    RotShooter rotShoot;      //　RotShootスクリプトを入れる変数rotShootを用意します　そこで使ってる変数を使うためです
    public GameObject OpenCapsel;
    public SpriteRenderer CloseCapsel;
 

    private void Start()
    {
        gameCtrl = GameObject.Find("Gun");      //　scene内から"GameController "という名前のObject を探して変数に入れます        　
        rotShoot = gameCtrl.GetComponent<RotShooter>();  //　変数rotShootに変数gameCtrlに入れられたRotShooterスクリプトを入れます
        veloDir = rotShoot.canonAngle * speed;            // 発射方向にrotShooter内のcanonAngleを持ってきます
        Destroy(gameObject, 3.5f);                                       // 生成されたのち、3.5秒で消します
    }

    private void Update()
    {
        transform.localPosition += veloDir;                 // Update内で、毎フレーム、「弾」のポジションにvelDirを足していきます
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mato")
        {
            //OpenCapsel.SetActive(true);
            CloseCapsel.enabled = false;
          
            //Vector3 tmp = this.gameObject.transform.position;
            //heightArmpos = tmp.x;
        }
    }
}