using System;
using Newtonsoft.Json;
using UnityEngine;

public class SaveCharacterData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(CharacterConverter))]
    public CharacterData characterData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveCharacterData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId} {characterData.Id} : (${CreationTime})";
    }
    public static SaveCharacterData GetRandomCharacter()
    {
        var newCharacter = new SaveCharacterData();
        newCharacter.characterData = DataTableManager.CharacterTable.GetRandom();
        return newCharacter;
    }

}
