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
    {//�͂��������ƃQ�[�����I������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
