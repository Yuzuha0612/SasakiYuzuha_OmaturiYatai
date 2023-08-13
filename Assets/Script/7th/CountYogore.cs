using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountYogore : MonoBehaviour
{
    public Text YogoreScoreText;
    public int YogoreCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YogoreScoreText.GetComponent<Text>().text = "Å~"+ YogoreCount;
    }
}
