using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    public static BotManager Instance;
    public List<BotAI> bots;

    void Awake()
    {
        Instance = this;
    }

    public void NotifyEggSpawn(Vector3 pos)
    {
        foreach (var bot in bots)
        {
            bot.MoveTo(pos);
        }
    }
}