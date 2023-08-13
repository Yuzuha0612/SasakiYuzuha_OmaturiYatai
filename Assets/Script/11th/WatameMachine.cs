using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatameMachine : MonoBehaviour
{
    public int numberOfBullet;          //弾の数
    //public GameObject bullet;           //弾のPrefabを入れる変数
    public GameObject[] Watamecolor;
    Vector2 spawnPoint;　　　　　//弾が生成される座標、（ここではクリックした場所）
    public float moveSpeed = 5f; 　//セットされたprefabが移動するスピード

    public float timeOut;
    private float timeElapsed;
    private CCGameAdministrator ccga;
    public GameObject Administor;

    void Start()
    {
        ccga = Administor.GetComponent<CCGameAdministrator>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            numberOfBullet = Random.Range(1, 18);
            //     カーソルの位置を変数spawnPointに入れます
            spawnPoint = this.transform.position;
            SpawnBullet(numberOfBullet);
            timeElapsed = 0.0f;
        }
      
    }
    void SpawnBullet(int numberOfBullet)
    {
        //　浮動小数点の変数angleStepに、360を弾数で割った値を入れます（弾の方向を何度ずつに分割するかを求める）
        float angleStep = 360f / numberOfBullet;
        float angle = 0f;                             　　　　　　　  //浮動小数点の変数angleに０を入れます（はじまりの位置です）

        //　forの繰り返し構文、（変数iに毎回1づつ足していき、変数numberOfBulletの数に達したら、繰り返しを抜けます）
        for (int i = 0; i <= numberOfBullet - 1; i++)
        {
            //　変数bulletXDirにspawnPointのxの値に、Cos（ラジアンで角度を扱うので、円周の長さ（半径＊２＊3.14）をangleの角度から求めます）
            float bulletXDir = spawnPoint.x + Mathf.Cos(angle * 2 * Mathf.PI / 360f);
            float bulletYDir = spawnPoint.y + Mathf.Sin(angle * 2 * Mathf.PI / 360f);       //　同様に変数bulletｙDirにspawnPointのｙの値をSin()を使って求めます
            Vector2 bulletPos = new Vector2(bulletXDir, bulletYDir);                             //    弾の位置座標をbulletPosに入れます
            //　弾の飛ぶ方向bulletMoveDirに、クリックした場所と弾の向かう場所の「差」からベクトルを算出して、単位ベクトル化して、prefabの移動スピードをかけます
            Vector2 bulletMoveDir = (bulletPos - spawnPoint).normalized * moveSpeed;

            //GameObject fireBall = Instantiate(bullet, spawnPoint, Quaternion.identity);　　//　弾のprefabをspawnPoint の場所に生成します
            if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameNormal)
            {
                int randomwatame = Random.Range(0, 7);

                GameObject fireBall = Instantiate(Watamecolor[randomwatame], spawnPoint, Quaternion.identity);  //　弾のprefabをspawnPoint の場所に生成します
                fireBall.transform.up = bulletMoveDir;                                                            //　fireBallオブジェクトの上方向をbulletMoveDirの方向にします
                                                                                                                  //　生成したprefabにRigidbodyを入れて、その速度ベクトル成分velocityに、bulletMoveDirのx,yベクトル成分を入れます
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

                angle += angleStep;   //変数angleに　angleStep の値を加えます
                Destroy(fireBall, 3.0f);　　//生成されたObject は3秒後に破壊します　
            }
            if(ccga.CCGS == CCGameAdministrator.CCGameStatus.GameFever)
            {
                int randomwatame = 6;

                GameObject fireBall = Instantiate(Watamecolor[randomwatame], spawnPoint, Quaternion.identity);  //　弾のprefabをspawnPoint の場所に生成します
                fireBall.transform.up = bulletMoveDir;                                                            //　fireBallオブジェクトの上方向をbulletMoveDirの方向にします
                                                                                                                  //　生成したprefabにRigidbodyを入れて、その速度ベクトル成分velocityに、bulletMoveDirのx,yベクトル成分を入れます
                fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDir.x, bulletMoveDir.y);

                angle += angleStep;   //変数angleに　angleStep の値を加えます
                Destroy(fireBall, 3.0f);　　//生成されたObject は3秒後に破壊します　
            }
        }
    }
}
