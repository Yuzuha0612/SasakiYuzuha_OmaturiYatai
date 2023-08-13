using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SagyoinMoyaMoya : MonoBehaviour
{
    public Slider HPRobot2;
    public SpriteRenderer SagyoinGenki;
    public GameObject SagyoinOtikomi;
    public Text MoyaMoyaCounter;
    public float MoyaMoyaCount;
    public Text GameClear7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HPRobot2.value == 3)
        {
            MoyaMoyaCounter.GetComponent<Text>().text = "Å~" + MoyaMoyaCount;
            SagyoinGenki.enabled = true;
            SagyoinOtikomi.SetActive(false);
            GameClear7.enabled = true;
            Time.timeScale = 0;
        }
    }
}
