using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GuessTry : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private int _initialNumberOfTries = 7;
    private int _tries;

    private Text _numberOfTriesText;

    private void Start()
    {
        _tries = _initialNumberOfTries;
        SetTriesText();
    }

    private void OnEnable()
    {
        _numberOfTriesText = GetComponent<Text>();

        GuessButton.Instance.WrongGuess += RemoveOneTry;
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
