using UnityEngine;

public static class SaveSystem
{
    private static readonly string _winCountName = "WinCount";
    private static readonly string _loseCountName = "LoseCount";

    public delegate void WinAddedDelegate();
    public static event WinAddedDelegate WinAdded;

    public delegate void LoseAddedDelegate();
    public static event LoseAddedDelegate LoseAdded;

    public static void AddWin()
    {
        int winCount = PlayerPrefs.GetInt(_winCountName);
        PlayerPrefs.SetInt(_winCountName, ++winCount);
        PlayerPrefs.Save();

        WinAdded?.Invoke();
    }

    public static void AddLose()
    {
        int loseCount = PlayerPrefs.GetInt(_loseCountName);
        PlayerPrefs.SetInt(_loseCountName, ++loseCount);
        PlayerPrefs.Save();

        LoseAdded?.Invoke();
    }

    public static int GetWinCount()
    {
        return PlayerPrefs.GetInt(_winCountName);
    }

    public static int GetLoseCount()
    {
        return PlayerPrefs.GetInt(_loseCountName);
    }
}
