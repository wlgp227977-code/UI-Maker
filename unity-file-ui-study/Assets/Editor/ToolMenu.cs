using UnityEditor;

public static class ToolMenu
{
    [MenuItem("Tool/언어/한국어")]
    private static void Korean()
    {
        Variables.Language = Languages.Korean;
    }
    [MenuItem("Tool/언어/영어")]
    private static void English()
    {
        Variables.Language = Languages.English;
    }
    [MenuItem("Tool/언어/일본어")]
    private static void Japanese()
    {
        Variables.Language = Languages.Japanese;
    }

}
