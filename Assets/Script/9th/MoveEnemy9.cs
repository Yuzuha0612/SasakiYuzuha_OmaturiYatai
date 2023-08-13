using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy9 : MonoBehaviour
{
    public GameObject enemy; //　エネミーのオブジェクトを入れる変数を用意します
    private Vector2 enePos; //　現在のポジションを格納する変数を用意します
    private Vector3 targetPos; //　Playerオブジェクトのポジションを格納する変数を用意します
    private float rad; //　向かう方向のラジアンを格納する変数を用意します
    public float speed;      //　エネミーの移動速度(かける値)を格納する変数を用意します
    public float addSpeed;       //　再セット時に足される速度を入れる変数を用意します
    public GameObject playerObj;              // playerの位置を格納するGameObject型の変数playerPosを用意します 

    MoveClick9 MoveClick9Sc;
    void Start()
    {
        //　変数targetPosにプレイヤーオブジェクトをの位置データを探して入れます
        targetPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        //　目標となるオブジェクトのｙ座標の差とx座標の差を用いて、その2つの線の作る角度のラジアンを求めます
        rad = Mathf.Atan2(targetPos.y - enemy.transform.position.y, targetPos.x - enemy.transform.position.x);
        MoveClick9Sc = playerObj.GetComponent<MoveClick9>();
    }
    void FixedUpdate()
    {
        if (MoveClick9Sc.isKunoitiRun == false)
        {
            enePos = enemy.transform.position;          //　変数enePosに現在のエネミーの位置を入れます 
            enePos.x += speed * Mathf.Cos(rad);         //　変数enePosのx値に「x軸方向の大きさ×speed」を入れます  
            enePos.y += speed * Mathf.Sin(rad);    //　変数enePosのx値に「y軸方向の大きさ×speed」を入れます 
            enemy.transform.position = enePos;   //　現在の位置に、計算して得られたposition値を入れます
                                                 //　もし、エネミーオブジェクトのｙ座標が-１２.0ｆ以下になったら・・
            if (enemy.transform.position.y < -12.0f)
            {
                speed += addSpeed;           //　エネミーの速度に変数addSpeedの値を足して変数に戻します
                ResetEnemy();            //　ResetEnemy()メソッドに飛びます
            }
        }
        else
        {

        }
    }
    void ResetEnemy()
    {
        //Tagが"Player"のオブジェクトを探して、変数playerに入れます
        GameObject player = GameObject.FindWithTag("Player");
        //　x軸の値を（－10.0～10.0のランダムな値）、 y軸の値を（8.0～10.0のランダムな値）とする新しいポジションを与えます
        enemy.gameObject.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(8.0f, 10.0f));
        //　その値を変数enePosに格納します
        enePos = enemy.gameObject.transform.position;

        if (player == null)            //　もし、変数player内に何もなければ・・（null　は変数に「何も入ってない」ことを示します）
        {
            speed = 0.0f;       //変数speedの値を０にします（エネミーの動きが止まります）
            enemy.gameObject.SetActive(false);        //　エネミーのオブジェクトの表示を止めます
            return;
        }
        if (player != null)            //　もし、変数player内に何かいたら・・（null　は変数に「何も入ってない」ことを示します）
        {
            rad = Mathf.Atan2(targetPos.y - enemy.transform.position.y, targetPos.x - enemy.transform.position.x);
            enePos = enemy.transform.position;          //　変数enePosに現在のエネミーの位置を入れます 
            enePos.x += speed * Mathf.Cos(rad);         //　変数enePosのx値に「x軸方向の大きさ×speed」を入れます 
            enePos.y += speed * Mathf.Sin(rad);           //　変数enePosのx値に「y軸方向の大きさ×speed」を入れます 
            enemy.transform.position = enePos;          //　現在の位置に、計算して得られたposition値を入れます
            enemy.gameObject.SetActive(true);           //　この変数enemyに入っているオブジェクトを表示します
        }
    }


}
