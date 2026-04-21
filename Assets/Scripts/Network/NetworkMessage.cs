public enum MessageType
{
    PlayerMove,
    EggSpawn,
    EggCollected
}

public class NetworkMessage
{
    public MessageType Type;
    public float TimeStamp;
    public object Data;
}