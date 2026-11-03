using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;
    public bool canContinue = false;

    protected override void Awake()
    {
        base.Awake();
        continueButton.onClick.AddListener(OnClickContinue);
        newGameButton.onClick.AddListener(OnClickNewGame);
        optionButton.onClick.AddListener(OnClickOption);
        // 이 코드와 Inspector에서 OnClick에추가하는거랑 같은거임
    }
    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSelected = canContinue ? continueButton.gameObject : newGameButton.gameObject;
        base.Open();
    }

    public void OnClickContinue()
    {
        manager.Open(Windows.GameOver);
    }
    public void OnClickNewGame()
    {
        manager.Open(Windows.Keyboard);
    }
    public void OnClickOption()
    {
        Debug.Log("OnClickOption");
    }
}
