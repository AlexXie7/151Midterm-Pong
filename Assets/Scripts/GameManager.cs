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
    
    public void PlayerScores(){
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/colgoal", 1);
        
        _playerScore++;
        PlayerScore.text = _playerScore.ToString();
        this.ball.ResetBall();

        _streak += 1;
        StreakScore.text = "Streak:" + _streak.ToString();
    }

    public void ComputerScores(){
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/colgoal", 1);
        
        _computerScore++;
        ComputerScore.text = _computerScore.ToString();
        this.ball.ResetBall();

        if (_streak > 0)
        {
            _streak -= 1;
        }
        StreakScore.text = "Streak:" + _streak.ToString();
    }

    private void Update()
    {
        if (_streak < 0)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 500);
        }
        else
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/streak", 1);
        }
    }
}
