using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    public Button button;

    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }

    public void SetCharacter(string characterId)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(characterId));
    }

    public void SetCharacter(CharacterData data)
    {    
        if (data == null)
        {
            SetEmpty();
            return;
        }

        this.data = data;
        icon.sprite = data.SpriteIcon;
        textName.text = data.StringName;

        Debug.Log($"캐릭터 ID: {data.Id}");
        Debug.Log($"이름 키: {data.Name}");
        Debug.Log($"표시 이름: {data.StringName}");
    }
}