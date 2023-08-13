using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UchiwaCountManager : MonoBehaviour
{
    public GameObject clickedUchiwa;
    public float UchiwaCountNumber;
    public AudioClip UchiwaSound;
    public AudioClip GoalSound;
    AudioSource audioSource;
    public Slider PlayerHPSlider;
    public float CurrentHP;
    public Text ClearText;
    public GameObject RetryButton;
    void Start()
    {
        UchiwaCountNumber = 0;
        audioSource = GetComponent<AudioSource>();
       // CurrentHP = 0;
}

    void Update()
    {
        PlayerHPSlider.value = UchiwaCountNumber;
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(UchiwaSound);
            clickedUchiwa = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedUchiwa = hit2d.transform.gameObject;
            }

            Debug.Log(clickedUchiwa);
        }
        if(UchiwaCountNumber == 5)
        {
            ClearText.enabled = true;
            RetryButton.SetActive(true);
            Time.timeScale = 0;
            //audioSource.Play(GoalSound);
        }
    }
}
