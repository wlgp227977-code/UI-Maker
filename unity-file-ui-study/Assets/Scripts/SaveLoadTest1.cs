// using UnityEngine;

// public class SaveLoadTest1 : MonoBehaviour
// {
//     public void CreateItem()
//     {
//         SaveLoadManager.Data.ItemList.Add(SaveItemData.GetRandomItem());
//     }
//     public void Save()
//     {
//         Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
//         SaveLoadManager.Data = new SaveDataV5();
//         SaveLoadManager.Data.FirstName = $"JiHye";
//         SaveLoadManager.Data.LastName = $"Choi";
//         SaveLoadManager.Data.Gold = Random.Range(100, 200);
//         // SaveLoadManager.Data.Exp = Random.Range(1000, 3000);
//         Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
//     }
//     public void Load()
//     {
//         Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
//         // Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
//         // Debug.Log(SaveLoadManager.Data.PlayerName);
//         // Debug.Log(SaveLoadManager.Data.Gold);
//         // // Debug.Log(SaveLoadManager.Data.Exp);
//     }
// }
using UnityEngine;

public class SaveLoadTest1 : MonoBehaviour
{
    public void CreateItem()
    {
        SaveLoadManager.Data.ItemList.Add(SaveItemData.GetRandomItem());
    }

    public void Save()
    {
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
        Debug.Log($"JSON 저장 경로: {Application.persistentDataPath}");
    }

    public void Load()
    {
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
        foreach (var data in SaveLoadManager.Data.ItemList)
        {
            Debug.Log(data);
        }
    }
}
