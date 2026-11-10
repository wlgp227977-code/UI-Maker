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
        textName.text = string.Empty;
        textHP.text = string.Empty;
        textAtk.text = string.Empty;
        textDef.text = string.Empty;
        textSpeed.text = string.Empty;
    }

    public void SetCharacter()
    {
        icon.sprite = null;
        textName.text = string.Empty;
        textHP.text = string.Empty;
        textAtk.text = string.Empty;
        textDef.text = string.Empty;
        textSpeed.text = string.Empty;
    }

}
