using UnityEngine;

// Player 이동
public class PlayerMove : MonoBehaviour
{
    // 필요 속성:
    [Header("능력치")]
    private float _speed = 2f;          // 속력
    public float Speed=> _speed;
    private const float _maxSpeed = 6f; // 최고 속력
    private const float _minSpeed = 1f;
    public float SpeedMultiplier = 1.2f;    // Shift키 누르면 속도 배 상승

    [Header("원점 좌표")]
    private Vector2 _originPosition = new Vector2(0f, -2.5f); 
    public Vector2 OriginPosition => _originPosition;

    [Header("이동 범위")]
    public float MinX = -2.4f;
    public float MaxX = 2.4f;
    public float MinY = -4.5f;
    public float MaxY = 0f;

    private bool _isReturningToOrigin = false;

    private Animator _animator;

    private void Start()
    {
        _originPosition = transform.position; 
        _animator = GetComponent<Animator>();
    }

    public void TurnOnMovingOrigin(bool isMovingOrigin)
    {
        if (isMovingOrigin)
        {
            _isReturningToOrigin = true;
        }
        else
        {
            _isReturningToOrigin = false;
        }
    }
    public void MovePlayer(Vector2 direction)
    {
        if(_isReturningToOrigin)
        {
            direction = ReturnToOrigin();
        }
        _animator.SetInteger("x", (int)direction.x);

        Vector2 currentPosition = transform.position;
        Vector2 newPosition = currentPosition + direction * _speed * Time.deltaTime;

        newPosition.x = WrapValue(newPosition.x, MinX, MaxX);
        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        transform.position = newPosition;
    }

    public void ChangeSpeedUp(bool speedUp)
    {
        if(speedUp)
        {
            _speed++;
        }
        else
        {
            _speed--;
        }

        _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
    }
    public void BoostSpeed(bool isBoosting)
    {
        if (isBoosting)
            _speed *= SpeedMultiplier;
        else
            _speed /= SpeedMultiplier;
    }

    private Vector2 ReturnToOrigin()
    {
        Vector2 currentPosition = transform.position;
        Vector2 directionToOrigin = _originPosition - currentPosition;
        return directionToOrigin.normalized;
    }

    // 플레이어의 x좌표를 화면 밖으로 나가면 반대편에서 나오도록 처리
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

    public void MoveSpeedUp(float value)
    {
        _speed += value;
        _speed = Mathf.Min(_speed, _maxSpeed);
    }
}
