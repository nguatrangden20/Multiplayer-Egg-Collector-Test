using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text playerScoreText;
    public TMP_Text botScoreText;
    public TMP_Text winnerText;

    private int playerScore = 0;
    private int botScore = 0;

    void Awake()
    {
        Instance = this;
        winnerText.gameObject.SetActive(false);
    }

    public void UpdateScore(string playerId)
    {
        if (playerId == "Player")
        {
            playerScore++;
        }
        else
        {
            botScore++;
        }

        playerScoreText.text = "Player: " + playerScore;
        botScoreText.text = "Bot: " + botScore;
    }

    public void ShowWinner(string winner)
    {
        winnerText.gameObject.SetActive(true);
        winnerText.text = "Winner: " + winner;
    }
}