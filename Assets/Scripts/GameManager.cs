using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;
    private int _streak;

    public Ball ball;
    public TMP_Text PlayerScore;
    public TMP_Text ComputerScore;
    public TMP_Text StreakScore;

    private void Start()
    {
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/reset", 0);
    }

    public void PlayerScores(){
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/colgoal", 1);
        
        _playerScore++;
        PlayerScore.text = _playerScore.ToString();
        this.ball.ResetBall();

        _streak += 1;
        StreakScore.text = "Streak: " + _streak.ToString();
    }

    public void ComputerScores(){
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/colgoal", 1);
        
        _computerScore++;
        ComputerScore.text = _computerScore.ToString();
        this.ball.ResetBall();
        
        _streak -= 1;
        StreakScore.text = "Streak: " + _streak.ToString();
    }

    private void Update()
    {
        if (_streak == 0)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 0);
        }
        
        // Lower bpm when streak is less than 0
        else if (_streak == -1)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 80);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", -20);
        }
        else if (_streak == -2)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 100);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", -30);
        }
        else if (_streak == -3)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 120);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", -40);
        }

        // Up bpm when streak is greater than 0
        else if (_streak == 1)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 80);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 20);
        }
        else if (_streak == 2)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 100);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 30);
        }
        else if (_streak >= 3)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/bpm", 120);
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 40);
        }
    }
}
