using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private TMPro.TextMeshProUGUI _currentScoreText;
    [SerializeField] private float _countingSpeed = 0.1f;

    private int _currentScore = 0;
    private bool _isCounting = true;

    [SerializeField] private int _highScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentScoreText.text = _currentScore.ToString();
        _playerHealth.OnDeath.AddListener(StopCounting);
        InvokeRepeating("Count", 0f, _countingSpeed);
    }

    void Count()
    {
        if (_isCounting)
        {
            _currentScore += 1;
            _currentScoreText.text = _currentScore.ToString();
        }
    }
    void StopCounting()
    {
        _isCounting = false;
        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            Debug.Log($"New high score: {_highScore}");
        }
        else
        {
            Debug.Log($"Final score: {_currentScore}");
        }
    }


}
