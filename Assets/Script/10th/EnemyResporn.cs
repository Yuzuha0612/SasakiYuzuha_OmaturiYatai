using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResporn : MonoBehaviour
{
    public GameObject enemy;            //enemyのPrefabを格納する変数enemyを用意します
    GameObject gameCtrl;    //GameControllerオブジェクトを格納する変数gameCtrlを用意します
    //GameBool gameBool;    //GameBoolスクリプトを格納する変数gameBoolを用意します

    private void Start()
    {
        gameCtrl = GameObject.Find("GameController");   //GameControllerオブジェクトを探して格納します
        //gameBool = gameCtrl.GetComponent<GameBool>(); //GameController内のGameBoolコンポネントを格納します
        enemy.gameObject.SetActive(false);            //　（消えている場合を想定して）このオブジェクトをScene に消します　　
        InvokeRepeating("EnemySet", 2.0f, 4.0f);       //　関数を繰り返し呼び出すメソッド、2秒後に、4秒ごとに”EnemySet”関数を呼び出します
    }

    void EnemySet()       //エネミーをセットするメソッド、　はじめから繰り返して呼び出されます
    {
        //生成する位置を決めます、ｘの値とｙの値を、Randam.Range(A,B)で範囲を決めてランダムに設定します
        Vector3 setPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(9.0f, 11.0f), 0);
        enemy = Instantiate(enemy, setPos, transform.rotation);     //Instantiate関数（prefab、場所、回転角度）で、生成します
        enemy.transform.position = setPos;                  //　現在の位置に、計算して得られたposition値を入れます
        enemy.gameObject.SetActive(true);
    }
    private void Update()
    {/*
       if (gameBool.gameOn != true) //　もしｍGameManagerのgameOnフラグが真（true）でなければ
        {
            CancelInvoke("EnemySet");       //　EnemySetメソッドを呼び出すことを止めます
        }*/
    }
}
