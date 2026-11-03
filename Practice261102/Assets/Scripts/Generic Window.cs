using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{
    protected WindowManager manager;
    public GameObject firstSelected;
    private EventSystem eventSystem;

    protected virtual void Awake()
    {
        eventSystem = EventSystem.current;
    }
    public void Init(WindowManager manager)
    {
        this.manager = manager;
    }
    public void OnFocus()
    {
        eventSystem.SetSelectedGameObject(firstSelected);   // 실행하자마자 셀렉티드 된 상태
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
