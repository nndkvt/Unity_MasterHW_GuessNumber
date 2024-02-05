using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WinLoseDisplayer : MonoBehaviour
{
    [SerializeField] private bool _isWinDisplay;
    private string _countName;

    private Text _displayText;

    private void Awake()
    {
        _displayText = GetComponent<Text>();

        if (_isWinDisplay)
        {
            _countName = "Количество побед: ";
            _displayText.text = _countName + SaveSystem.GetWinCount();

            SaveSystem.WinAdded += UpdateDisplay;
        }
        else
        {
            _countName = "Количество неудач: ";
            _displayText.text = _countName + SaveSystem.GetLoseCount();

            SaveSystem.LoseAdded += UpdateDisplay;
        }
    }

    private void OnDisable()
    {
        if (_isWinDisplay)
        {
            SaveSystem.WinAdded -= UpdateDisplay;
        }
        else
        {
            SaveSystem.LoseAdded -= UpdateDisplay;
        }
    }

    private void UpdateDisplay()
    {
        if (_isWinDisplay)
        {
            _displayText.text = _countName + SaveSystem.GetWinCount();
        }
        else
        {
            _displayText.text = _countName + SaveSystem.GetLoseCount();
        }
    }
}
