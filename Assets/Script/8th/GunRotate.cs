using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private Vector3 clickPos;             // クリックした位置座標
    public Transform canonPos;	//　 弾が出る場所の座標
    public GameObject PlayerObject;
    private float Degreee;
    public float rotSpeed = 0.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //腕の回転
        Vector3 bulletDir = Vector3.Scale((Camera.main.ScreenToWorldPoint(clickPos) - canonPos.position), new Vector3(1, 1, 0)).normalized;
        Degreee = Mathf.Atan2(bulletDir.z, bulletDir.x) * Mathf.Rad2Deg;
        PlayerObject.transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(PlayerObject.transform.eulerAngles.y, Degreee, Time.deltaTime * rotSpeed), 0f);

    }
}
