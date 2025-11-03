using UnityEngine;
using static UnityEngine.UI.Image;

// Player 이동
public class PlayerMove : MonoBehaviour
{
    // 목표
    // "키보드 입력"에 따라 "방향"을 구하고 그 방향으로 이동

    // 구현 순서 :
    // 1. 키보드 입력을 받는다.
    // 2. 방향을 구한다.
    // 3. 이동한다.

    // 필요 속성:
    [Header("능력치")]
    public float Speed = 3f;    // 속력
    
    public float MaxSpeed = 10f;
    public float MinSpeed = 1f;
    public float SpeedMultiplier = 1.2f;    // Shift키 누르면 속도 배 상승

    [Header("이동 범위")]
    public float MinX = -2.4f;
    public float MaxX = 2.4f;
    public float MinY = -5f;
    public float MaxY = 0f;
    public Vector2 Origin = new Vector2(0f, -2.5f); // 원점 좌표

    private bool isReturningToOrigin = false; // 원점으로 이동 중인지 여부

    // 게임 오브젝트가 게임을 시작할 때
    private void Start()
    {
        
    }

    // 게임 오브젝트가 게임을 시작 후 프레임마다
    private void Update()
    {
        HandleInput();
        MovePlayer();
    }

    private void HandleInput()
    {
        ChangeSpeed();
        SpeedUpShift();
        MoveToOrigin();
    }

    private void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed--;    
        }

        Speed = Mathf.Clamp(Speed, MinSpeed, MaxSpeed); // 속도 범위 제한
    }
    private void SpeedUpShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed *= SpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed /= SpeedMultiplier;
        }
    }
    private void MoveToOrigin()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReturningToOrigin = true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            isReturningToOrigin = false;
        }
    }
    private void MovePlayer()
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction = GetMovementDirection(currentPosition);
        Vector2 newPosition = currentPosition + direction * Speed * Time.deltaTime;

        // 화면 밖으로 나가지 않도록 처리
        newPosition.x = WrapValue(newPosition.x, MinX, MaxX);
        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        transform.position = newPosition;
    }

    private Vector2 GetInputDirection()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 inputDirection = new Vector2(h, v).normalized;

        return inputDirection;
    }

    private Vector2 GetMovementDirection(Vector2 currentPosition)
    {
        if (isReturningToOrigin)
        {
            Vector2 directionToOrigin = Origin - currentPosition;
            return directionToOrigin.normalized;
        }
        else
        {
            return GetInputDirection();
        }
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
}
