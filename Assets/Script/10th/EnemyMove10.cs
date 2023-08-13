using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove10 : MonoBehaviour
{
    float enePos;                //enemyの横移動の開始位置を決めるラジアン値を入れる変数を用意します
    public GameObject bullet;

    void Start()
    {
        enePos = Random.Range(0, Mathf.PI);  //変数enePosに、０から3.14（Mathf.PIは円周率を出す関数）のランダム値を入れます
        InvokeRepeating("EneShot", 1.0f, 3.0f);  //EneShot関数をInvokeRepeatingで3秒おきに呼び出し続けます
    }

    void FixedUpdate()
    {    //オブジェクトの位置から毎フレーム、y軸の値をTime.deltaTime分を減らし続けます
         //　xの値は、経過したフレーム数に0，05をかけた値に、ランダムで得られた値を足して、Cosの値を求め、その振幅を調整し、毎フレームの位置を求めます
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount * 0.05f + enePos) * 0.05f, Time.deltaTime, 0f);
    }

    void EneShot() 	 //enemyから弾を発射する関数「EneShot()」を作ります
    {
        Instantiate(bullet, transform.position, transform.rotation);   //bulletに格納されたPrefabをこのオブジェクトの位置に生成します
    }
}

