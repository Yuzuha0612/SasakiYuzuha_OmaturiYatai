using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMove : MonoBehaviour
{
    GameObject gameCtrl;         //　GameControllerを探してきて入れる変数gameCtrlを用意します
    private bool gameOn; 　　　　　//　bool型の変数gameOnを用意します
    private Vector2 targetPos;  　　　 //　Vector2型の変数targetPosを用意します
    public float power;     　　　　　　//　float型の変数 powerを用意します
    private Vector2 clickPos;       　　　 //　「最後にマウスのあった場所」を格納する変数を用意します
    public GameObject smokeObj;      //　煙のスプライトを入れる変数を用意します
    public float waitTime = 0.2f; 　　　//　煙を出すまでの時間間隔です
    public GameObject exhaust;     　  //　煙のスプライトを出す場所のオブジェクトです
    public GameObject clickPoint;       //　クリップした場所に表示するGameObjectを格納する変数を用意します

    void Start()
    {
        gameCtrl = GameObject.Find("GameController"); //　GameControllerオブジェクトを探して変数gameCtrlに格納します

        StartCoroutine("SmokeObj");              //　StartCoroutineで、"SmokeObj"関数を呼び出します
    }
    void Update()
    {
            if (Input.GetMouseButtonDown(0)) 	// もし、右のマウスボタンが押されたら（押し続けた状態も含む）
            {
                //　clickPointグラフィックを非表示にします（次の移動場所に表示させるため、一旦消します）
                clickPoint.SetActive(false);

                clickPos = Input.mousePosition; // そのマウスの位置の座標を取得する
                targetPos = Camera.main.ScreenToWorldPoint(clickPos);  // マウスカーソルの位置をワールド座標に変換する

                //　ゲームオブジェクトclickPointグラフィックの位置にクリックされた位置を入れます
                //　(positionはVector3型ですが、暗黙的にキャストしてくれます)
                clickPoint.transform.position = targetPos;
                clickPoint.SetActive(true);                   //　clickPointのグラフィックをその地点に表示します
            }
        transform.position = Vector2.Lerp(transform.position, targetPos, power);
       
       // else return;　　　　　　　 // ｛無くても良いです｝
    }

    IEnumerator SmokeObj() // 煙を発生させるコルーチンです
    {
        while (true) // そのまま何度も続けさせたい場合、while(true)と書きます
        {
            //　smokeObjをexhaustの位置に生成させます
            Instantiate(smokeObj, exhaust.transform.position, smokeObj.transform.rotation);
            yield return new WaitForSeconds(waitTime);  //　変数waitTimeの時間が立った時に戻ります「while(true)」と共に使います
        }
    }
}