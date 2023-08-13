using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruiteDes : MonoBehaviour
{/*
    public GameObject[] Fruitecolor;
    void Start()
    {
        
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            numberOfBullet = Random.Range(1, 18);
            SpawnBullet(numberOfBullet);
            timeElapsed = 0.0f;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruite")
        {
            Destroy(collision.gameObject);
        }
    }
    void SpawnBullet(int numberOfBullet)
    {
            //GameObject fireBall = Instantiate(bullet, spawnPoint, Quaternion.identity);　　//　弾のprefabをspawnPoint の場所に生成します
            
                int randomwatame = Random.Range(0, 7);

                GameObject fireBall = Instantiate(Fruitecolor[numberOfBullet], spawnPoint, Quaternion.identity);  //　弾のprefabをspawnPoint の場所に生成します
              
                Destroy(fireBall, 3.0f);　　//生成されたObject は3秒後に破壊します　
        
        
    }*/
}
