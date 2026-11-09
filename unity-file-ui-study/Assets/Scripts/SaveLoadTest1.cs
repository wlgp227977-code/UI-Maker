using UnityEngine;

public class SaveLoadTest1 : MonoBehaviour
{
    public void Save()
    {
        SaveLoadManager.Data = new SaveDataV4();
        SaveLoadManager.Data.PlayerName = $"JiHye Choi";
        SaveLoadManager.Data.Gold = Random.Range(100, 200);
        // SaveLoadManager.Data.Exp = Random.Range(1000, 3000);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
    }
    public void Load()
    {
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
        Debug.Log(SaveLoadManager.Data.PlayerName);
        Debug.Log(SaveLoadManager.Data.Gold);
        // Debug.Log(SaveLoadManager.Data.Exp);
    }
}
