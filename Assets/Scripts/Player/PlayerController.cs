using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        transform.position += move * speed * Time.deltaTime;

        SendToServer();
    }

    void SendToServer()
    {
        var Data = new PlayerMoveData()
        {
            position = transform.position,
            time = Time.time,
            playerId = "Player_1"
        };

        NetworkMessage msg = new NetworkMessage()
        {
            Type = MessageType.PlayerMove,
            TimeStamp = Time.time,
            Data = Data
        };

        ServerSimulator.Instance.SendMessageToClient(msg);
    }
}