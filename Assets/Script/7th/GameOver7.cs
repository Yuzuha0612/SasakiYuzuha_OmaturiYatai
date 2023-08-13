using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver7 : MonoBehaviour
{
    public Slider HPRobot2;
    public Text GameOverText2;
    public GameObject RetryButton;
    void Start()
    {
        
    }

    void Update()
    {
        if (HPRobot2.value == 5)
        {
            Time.timeScale = 0;
            GameOverText2.enabled = true;
            RetryButton.SetActive(true);
}
    }
}
