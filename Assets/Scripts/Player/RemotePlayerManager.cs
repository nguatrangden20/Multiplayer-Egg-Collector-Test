using System.Collections.Generic;
using UnityEngine;

public class RemotePlayerManager : MonoBehaviour
{
    public static RemotePlayerManager Instance;

    public GameObject remotePlayerPrefab;

    private Dictionary<string, RemotePlayer> players = new Dictionary<string, RemotePlayer>();

    private void Awake()
    {
        Instance = this;
    }

    public void OnPlayerMove(NetworkMessage msg)
    {
        var data = (PlayerMoveData)msg.Data;

        if (!players.ContainsKey(data.playerId))
        {
            SpawnRemotePlayer(data.playerId, data.position);
        }

        players[data.playerId].SetTarget(data.position);
    }

    void SpawnRemotePlayer(string id, Vector3 pos)
    {
        GameObject go = Instantiate(remotePlayerPrefab, pos, Quaternion.identity);
        RemotePlayer rp = go.GetComponent<RemotePlayer>();

        players.Add(id, rp);
    }
}