using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wattaame : MonoBehaviour
{
    public SpriteRenderer[] WataameColor;
    public SpriteRenderer WaribasiNormal;
    public SpriteRenderer WaribasiWatame;
    public SpriteRenderer WattamePink01;
    public bool Waribasi;
    public bool PinkWataame;
    public bool GreenWataame;
    public bool BlueWataame;
    public bool PandaWataame;
    public bool Wataame1;
    public bool Wataame2;
    public bool Wataame3;

    public int WataameCount;
    public int WattameBWCount;
    public GameObject AllWatame;
    public SpriteRenderer Watamebag;
    public ParticleSystem clearEffect;
    public ParticleSystem clearEffect2;
    public int Wattamemake;
    public Text Wattametext;
    public Image ThemeWataamePink;
    public Image ThemeWataameBlue;
    public Image ThemeWataameGreen;
    public Image ThemeWataameBW;
    private float ThemeNumber;
    public ParticleSystem clearEffect3;
    public bool Countbool11;
    private CCGameAdministrator ccga;
    public GameObject Administor;
    void Start()
    {
        ccga = Administor.GetComponent<CCGameAdministrator>();
    }

    void Update()
    {
        if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameNormal)
        {
            if (WattameBWCount >= 5)
            {
                ThemeNumber = 3;
                PinkWataame = false;
                GreenWataame =false;
                BlueWataame = false;
                PandaWataame = true;
                ccga.CCGS = CCGameAdministrator.CCGameStatus.GameFever;
                StartCoroutine(PandaWatameFever());
            } 
        }
            Wattametext.text ="~"+ Wattamemake;
        if (WataameCount >= 8 && Countbool11==true)
        {
            clearEffect.transform.position = this.transform.position;
            clearEffect.Emit(1);
            clearEffect2.transform.position = this.transform.position;
            clearEffect2.Emit(1);
            StartCoroutine(WatameClearCoroutine());
            Countbool11 = false;
        }
       if(Waribasi==true)
        {
            WataameColor[0].enabled = true;
        }
        else
        {
            WataameColor[0].enabled = false;
        }
        if (PinkWataame == true)
        {
            if (WataameCount >=1)
            {
                WataameColor[1].enabled = true;
                WataameColor[2].enabled = false;
                WataameColor[3].enabled = false;
            }
            if ( WataameCount >= 4)
            {
                WataameColor[2].enabled = true;
                WataameColor[1].enabled = false;
                WataameColor[3].enabled = false;
            }
            if (WataameCount >= 6)
            {
                WataameColor[3].enabled = true;
                WataameColor[1].enabled = false;
                WataameColor[2].enabled = false;
            }
        }else
        {
            WataameColor[3].enabled = false;
            WataameColor[1].enabled = false;
            WataameColor[2].enabled = false;
        }
        if (BlueWataame == true)
        {
            if ( WataameCount >= 1)
            {
                WataameColor[4].enabled = true;
                WataameColor[5].enabled = false;
                WataameColor[6].enabled = false;
            }
            if ( WataameCount >= 4)
            {
                WataameColor[5].enabled = true;
                WataameColor[4].enabled = false;
                WataameColor[6].enabled = false;
            }
            if ( WataameCount >= 6)
            {
                WataameColor[6].enabled = true;
                WataameColor[4].enabled = false;
                WataameColor[5].enabled = false;
            }
        }
        else
        {
            WataameColor[4].enabled = false;
            WataameColor[5].enabled = false;
            WataameColor[6].enabled = false;
        }
        if (GreenWataame == true)
        {
            if ( WataameCount >= 1)
            {
                WataameColor[7].enabled = true;
                WataameColor[8].enabled = false;
                WataameColor[9].enabled = false;
            }
            if (WataameCount >= 4)
            {
                WataameColor[8].enabled = true;
                WataameColor[7].enabled = false;
                WataameColor[9].enabled = false;
            }
            if ( WataameCount >= 6)
            {
                WataameColor[9].enabled = true;
                WataameColor[7].enabled = false;
                WataameColor[8].enabled = false;
            }
        }
        else
        {
            WataameColor[7].enabled = false;
            WataameColor[8].enabled = false;
            WataameColor[9].enabled = false;
        }
        if (PandaWataame == true)
        {
            if (WataameCount >= 1)
            {
                WataameColor[10].enabled = true;
                WataameColor[11].enabled = false;
                WataameColor[12].enabled = false;
            }
            if (WataameCount >= 4)
            {
                WataameColor[11].enabled = true;
                WataameColor[10].enabled = false;
                WataameColor[12].enabled = false;
            }
            if (WataameCount >= 6)
            {
                WataameColor[12].enabled = true;
                WataameColor[10].enabled = false;
                WataameColor[11].enabled = false;
            }
        }
        else
        {
            WataameColor[10].enabled = false;
            WataameColor[11].enabled = false;
            WataameColor[12].enabled = false;
        }
        if (WataameCount >= 12 || WataameCount == 0)
        {
            WaribasiNormal.enabled = true;
            WaribasiWatame.enabled = false;
        }
        else
        {
            WaribasiNormal.enabled = false;
            WaribasiWatame.enabled = true;
        }
        if (ThemeNumber == 0)
        {
            ThemeWataamePink.enabled = true;
            ThemeWataameBlue.enabled = false;
            ThemeWataameGreen.enabled = false;
            ThemeWataameBW.enabled = false;
        }
        if (ThemeNumber == 1)
        {
            ThemeWataamePink.enabled = false;
            ThemeWataameBlue.enabled = true;
            ThemeWataameGreen.enabled = false;
            ThemeWataameBW.enabled = false;
        }
        if (ThemeNumber == 2)
        {
            ThemeWataamePink.enabled = false;
            ThemeWataameBlue.enabled = false;
            ThemeWataameGreen.enabled = true;
            ThemeWataameBW.enabled = false;
        }
        if (ThemeNumber == 3)
        {
            ThemeWataamePink.enabled = false;
            ThemeWataameBlue.enabled = false;
            ThemeWataameGreen.enabled = false;
            ThemeWataameBW.enabled = true;
        }
    }
    IEnumerator WatameClearCoroutine()
    {
        if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameNormal)
        {
            AllWatame.SetActive(false);
            Watamebag.enabled = true;
            Wattamemake++;
            yield return new WaitForSecondsRealtime(1.0f);
            AllWatame.SetActive(true);

            Watamebag.enabled = false;
            clearEffect3.transform.position = this.transform.position;
            clearEffect3.Emit(1);
            ThemeNumber = Random.Range(0, 3);

            WataameCount = 0;
            GreenWataame = false;
            PinkWataame = false;
            BlueWataame = false;
            PandaWataame = false;
            Countbool11 = true;
        }
        if (ccga.CCGS == CCGameAdministrator.CCGameStatus.GameFever)
        {
            AllWatame.SetActive(false);
            Watamebag.enabled = true;
            Wattamemake++;
            yield return new WaitForSecondsRealtime(1.0f);
            AllWatame.SetActive(true);

            Watamebag.enabled = false;
            clearEffect3.transform.position = this.transform.position;
            clearEffect3.Emit(1);
            ThemeNumber =3;

            WataameCount = 0;
            GreenWataame = false;
            PinkWataame = false;
            BlueWataame = false;
            PandaWataame = false;
            Countbool11 = true;
        }
        }
    IEnumerator PandaWatameFever()
    {
        yield return new WaitForSecondsRealtime(8.0f);
        WataameCount = 0;
        WattameBWCount = 0;
        GreenWataame = false;
        PinkWataame = false;
        BlueWataame = false;
        PandaWataame = false;
        ThemeNumber = Random.Range(0, 3);
        ccga.CCGS = CCGameAdministrator.CCGameStatus.GameNormal;
    }
    }
