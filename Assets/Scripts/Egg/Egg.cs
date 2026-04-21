using UnityEngine;

public class Egg : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect("Player");
        }
        else if (other.CompareTag("Bot"))
        {
            Collect("Bot");
        }
    }

    void Collect(string playerId)
    {
        GameManager.Instance.AddScore(playerId);

        NetworkMessage msg = new NetworkMessage()
        {
            Type = MessageType.EggCollected,
            Data = id
        };

        ServerSimulator.Instance.SendMessageToClient(msg);
    }
}