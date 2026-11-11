using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiCharacterInfo2 : MonoBehaviour
{
    public static readonly string FormatString = "{0}: {1}";
    public Image icon;
    public TMP_Text textName;
    public TMP_Text textHP;
    public TMP_Text textAtk;
    public TMP_Text textDef;
    public TMP_Text textSpeed;

    public void SetEmpty()
    {
        icon.sprite = null;
        icon.enabled = false;
        textName.text = string.Empty;
        textHP.text = string.Empty;
        textAtk.text = string.Empty;
        textDef.text = string.Empty;
        textSpeed.text = string.Empty;
    }

    public void SetCharacter(SaveCharacterData saveCharacterData)
    {
        var st = DataTableManager.StringTable;
        var data = saveCharacterData.CharacterData;
        icon.sprite = saveCharacterData.CharacterData.SpriteIcon;
        icon.enabled = true;
        textName.text = string.Format(FormatString, st.Get("NAME"), data.StringName);
        textHP.text = string.Format(FormatString, st.Get("Hp"), data.Hp);
        textAtk.text = string.Format(FormatString, st.Get("Atk"), data.Atk);
        textDef.text = string.Format(FormatString, st.Get("Def"), data.Def);
        textSpeed.text = string.Format(FormatString, st.Get("Speed"), data.Speed);
    }

}
