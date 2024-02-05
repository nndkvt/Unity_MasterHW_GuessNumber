using UnityEngine;
using UnityEngine.UI;

public class GuessTry : MonoBehaviour
{
    [SerializeField] private Text _numberOfTriesText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private int _initialNumberOfTries = 5;
    private int _tries;

    private void Start()
    {
        _tries = _initialNumberOfTries;
        SetTriesText();

        GuessButton.Instance.WrongGuess += RemoveOneTry; // GuessButton should awake first
    }

    private void OnDisable()
    {
        GuessButton.Instance.WrongGuess -= RemoveOneTry;
    }

    private void RemoveOneTry()
    {
        _tries--;
        SetTriesText();

        if (_tries <= 0)
        {
            SaveSystem.AddLose();
            _gameOverScreen.SetActive(true);
        }
    }

    private void SetTriesText()
    {
        _numberOfTriesText.text = "Попытки: " + _tries.ToString();
    }
}
