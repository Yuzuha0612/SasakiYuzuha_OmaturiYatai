using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Firsttarget;
    //public GameObject Secondtarget;
    private Vector3 Firstoffset;
    //private Vector3 Secondoffset;
    public bool FirstBall;
    public bool SecondBall;
    void Start()
    {
        Firstoffset = transform.position - Firsttarget.transform.position;
        //Secondoffset = transform.position - Firsttarget.transform.position;
    }

    void Update()
    {
        transform.position = Firsttarget.transform.position + Firstoffset;
        //transform.position = Firsttarget.transform.position + Secondoffset;
    }
}
