using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UICharacterList : MonoBehaviour
{
    public readonly string[] SortingOptionNames =
    {        
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC"
    };
    public TMP_Dropdown sorting;
    public UICharacterSlotList uICharacterSlotList;

    private void OnEnable()
    {
        UpdateDropdownOptions();
        Variables.OnLanguageChanged += UpdateDropdownOptions;

        OnLoad();
        OnChangeSorting(sorting.value);        
    }
    private void OnDisable()
    {
        Variables.OnLanguageChanged -= UpdateDropdownOptions;
        OnSave();
    }

    public void UpdateDropdownOptions()
    {
        var stringTable = DataTableManager.StringTable;
        sorting.ClearOptions();
        var options = new List<string>();

        foreach (var id in SortingOptionNames)
        {
            options.Add(stringTable.Get(id));
        }
        sorting.AddOptions(options);
    }
    public void OnChangeSorting(int index)
    {
       uICharacterSlotList.Sorting = (UICharacterSlotList.SortingOptions)index;
    }
    public void OnSave()
    {
        SaveLoadManager.Data.CharacterList = uICharacterSlotList.GetSaveCharacterDataList();
        SaveLoadManager.Save();
    }
    public void OnLoad()
    {
        SaveLoadManager.Load();
        uICharacterSlotList.SetSaveCharacterList(SaveLoadManager.Data.CharacterList);
    }
    public void OnCreateItem()
    {
        uICharacterSlotList.AddRandomCharacter();
    }
    public void OnRemoveItem()
    {
        uICharacterSlotList.RemoveCharacter();
    }
    
}
