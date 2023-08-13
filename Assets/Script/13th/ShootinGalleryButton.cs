using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootinGalleryButton : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("ShootinGallery");
    }
    public void OnNextStageButtonClicked()
    {
        SceneManager.LoadScene("Quoits");
    }
    public void OnTitleButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
