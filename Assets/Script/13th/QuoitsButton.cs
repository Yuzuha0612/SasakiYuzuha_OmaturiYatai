using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuoitsButton : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("Quoits");
    }
    public void OnNextStageButtonClicked()
    {
        SceneManager.LoadScene("CottonCnady");
    }
    public void OnTitleButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
