using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyBullet10 : MonoBehaviour
{
    public GameObject explosion;       //パーティクルの変数を用意します

    void Start()
    {
        Invoke("SelfKill", 5.0f);       //生成された10秒後に破壊します
    }

    void Update()
    {
        transform.position += new Vector3(0, -2.5f, 0) * Time.deltaTime;  //　毎フレームｙの値を引いて行きます（マイナスを足している）
    }

    private void OnTriggerEnter2D(Collider2D other)   //当たり判定です　トリガーを使います
    {
        if (other.gameObject.tag == "Bullet" && gameObject != null)        //もし、当たった相手のtagがBulletなら
        {
            SelfKill();
        }
    }

    void SelfKill()
    {
        explosion.transform.position = gameObject.transform.position;    //explosionの場所にこのオブジェクトの場所を入れます
                                                                         //GameObject型のパーティクルプレハブに、explosionのプレハブを生成して入れます
        GameObject expPrefab = Instantiate(explosion, explosion.transform.position, transform.rotation);
        Destroy(expPrefab, 1.0f);                       //1秒後にパーティクルを消します
        Destroy(gameObject, 0.1f);                   //このオブジェクト（エネミーの弾）を消します
    }
}


