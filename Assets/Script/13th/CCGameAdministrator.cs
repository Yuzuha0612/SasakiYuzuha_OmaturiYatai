using UnityEngine;

public class CCGameAdministrator : MonoBehaviour
{
    void Start()
    {
        
    }
    public enum CCGameStatus
    {
        ReadyGo,
        GameNormal,
        GameFever,
        Result
    }
    public CCGameStatus CCGS;
    void Update()
    {
        switch (CCGS)
        {
            case CCGameStatus.ReadyGo:
                Debug.Log("���f�B�[...");
                break;
            case CCGameStatus.GameNormal:
                Debug.Log("�Q�[����");
                break;
            case CCGameStatus.GameFever:
                Debug.Log("�t�B�[�o�[�^�C��!");
                break;
            case CCGameStatus.Result:
                Debug.Log("���ʔ��\");
                break;
        }
    }
}
