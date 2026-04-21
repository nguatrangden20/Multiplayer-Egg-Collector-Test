using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerSimulator : MonoBehaviour
{
    public static ServerSimulator Instance;
    public LayerMask obstacleMask;
    private Queue<NetworkMessage> messageQueue = new Queue<NetworkMessage>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnEgg), 1f, 2f);
    }

    void SpawnEgg()
    {
        Vector3 pos;
        int maxTry = 20;

        do
        {
            pos = new Vector3(
                Random.Range(-8, 8),
                0.5f,
                Random.Range(-8, 8)
            );

            maxTry--;

        } while (Physics.CheckSphere(pos, 0.4f, obstacleMask) && maxTry > 0);

        NetworkMessage msg = new NetworkMessage()
        {
            Type = MessageType.EggSpawn,
            Data = pos
        };

        SendMessageToClient(msg);
    }

    public void SendMessageToClient(NetworkMessage msg)
    {
        StartCoroutine(DelayMessage(msg));
    }

    IEnumerator DelayMessage(NetworkMessage msg)
    {
        float delay = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(delay);

        NetworkClient.Instance.ReceiveMessage(msg);
    }
}