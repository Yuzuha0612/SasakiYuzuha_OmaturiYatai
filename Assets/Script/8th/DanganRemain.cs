using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanganRemain : MonoBehaviour
{
    public float DanganRemainNumber;
    public Text DanganLabel;
    public Text ClearText;
    public Text KeihinBoxNumberText;
    public Text KeihinnNuiNumberText;
    public int BearNui;
    public int BoxSnack;
    public GameObject ResultShooting;
    public Image PandaNui;
    public bool PandaNuiGet;
    void Start()
    {
        PandaNuiGet = false;
    }

    void Update()
    {
        DanganLabel.text = "�c��" + DanganRemainNumber+"��";
        if (Input.GetMouseButtonDown(0))        // �}�E�X�ō��N���b�N������E�E
        {
            DanganRemainNumber--;
            DanganLabel.text = "�c��" + DanganRemainNumber + "��";
        }
        if (DanganRemainNumber == 0)
        {
            Time.timeScale = 0;
            StartCoroutine(DanganCoroutine());
            KeihinBoxNumberText.text = "�~" + BoxSnack;
            KeihinnNuiNumberText.text = "�~" + BearNui;
            if (PandaNuiGet == true)
            {
                PandaNui.enabled = true;
            }
        }
        }

    IEnumerator DanganCoroutine()
    {
        ClearText.enabled = true;
        yield return new WaitForSecondsRealtime(2.0f);
        ResultShooting.SetActive(true);
    }
}
