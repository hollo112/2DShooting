using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAutoMove : MonoBehaviour
{
    [Header("자동 이동 조건")]
    public float DetectRangeY = 4f;   // 내 위에서 적 감지할 거리
    public float AttackRangeY = 6f;   // 공격(앞으로 가기) 가능 거리
    public float DangerRangeX = 1.2f; // x축으로 가까우면 회피
    public float MoveThreshold = 0.1f; // x축으로 거의 정렬되면 멈춤
    public float CheckRange = 1.5f; // 양쪽 위협 탐색 범위

    private PlayerMove _move;
    private Vector2 _currentAvoidDir = Vector2.zero; // 회피 유지용 방향

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
    }

    public void HandleAutoMove()
    {
        if (EnemyManager.Instance == null)
        {
            MoveToCenter();
            return;
        }

        // 가장 가까운 적 탐색
        Transform closest = EnemyManager.Instance.GetClosestEnemy(transform.position);
        if (closest == null)
        {
            MoveToCenter();
            return;
        }

        Vector2 myPos = transform.position;
        Vector2 enemyPos = closest.position;

        // 내 아래에 있으면 무시하고 중앙 복귀
        if (enemyPos.y <= myPos.y)
        {
            MoveToCenter();
            return;
        }

        // y, x가 둘 다 가까우면 회피 판단
        float yDiff = enemyPos.y - myPos.y;
        float xDiff = enemyPos.x - myPos.x;

        if (yDiff < DetectRangeY && Mathf.Abs(xDiff) < DangerRangeX)
        {
            AvoidClosestEnemy(closest);
            return;
        }

        // 위험 없으면 적 쪽으로 이동
        MoveTowardEnemy(closest);
    }

    private void MoveToCenter()
    {
        _move.TurnOnMovingOrigin(true);
        _move.MovePlayer(Vector2.zero);
    }

    // 가장 가까운 적 방향으로 이동
    private void MoveTowardEnemy(Transform enemy)
    {
        _move.TurnOnMovingOrigin(false);

        Vector2 myPos = transform.position;
        float xDiff = enemy.position.x - myPos.x;
        float yDiff = enemy.position.y - myPos.y;

        if (Mathf.Abs(xDiff) < MoveThreshold)
        {
            if (yDiff > 0 && yDiff > AttackRangeY)
            {
                Vector2 advanceDir = Vector2.up;
                _move.MovePlayer(advanceDir);
            }
            else
            {
                _move.MovePlayer(Vector2.zero);
            }
            return;
        }


        // 적이 오른쪽에 있으면 오른쪽, 왼쪽에 있으면 왼쪽 이동
        Vector2 dir = (xDiff > 0f) ? Vector2.right : Vector2.left;
        _move.MovePlayer(dir);
    }
   
    // 회피 로직
    private void AvoidClosestEnemy(Transform closest)
    {
        _move.TurnOnMovingOrigin(false);

        Vector2 myPos = transform.position;
        Vector2 enemyPos = closest.position;
        Vector2 moveDir;

        // 적 반대 방향으로 회피
        moveDir = (enemyPos.x > myPos.x) ? Vector2.left : Vector2.right;

        // 양쪽 적 밀도 비교, 더 적은 쪽으로 회피 보정
        float dangerLeft = EnemyManager.Instance.CountEnemiesNear(myPos + Vector2.left * CheckRange, 1f);
        float dangerRight = EnemyManager.Instance.CountEnemiesNear(myPos + Vector2.right * CheckRange, 1f);

        if (dangerLeft > dangerRight)
            moveDir = Vector2.right;
        else if (dangerRight > dangerLeft)
            moveDir = Vector2.left;

        moveDir += Vector2.down;

        _currentAvoidDir = moveDir.normalized;
        _move.MovePlayer(_currentAvoidDir);
    }
}
