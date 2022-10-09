using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ball;

    public GameObject player1Paddle;
    public GameObject player1Goal;

    public GameObject player2Paddle;
    public GameObject player2Goal;

    public GameObject Player1Text;
    public GameObject Player2Text;

    private int Player1Score;
    private int Player2Score;

    private bool gameEnd = false;
    public bool gameStarted = false;

    public GameObject endGameUI;
    public GameObject startGameUI;
    
    public void Player1Scored(){
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        if (Player1Score >= 5){
            //endGameUI.GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!";
            endGameUI.SetActive(true);
            gameEnd = true;
        }
        else
        {
            ResetPosition();
        }
    }
    public void Player2Scored(){
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        if (Player2Score >= 5){
            //endGameUI.GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!";
            endGameUI.SetActive(true);
            gameEnd = true;
        }
        else
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<PlayerMovement>().Reset();
        player2Paddle.GetComponent<PlayerMovement>().Reset();
    }

    public void EndGame(){
        endGameUI.SetActive(true);
    }

    void Update(){
        if (gameEnd){
            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (!gameStarted){
            if (Input.GetKeyDown(KeyCode.Space)){
                startGameUI.SetActive(false);
                gameStarted = true;
                ResetPosition();
            }
        }
    }
}
