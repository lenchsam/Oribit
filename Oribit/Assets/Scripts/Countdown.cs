using UnityEngine;
using TMPro;
using static UIUtils;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private int _countdownTime = 3;
    private int _counter = 3;

    private void Start()
    {
        _countdownText.text = (_counter).ToString();
    }
    public void StartCountdown()
    {
        _countdownText.gameObject.SetActive(true);
        _counter = _countdownTime;
        _countdownText.text = _counter.ToString();
        InvokeRepeating("UpdateCountdown", 1f, 1f);
    }
    private void UpdateCountdown()
    {
        if (_counter > 0)
        {
            _counter--;
            _countdownText.text = _counter.ToString();
        }
        else
        {
            CancelInvoke("UpdateCountdown");
            _countdownText.gameObject.SetActive(false);
            GameManager.Instance.StartGame(); // Assuming GameManager is a singleton

        }
    }
}

