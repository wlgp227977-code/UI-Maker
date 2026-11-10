using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICharacterSlot : MonoBehaviour
{
    public int SlotIndex = -1;
    public Button button;
    public Image icon;
    public TMP_Text textCharacterName;

    public SaveCharacterData CharacterData { get; private set; }
    public void SetEmpty()
    {
        CharacterData = null;
        icon.sprite = null;
        textCharacterName.text = string.Empty;
    }
    public void SetCharacter(SaveCharacterData data)
    {
        CharacterData = data;
        icon.sprite = CharacterData.characterData.SpriteIcon;
        textCharacterName.text = CharacterData.characterData.StringName;
    }

}
