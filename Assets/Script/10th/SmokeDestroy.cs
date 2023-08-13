using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDestroy : MonoBehaviour
{
    public float lifetime = 2.0f;            //　変数lifetimeをつくります

    void Start()
    {
        Destroy(gameObject, lifetime); //　Startメソッドで、消す時間を与えておきます
    }

}
