using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;

    public Ball ball;
    public TMP_Text PlayerScore;
    public TMP_Text ComputerScore;

    public void PlayerScores(){
        _playerScore++;
        PlayerScore.text = _playerScore.ToString();
        this.ball.ResetBall();
    }

    public void ComputerScores(){
        _computerScore++;
        ComputerScore.text = _computerScore.ToString();
        this.ball.ResetBall();
    }


}
