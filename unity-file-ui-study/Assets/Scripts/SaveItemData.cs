using System;
using Newtonsoft.Json;
using UnityEngine;

public class SaveItemData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]      // 컨버터 없이도 직렬, 역직렬 가능하게 하는 어트리뷰트 
    public ItemData ItemData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveItemData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId} {ItemData.Id} : (${CreationTime})";
    }

    public static SaveItemData GetRandomItem()
    {
        var newItem = new SaveItemData();
        newItem.ItemData = DataTableManager.ItemTable.GetRandom();
        return newItem;
    }
}
