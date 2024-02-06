using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuessButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private GameObject _gameWinScreen;
    [SerializeField] private Text _guessOrNot;
    private int _guessedNum;

    public static GuessButton Instance;

    public event VoidDelegate WrongGuess;

    private void Awake()
    {
        System.Random rand = new();
        _guessedNum = rand.Next(101);

        Instance = this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void OnClick()
    {
        if (_inputField.text != "")
        {
            if (int.Parse(_inputField.text) == _guessedNum)
            {
                SaveSystem.AddWin();
                _gameWinScreen.SetActive(true);
            }
            else if (int.Parse(_inputField.text) < _guessedNum)
            {
                _guessOrNot.text = "Загаданное число больше введенного";
                WrongGuess?.Invoke();
            }
            else
            {
                _guessOrNot.text = "Загаданное число меньше введенного";
                WrongGuess?.Invoke();
            }
        }
        else
        {
            _guessOrNot.text = "Сначала введите число";
        }
    }
}
