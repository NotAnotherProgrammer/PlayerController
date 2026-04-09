using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool GameEnded { get; private set; } = false;

    [Header("Timer")]
    public float gameTime = 300f; // 5 minutes

    public System.Action<float> OnTimerChanged;
    public System.Action<string> OnGameEndMessage;

    private float timeRemaining;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        timeRemaining = gameTime;
    }

    private void Update()
    {
        if (!GameEnded && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            OnTimerChanged?.Invoke(timeRemaining);

            if (timeRemaining <= 0)
            {
                GameOver(false);
                OnGameEndMessage?.Invoke("Time's Up! Game Over!");
            }
        }
    }

    public void GameOver(bool won)
    {
        GameEnded = true;
        // Handle game over logic here
        string message = won ? "You Win!" : "Game Over!";
        Debug.Log(message);
        OnGameEndMessage?.Invoke(message);
        // You can add scene loading, UI updates, etc.
    }

    public void RestartGame()
    {
        GameEnded = false;
        timeRemaining = gameTime;
        OnTimerChanged?.Invoke(timeRemaining);
        // Reset game state
    }
}