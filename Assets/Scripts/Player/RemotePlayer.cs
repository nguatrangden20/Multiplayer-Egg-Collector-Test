using UnityEngine;

public class RemotePlayer : MonoBehaviour
{
    private Vector3 targetPos;

    public float speed = 10f;

    public void SetTarget(Vector3 pos)
    {
        targetPos = pos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
    }
}