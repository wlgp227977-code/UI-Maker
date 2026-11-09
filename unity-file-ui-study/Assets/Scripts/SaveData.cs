using Unity.VisualScripting;
using UnityEngine;

public abstract class SaveData
{
    public int Version { get; protected set; }
    public abstract SaveData VersionUp();
}

public class SaveDataV4 : SaveData
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Gold { get; set; } = 100;
    public string PlayerName
    {
        get
        {
            return FirstName + " " + SecondName;
        }
        set
        {
            string[] names = value.Split(' ');
            FirstName = names[0];
            SecondName = names[1];
        }
    }
    public SaveDataV4()
    {
        Version = 4;
    }
    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }
}

public class SaveDataV3 : SaveData      // SaveDataV2를 부모로 상속받아도 됨
{
    public string PlayerName { get; set; } = string.Empty;
    public int Exp { get; set; } = 1000;
    public int Gold { get; set; } = 100;
    public SaveDataV3()
    {
        Version = 3;
    }
    public override SaveData VersionUp()
    {

        var data = new SaveDataV4();
        data.PlayerName = PlayerName;
        data.Gold = Gold;
        return data;
    }
}
public class SaveDataV2 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;
    public SaveDataV2()
    {
        Version = 2;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV3();
        data.PlayerName = PlayerName;
        data.Gold = Gold;
        return data;
    }
}

public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV2();
        data.PlayerName = PlayerName;
        return data;
    }
}