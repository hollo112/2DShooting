using System.Collections.Generic;
using UnityEngine;

public class FollowerMove : MonoBehaviour
{
    public GameObject HeadObject;
    public int MaxQueueSize = 100;
    private Queue<(Vector2 direction, float speed)> _headMoveQueue = new Queue<(Vector2 direction, float speed)>();
    [Header("이동 범위")]
    public float MinX = -2.4f;
    public float MaxX = 2.4f;
    public float MinY = -4.5f;
    public float MaxY = 0f;

    // Update is called once per frame
    private void Update()
    {
        MoveFollower();
    }

    public void EnqueueDirection(Vector2 direction, float speed)
    {
        _headMoveQueue.Enqueue((direction, speed));

        if (_headMoveQueue.Count > MaxQueueSize)
            _headMoveQueue.Dequeue();
    }

    private bool DequeueDirection(out Vector2 direction, out float speed)
    {
        if (_headMoveQueue.Count == MaxQueueSize)
        {
            var data = _headMoveQueue.Dequeue();
            direction = data.direction;
            speed = data.speed;
            return true;
        }

        direction = Vector2.zero;
        speed = 0f;
        return false;
    }

    private void MoveFollower()
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction;
        float speed;

        if (DequeueDirection(out direction, out speed))
        {
            Vector2 newPosition = currentPosition + direction * speed * Time.deltaTime;

            newPosition.x = WrapValue(newPosition.x, MinX, MaxX);
            newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

            transform.position = newPosition;
        }
    }

    private float WrapValue(float newPosition, float Min, float Max)
    {
        if (newPosition > Max)
        {
            newPosition = Min;
        }
        else if (newPosition < Min)
        {
            newPosition = Max;
        }

        return newPosition;
    }
}
