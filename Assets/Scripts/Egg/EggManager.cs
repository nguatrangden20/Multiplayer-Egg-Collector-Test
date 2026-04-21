using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public static EggManager Instance;

    public GameObject eggPrefab;

    private Dictionary<int, GameObject> eggs = new Dictionary<int, GameObject>();

    private int currentId = 0;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnEgg(NetworkMessage msg)
    {
        Vector3 pos = (Vector3)msg.Data;

        GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);

        int id = currentId++;
        egg.GetComponent<Egg>().id = id;

        eggs.Add(id, egg);

        BotManager.Instance.NotifyEggSpawn(pos);
    }

    public void CollectEgg(NetworkMessage msg)
    {
        int id = (int)msg.Data;

        if (eggs.ContainsKey(id))
        {
            Destroy(eggs[id]);
            eggs.Remove(id);
        }
    }
}