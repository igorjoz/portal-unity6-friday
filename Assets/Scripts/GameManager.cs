using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;

    bool isGameFinished = false;
    bool isGameWon = false;

    public int points = 0;
    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 15;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;

            isGameFinished = true;
        }

        if (isGameFinished)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game is paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game is resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");

        if (isGameWon)
        {
            Debug.Log("You won! Reload?");
        }
        else
        {
            Debug.Log("You lost :c  Reload?");
        }
    }

    void Update()
    {
        CheckPause();
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Gold:
                goldKeys++;
                break;
            case KeyColor.Green:
                greenKeys++;
                break;
            case KeyColor.Red:
                redKeys++;
                break;
        }
    }
}
