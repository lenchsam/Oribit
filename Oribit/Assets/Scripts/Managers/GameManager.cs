using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindAnyObjectByType<GameManager>();
            }

            return _instance;
        }
    }

    public UnityEvent OnGamePlay = new UnityEvent();

    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        Debug.Log("Game Started");

        OnGamePlay.Invoke();
    }
}
