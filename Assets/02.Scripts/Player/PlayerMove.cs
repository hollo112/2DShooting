using UnityEngine;

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

    [Header("이동 범위")]
    public float MinX = -2.4f;
    public float MaxX = 2.4f;
    public float MinY = -5f;
    public float MaxY = 0f;

    // 게임 오브젝트가 게임을 시작할 때
    private void Start()
    {
        
    }

    // 게임 오브젝트가 게임을 시작 후 프레임마다
    private void Update()
    {
        // 1. 키보드 입력을 받는다.
        // 유니티에서는 Input이라고 하는 모듈이 입력에 관한 모든것을 담당한다
        float h = Input.GetAxisRaw("Horizontal");    // 세로축, GetAxis():수평 입력에 대한 값을 -1 ~ 0 ~ 1사이로 가져온다
        float v = Input.GetAxisRaw("Vertical");      // 가로축, GetAxis():수직 입력에 대한 값을 -1 ~ 0 ~ 1사이로 가져온다

        // 2. 방향을 구한다.
        Vector2 direction = new Vector2(h, v);   // 방향 벡터를 만든다

        // 방향 벡터의 크기를 1로 만든다. (정규화)
        direction = direction.normalized;

        // 3. 이동한다.
        Vector2 position = transform.position;          // 현재 위치를 가져온다

        // 속도 조절
        ChangeSpeed();

        // 새로운 위치 = 현재 위치 + 방향 * 속력 * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;     // 새로운 위치

        // 이동 범위 제한
        //newPosition.x = Mathf.Clamp(newPosition.x, MinX, MaxX); // x좌표 범위 제한
        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY); // y좌표 범위 제한
        newPosition.x = WrapValue(newPosition.x, MinX, MaxX);

        // Time.deltaTime : 마지막 프레임이 끝나고 지금 프레임이 시작될 때까지 걸린 시간(초)
        // 1초 / fps 값과 비슷하다
        transform.position = newPosition;               // 새로운 위치로 이동한다
        
    }

    private void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed += 1f; 
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed -= 1f;
        }
    }

    // 플레이어의 x좌표를 화면 밖으로 나가면 반대편에서 나오도록 처리
    private float WrapValue(float newPosition, float Min, float Max)
    {
        if(newPosition > Max)
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
