using UnityEngine;

public delegate void VoidDelegate();

public static class SaveSystem
{
    private static readonly string _winCountName = "WinCount";
    private static readonly string _loseCountName = "LoseCount";

    public static event VoidDelegate WinAdded;
    public static event VoidDelegate LoseAdded;

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
