using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveClick9 : MonoBehaviour
{

    private Vector2 targetPos;  			//　Vector2型の変数targetPosを用意します
    public float power;                 //　float型の変数 powerを用意します
    private Vector2 clickPos;		                       //    クリックしたｘ、ｙ座標を格納するVector２型の変数を用意します
    public GameObject clickPoint;           //　クリップした場所に表示するGameObjectを格納する変数を用意します

    public bool isKunoitiRun;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))　　//　もしマウスの「middleボタン」が押されたら・・　　（右ボタンなら（１）、左ボタンなら（０）とします）
        {
            Debug.Log(targetPos);
            //　clickPointグラフィックを非表示にします（次の移動場所に表示させるため、一旦消します）
            clickPoint.SetActive(false);
            clickPos = Input.mousePosition; 				//　 Vector２でマウスカーソルの位置座標を取得する
            targetPos = Camera.main.ScreenToWorldPoint(clickPos);       // マウスカーソルの位置をワールド座標に変換する

            //　ゲームオブジェクトclickPointグラフィックの位置にクリックされた位置を入れます　(positionはVector3型ですが、暗黙的にキャストしてくれます)
            clickPoint.transform.position = targetPos;
            clickPoint.SetActive(true);                                 //　clickPointのグラフィックをその地点に表示します
            isKunoitiRun = true;

        }
            //　このオブジェクトのpositionの値に、targetPosの位置まで、補完しながら毎フレームpower変数の値だけ、
            //　ゆっくり位置を書き換えていきます
 　　transform.position = Vector2.Lerp(transform.position, targetPos, power);

            //　targetPosの充分近く（差が0.2以内なら）まで本体が移動できたら・・・　
            //　（Vector3型とVector2型では計算ができないので、　targetPosの前に（Vector3）と書いてVector3型に変更キャストします　
            //　sqrMagnitudeはベクトルを2乗して大きさの値を出す関数です）
            if ((transform.position - (Vector3)targetPos).sqrMagnitude <= 0.2f)
            {
                clickPoint.SetActive(false);                      //　clickPointグラフィックを消します
            isKunoitiRun = false;
            }
    }
}
    


