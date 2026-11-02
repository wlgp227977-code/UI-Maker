using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> windows;

    public Windows defaultWindow;
    public Windows CurrentWindow { get; private set; }
    private void Start()
    {
        foreach (var window in windows)
        {
            window.Init(this);      // 관리하는 window에 직접 접근
            window.gameObject.SetActive(false);
        }

        CurrentWindow = defaultWindow;
        windows[(int)CurrentWindow].Open();         // ?
    }
    public void Open(Windows id)
    {
        windows[(int)CurrentWindow].Close();
        CurrentWindow = id;
        windows[(int)CurrentWindow].Open();
    }
}
