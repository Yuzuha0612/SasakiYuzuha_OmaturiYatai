using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletKill10 : MonoBehaviour
{
    public GameObject explosion; //　爆発パーティクルを格納するGameObject型の変数をつくります

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")　//　もし相手(other)のtagが”Bullet”ならば
        {
            //explosionの場所にotherの場所を入れます
            explosion.transform.position = other.transform.position;
            //gameObject型の爆発のプレハブを生成して、変数expPrefabに入れます
            GameObject expPrefab = Instantiate(explosion, explosion.transform.position, transform.rotation);
            Destroy(expPrefab, 1.0f);                       　//パーティクルを消します
            this.gameObject.SetActive(false);      //　この弾のオブジェクトをScene から非表示にして消します
        }
    }
}
