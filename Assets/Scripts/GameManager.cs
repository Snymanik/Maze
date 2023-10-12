using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int TimeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0, silverKey = 0, goldKey = 0;

    public static GameManager gameManager;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
            if (TimeToEnd <= 0)
                TimeToEnd = 100;
            InvokeRepeating("Stopper", 2, 1);
        }
    }
    private void Update()
    {
        PauseCheck();
    }
    void Stopper()
    {
        TimeToEnd--;
        Debug.Log($"Time:{TimeToEnd}s");
        if (TimeToEnd <= 0)
        {
            TimeToEnd = 0;
            endGame = true;
        }
        if (endGame)
            EndGame();
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else PauseGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win! Reload?");
        }
        else
        {
            Debug.Log("You lose! Reload?");
        }

    }
    public void AddPoints(int points)
    {
        this.points += points;
    }
    public void AddTime(int time)
    {
        TimeToEnd += time;
    }
    public void FreezeTime(int freezetime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezetime, 1);
    }
    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red)
        {
            redKey++;
        }
        else if (keyColor == KeyColor.Silver)
        {
            silverKey++;
        }
        else if (keyColor == KeyColor.Gold)
        {
            goldKey++;
        }
        else Debug.Log("Incorrect key color!");
    }
}
