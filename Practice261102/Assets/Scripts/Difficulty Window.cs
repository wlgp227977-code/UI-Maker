using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

// 선택한 난이도 저장, 다시 윈도우가 열릴때 저장된걸로 시작, 화살표키로 선택을 바꿈, esc로 스타트화면

public class DifficultyWindow : GenericWindow
{
    public enum Difficulty
    {
        None = -1,
        Easy,
        Normal,
        Hard,
    }
    public Toggle[] toggles;
    private Difficulty savedDifficulty;

    public Difficulty CurrentDifficulty
    {
        get
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    return (Difficulty)i;
                }
            }
            return Difficulty.None;
        }
        set
        {
            toggles[(int)value].isOn = true;
        }
    }
    public override void Open()
    {
        CurrentDifficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 1);
        base.Open();

    }
    public override void Close()
    {
        PlayerPrefs.SetInt("Difficulty", (int)CurrentDifficulty);
        base.Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("Difficulty", (int)CurrentDifficulty);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentDifficulty = Difficulty.Easy;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentDifficulty = Difficulty.Normal;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentDifficulty = Difficulty.Hard;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int index = (int)CurrentDifficulty;
            index = (int)Mathf.Repeat(index + 1, toggles.Length);
            CurrentDifficulty = (Difficulty)index;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int index = (int)CurrentDifficulty;
            index = (int)Mathf.Repeat(index - 1, toggles.Length);
            CurrentDifficulty = (Difficulty)index;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.Open(Windows.Start);
        }


    }
    public void OnClickEasy(bool value)
    {
        if (value == true)
        {
            CurrentDifficulty = Difficulty.Easy;

        }
    }
    public void OnClickNormal(bool value)
    {
        if (value == true)
        {
            CurrentDifficulty = Difficulty.Normal;

        }
    }
    public void OnClickHard(bool value)
    {
        if (value == true)
        {
            CurrentDifficulty = Difficulty.Hard;

        }
    }
}
