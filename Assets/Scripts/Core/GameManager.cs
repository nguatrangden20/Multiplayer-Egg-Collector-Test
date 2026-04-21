using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime = 60f;
    private float timer;
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = gameTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(string playerId)
    {
        if (!scores.ContainsKey(playerId))
            scores[playerId] = 0;

        scores[playerId]++;

        UIManager.Instance.UpdateScore(playerId);
    }

    void EndGame()
    {
        string winner = "";
        int max = -1;

        foreach (var kv in scores)
        {
            if (kv.Value > max)
            {
                max = kv.Value;
                winner = kv.Key;
            }
        }

        Debug.Log("Winner: " + winner);

        UIManager.Instance.ShowWinner(winner);

        Time.timeScale = 0;
    }
}