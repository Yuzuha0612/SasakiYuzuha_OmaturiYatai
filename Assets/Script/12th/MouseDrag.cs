using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Rigidbody2D rbPlayer;          //rigidbodyを格納する変数を用意します
    public LineRenderer lineDir;         　  //　LineRenderer型の変数lineDirを用意します（引っ張った時にLineを引きます）
    private Vector2 startPos;     //　引きはじめのオブジェクトの位置（Vector2）を格納する変数を用意ます　
    private Vector2 pullPos; 	　    //　引き終わりのカーソル位置（Vector2）を格納する変数を用意します
    public float pullPower = 6.0f;              //飛ばす力の大きさを調整する変数を用意します
    public float maxPower = 2.0f;        　  //　引張る力の最大値を調整する変数を用意します　

    private Camera mainCamera;           //  Camera型の変数mainCameraを用意します 
    public GameObject[] WanageAll;
    private int WanageRandom;
    private CircleCollider2D CollWanage;
    public GameObject wgobjRed;
    public WanageGola wgRed;
    public GameObject wgobjBlue;
    public WanageGola wgBlue;
    public GameObject wgobjGreen;
    public WanageGola wgGreen;
    public void Start()
    {
        WanageRandom= Random.Range(0, 3);
        WanageAll[WanageRandom].SetActive(true);
        CollWanage = WanageAll[WanageRandom].GetComponent<CircleCollider2D>();
        rbPlayer = this.GetComponent<Rigidbody2D>();           //　rigidbody変数に、このobjectのrigidbodyを入れます
        mainCamera = Camera.main;                                              　//　変数mainCameraにこのSceneのメインカメラを入れます
        rbPlayer.bodyType = RigidbodyType2D.Kinematic;//重力無効
        
        wgobjRed = GameObject.Find("WanageRedGoal");
        wgRed = wgobjRed.GetComponent<WanageGola>();
        wgobjBlue = GameObject.Find("WanageBlueGoal");
        wgBlue = wgobjBlue.GetComponent<WanageGola>();
        wgobjGreen = GameObject.Find("WanageGreenGoal");
        wgGreen = wgobjGreen.GetComponent<WanageGola>();

    }
    void Update()
    {
        if (wgRed.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgRed.Wanagepredestroy = false;
        }
        if (wgBlue.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgBlue.Wanagepredestroy = false;
        }
        if (wgBlue.Wanagepredestroy == true)
        {
            Destroy(this.gameObject);
            wgBlue.Wanagepredestroy = false;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("マウスクリック");
        startPos = Input.mousePosition;                                          	   　//   マウスボタンを押した時の位置をstatPos変数に格納します
        startPos = mainCamera.ScreenToWorldPoint(startPos);       //   その位置をワールド座標に変換して入れ直します
        this.lineDir.enabled = true;             //　マウスが押された時にラインレンダラーをOnにします
        this.lineDir.SetPosition(0, rbPlayer.position);      //　ラインレンダラーの開始位置「０番目」をrigidbody変数の位置にします
        this.lineDir.SetPosition(1, rbPlayer.position);	//　ラインレンダラーの終わりの位置「１番目」をrigidbody変数の位置にします

    }

    public void OnMouseDrag()
    {
        Debug.Log("マウスドラッグ");
        Vector2 position = Input.mousePosition;                                  　	 　//   押しているマウスボタンの位置をposition変数に格納します
        position = this.mainCamera.ScreenToWorldPoint(position); 　　//   その位置をワールド座標に変換して入れ直します
        pullPos = position - startPos;                                                            //   今のマウス位置からスタートした位置を引くと方向ベクトルが得られますがきます
        if (pullPos.magnitude > maxPower)		　 //   その長さ(magnitude)がmaxPowerより長ければ・・
        {
            pullPos *= maxPower / pullPos.magnitude;		 //   maxPowerをその長さ(magnitude)で割った値をpullPos にかけた値を入れます
        }

        this.lineDir.SetPosition(0, this.rbPlayer.position);        //　ラインレンダラーの開始位置「０番目」をrbPlayer変数の位置にします
        this.lineDir.SetPosition(1, this.rbPlayer.position + this.pullPos);　 //　ラインレンダラーの終わりの位置「１番目」をrbPlayer変数の位置にpullPosを足した位置にします

    }

    public void OnMouseUp()
    {
        Debug.Log("マウスを離す");
        rbPlayer.bodyType = RigidbodyType2D.Dynamic;//重力有効
        CollWanage.enabled = true;
        this.lineDir.enabled = false;			// 　ラインレンダラーをOffにして、ラインを消します
        Pull(pullPos * -1 * pullPower);                       　　　　　　　　　　　//　マウスを離した時、Pull関数に引数「pullPosの方向へ―（マイナス）をかけた値」を渡します
    }

    public void Pull(Vector2 shotPower)			　 //　Pull関数　　引数を入れる変数shotPowerを用意してそこに受け取ります
    {
        Debug.Log("わなげを投げる!");
        this.rbPlayer.AddForce(shotPower, ForceMode2D.Impulse);　 //　rigidbodyにAddForceで受け取ったベクトルへ衝撃力を与えます
    }
    
}


