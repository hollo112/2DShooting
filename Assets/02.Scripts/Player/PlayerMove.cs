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
    public float Speed = 3f;    // 속력

    // 게임 오브젝트가 게임을 시작할 때
    private void Start()
    {
        
    }

    // 게임 오브젝트가 게임을 시작 후 프레임마다
    private void Update()
    {
        // 1. 키보드 입력을 받는다.
        // 유니티에서는 Input이라고 하는 모듈이 입력에 관한 모든것을 담당한다
        float h = Input.GetAxis("Horizontal");    // 세로축, 수평 입력에 대한 값을 -1, 0, 1사이로 가져온다
        float v = Input.GetAxis("Vertical");      // 가로축, 수직 입력에 대한 값을 -1, 0, 1사이로 가져온다

        Debug.Log($"h: {h}, v: {v}");

        // 2. 방향을 구한다.
        Vector2 direction = new Vector2(h, v);   // 방향 벡터를 만든다
        Debug.Log($"direction: {direction}");

        // 3. 이동한다.
        Vector2 position = transform.position;          // 현재 위치를 가져온다

        // 새로운 위치 = 현재 위치 + 방향 * 속력 * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;     // 새로운 위치

        // Time.deltaTime : 마지막 프레임이 끝나고 지금 프레임이 시작될 때까지 걸린 시간(초)
        // 1초 / fps 값과 비슷하다
        transform.position = newPosition;               // 새로운 위치로 이동한다
        
    }
}
