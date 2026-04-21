using System.Collections.Generic;
using UnityEngine;

public class BotAI : MonoBehaviour
{
    public float speed = 3f;

    private List<Vector3> path;
    private int pathIndex;

    void Update()
    {
        if (path == null || pathIndex >= path.Count)
            return;

        Vector3 target = path[pathIndex];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
            pathIndex++;
    }

    public void MoveTo(Vector3 target)
    {
        path = AStar.Instance.FindPath(transform.position, target);
        pathIndex = 0;
    }
}