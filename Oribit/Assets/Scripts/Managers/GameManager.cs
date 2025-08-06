using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
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
