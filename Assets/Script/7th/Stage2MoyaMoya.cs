using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2MoyaMoya : MonoBehaviour
{
    private GameObject CountText;
    CountYogore CountYogoreSc;
    public GameObject WallAll;
    public GameObject WallAll2;
    ScrollShelf  WallAll2Scr;
    private Transform oriPos;
    public float MoveMoyaMoyaSpeed;
    public bool isMoveMoyaMoya;
    void Start()
    {
        CountText = GameObject.Find("YogoreCount");
        CountYogoreSc = CountText.GetComponent<CountYogore>();
        isMoveMoyaMoya = false;
    }

    void Update()
    {
        if (CountYogoreSc.YogoreCount == 11)
        {
            WallAll2.SetActive(true);
            isMoveMoyaMoya = true;
            WallAll.SetActive(false);
        }
        if(isMoveMoyaMoya==true)
        {
            transform.Translate(MoveMoyaMoyaSpeed, 0, 0);
            if (transform.position.x < 0)  //�@x���̈ʒu��-10f��菬�����Ȃ�����E�E
            {
                transform.position = new Vector3(0, 0, 0); //�@���̈ʒu�ɖ߂��܂��i���̒l�����Ƃ̍����ɂ��Ă��܂��j     
            }
        }
    
    }
}
