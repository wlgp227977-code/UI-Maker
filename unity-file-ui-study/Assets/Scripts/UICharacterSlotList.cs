using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICharacterSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        CreationCharacterAsscending,
        CreationCharacterDesscending,
        NameAsscending,
        NameDesscending
    }
    
    public readonly System.Comparison<SaveCharacterData>[] comparisons =
    {
        (lhs, rhs) => lhs.CreationTime.CompareTo(rhs.CreationTime),
        (lhs, rhs) => rhs.CreationTime.CompareTo(lhs.CreationTime),
        (lhs, rhs) => lhs.CharacterData.StringName.CompareTo(rhs.CharacterData.StringName),
        (lhs, rhs) => rhs.CharacterData.StringName.CompareTo(lhs.CharacterData.StringName),
    };
    private SortingOptions sorting = SortingOptions.CreationCharacterAsscending;
    public SortingOptions Sorting
    {
        get => sorting;
        set
        {
            if (sorting != value)
            {
                sorting = value;
                UpdateSlot();
            }
        }
    }

    private int selectedSlot = -1;
    public UnityEvent OnUpdateSlots;
    public UnityEvent<SaveCharacterData> OnSelectSlot;
    public UICharacterSlot prefab;
    public ScrollRect scrollRect;
    private List<UICharacterSlot> uiSlotList = new List<UICharacterSlot>();
    private List<SaveCharacterData> saveCharacterDataList = new List<SaveCharacterData>();

    public void SetSaveCharacterList(List<SaveCharacterData> source)
    {
        saveCharacterDataList = new List<SaveCharacterData>(source);

    }
    public List<SaveCharacterData> GetSaveCharacterDataList()
    {
        return saveCharacterDataList;
    }
    private void UpdateSlot()
    {
        var list = saveCharacterDataList;
        list.Sort(comparisons[(int)sorting]);  
        if (uiSlotList.Count < list.Count)
        {
            for (int i = uiSlotList.Count; i < list.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.SlotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                newSlot.button.onClick.AddListener(() =>
                {
                    selectedSlot = newSlot.SlotIndex;
                    if (newSlot.CharacterData != null)
                    {
                        OnSelectSlot.Invoke(newSlot.CharacterData);
                    }
                });
                uiSlotList.Add(newSlot);
            }
        }
        for (int i = 0; i < uiSlotList.Count; i++)
        {
            if (i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetCharacter(list[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
        }

    }
    public void AddRandomCharacter()
    {
        saveCharacterDataList.Add(SaveCharacterData.GetRandomCharacter());
        UpdateSlot();
    }
    public void RemoveCharacter()
    {
        if (selectedSlot == -1)
        {
            return;
        }
        saveCharacterDataList.Remove(uiSlotList[selectedSlot].CharacterData);
        UpdateSlot();
    }

}
