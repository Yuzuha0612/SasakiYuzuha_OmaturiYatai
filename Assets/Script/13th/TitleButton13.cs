using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton13 : MonoBehaviour
{
    public void OnCottnCandyButtonClicked()
    {
        SceneManager.LoadScene("CottonCnady");
    }
    public void OnQuoitsClicked()
    {
        SceneManager.LoadScene("Quoits");
    }
    public void OnTitleClicked()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnFirstStageButtonClicked()
    {
        SceneManager.LoadScene("ShootinGallery");
    }
    public void OnShootinGalleryClicked()
    {
        SceneManager.LoadScene("ShootinGallery");
    }
    public void OnFinishGameButtonClicked()
    {//はいを押すとゲームを終了する
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
