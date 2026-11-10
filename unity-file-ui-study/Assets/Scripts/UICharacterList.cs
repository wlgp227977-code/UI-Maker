using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UICharacterList : MonoBehaviour
{
    public readonly string[] SortingOptionNames =
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC"
    };
    public readonly string[] FilteringOptionNames =
    {
        "FILTER_ALL",
        "FILTER_WEAPON",
        "FILTER_EQUIP",
        "FILTER_CONSUMABLE"
    };
}
