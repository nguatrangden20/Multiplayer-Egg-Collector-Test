using UnityEngine;

public class NetworkClient : MonoBehaviour
{
    public static NetworkClient Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ReceiveMessage(NetworkMessage msg)
    {
        switch (msg.Type)
        {
            case MessageType.PlayerMove:
                RemotePlayerManager.Instance.OnPlayerMove(msg);
                break;

            case MessageType.EggSpawn:
                EggManager.Instance.SpawnEgg(msg);
                break;

            case MessageType.EggCollected:
                EggManager.Instance.CollectEgg(msg);
                break;
        }
    }
}