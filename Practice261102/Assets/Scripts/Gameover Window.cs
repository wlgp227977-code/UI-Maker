
using UnityEngine;
using TMPro;
using System.Collections;

public class GameoverWindow : GenericWindow
{
    public TMP_Text leftStatsLabel;
    public TMP_Text rightStatsLabel;
    public TMP_Text leftStatsValues;
    public TMP_Text rightStatsValues;
    public TMP_Text textTotalScore;

    private int[] scores = new int[6];
    private int totalScore;

    private float showInterval = 1f;
    private Coroutine showCoroutine;
    private Coroutine routine;


    public override void Open()
    {
        base.Open();
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;         // 이건 습관처럼 넣기 StopCoroutine하자마자 null이 안되니까
        }
        StartCoroutine(ResetScores());
    }
    public override void Close()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        base.Close();
    }

    IEnumerator ResetScores()
    {
        for (int i = 0; i < scores.Length; ++i)
        {
            scores[i] = Random.Range(0, 1000);
        }

        totalScore = Random.Range(0, 100000000);

        leftStatsLabel.text = string.Empty;
        rightStatsLabel.text = string.Empty;
        leftStatsValues.text = string.Empty;
        rightStatsValues.text = string.Empty;

        for (int i = 0; i < scores.Length; ++i)
        {
            yield return new WaitForSeconds(showInterval);

            TMP_Text label = i < 3 ? leftStatsLabel : rightStatsLabel;
            TMP_Text value = i < 3 ? leftStatsValues : rightStatsValues;

            label.text += $"STAT {i + 1}\n";
            value.text += $"{scores[i]:D4}\n";
        }
        yield return new WaitForSeconds(showInterval);

        float elapsed = 0f;
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 2f;
            int value = Mathf.RoundToInt(Mathf.Lerp(0, totalScore, t));   // Lerp에 대해 공부 더하기
            textTotalScore.text = $"{value:D9}";
            yield return null;
        }
        textTotalScore.text = $"{totalScore:D9}";

    }
    public void OnNext()
    {
        manager.Open(Windows.Start);
    }
}
