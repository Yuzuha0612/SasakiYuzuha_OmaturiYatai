using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDestroy : MonoBehaviour
{
    public GameObject GameOverBoy;
    public Text GameOverBoyT;
    public GameObject GameOverGirl;
    public Text GameOverGirlT;
    public GameObject GameCleartext;
    public Text GameCleartextT;

    public GameObject MoziDai;
    public GameObject MoziS;
    public GameObject MoziK;
    public GameObject MoziDai2;
    public GameObject MoziKi;
    public GameObject MoziR;
    public Image MoziDaiT;
    public Image MoziST;
    public Image MoziKT;
    public Image MoziDai2T;
    public Image MoziKTT;
    public Image MoziRT;
    public float CountMozi;
    void Start()
    {
        GameOverBoy = GameObject.Find("GameOverBoy");
        GameOverBoyT.GetComponent<Text>();
        GameOverGirl = GameObject.Find("GameOverGirl");
        GameOverGirlT.GetComponent<Text>();
        GameCleartext = GameObject.Find("GameOverGirl");
        GameCleartextT.GetComponent<Text>();
        GameOverBoy = GameObject.Find("GameOverBoy");
        GameOverBoyT.GetComponent<Text>();
        GameOverGirl = GameObject.Find("GameOverGirl");
        GameOverGirlT.GetComponent<Text>();
        GameCleartext = GameObject.Find("GameOverGirl");
        GameCleartextT.GetComponent<Text>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kataomoi")
        {
            Time.timeScale = 0;
            GameCleartextT.enabled = true;
        }
        if (collision.gameObject.tag == "Girl")
        {
            Time.timeScale = 0;
            GameOverGirlT.enabled = true;

        }
        if (collision.gameObject.tag == "Boy")
        {
            Time.timeScale = 0;
            GameOverBoyT.enabled = true;
        }
        if (collision.gameObject.tag == "MoziD")
        {
            MoziDaiT.enabled = true;
            CountMozi++;
        }
        if (collision.gameObject.tag == "MoziS")
        {
            MoziST.enabled = true;
            CountMozi++;
        }
        if (collision.gameObject.tag == "MoziK")
        {
            MoziKT.enabled = true;
            CountMozi++;
        }
        if (collision.gameObject.tag == "MoziD2")
        {
            MoziDai2T.enabled = true;
            CountMozi++;
        }
        if (collision.gameObject.tag == "MoziK")
        {
            MoziKTT.enabled = true;
            CountMozi++;
        }
        if (collision.gameObject.tag == "MoziR")
        {
            MoziRT.enabled = true;
            CountMozi++;
        }
    }
}
