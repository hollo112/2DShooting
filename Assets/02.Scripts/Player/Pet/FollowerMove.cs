using System.Collections.Generic;
using UnityEngine;

public class FollowerMove : MonoBehaviour
{
    [Header("따라갈 대상")]
    public Transform Target;

    [Header("딜레이 크기 (Queue 최대 크기)")]
    public int MaxQueue = 50;

    private Queue<Vector2> _positionQueue = new Queue<Vector2>();
    private Vector2 _followPostion;
    private Vector2 _targetPosition;
    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        _targetPosition = Target.position;

        // 1. 부모 위치 큐에 추가
        if(!_positionQueue.Contains(_targetPosition))
        {
            _positionQueue.Enqueue(_targetPosition);
        }

        // 2. 큐 크기가 MaxQueue를 넘으면
        if (_positionQueue.Count > MaxQueue)
        {
            // 가장 오래된 위치를 꺼내서 follower 위치로 이동
            _followPostion = _positionQueue.Dequeue();
        }
        else if (_positionQueue.Count < MaxQueue)
        {
            _followPostion = Target.position;
        }
            transform.position = _followPostion;
    }
}
