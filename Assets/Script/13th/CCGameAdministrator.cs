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
                Debug.Log("レディー...");
                break;
            case CCGameStatus.GameNormal:
                Debug.Log("ゲーム中");
                break;
            case CCGameStatus.GameFever:
                Debug.Log("フィーバータイム!");
                break;
            case CCGameStatus.Result:
                Debug.Log("結果発表");
                break;
        }
    }
}
