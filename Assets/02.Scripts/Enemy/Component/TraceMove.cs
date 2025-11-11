using UnityEngine;

public class TraceMove : Movement
{
    private Transform _playerTransform;
    // 기본 스프라이트가 위쪽(Up)을 기준으로 제작되었기 때문에, x축 기반으로 계산된 각도에 90도 오프셋을 적용한다
    private const float AngleOffset = 90f;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            _playerTransform = playerObject.transform;
        }
    }
    protected override void Move()
    {
        if (_playerTransform == null) return;

        Vector2 direction = _playerTransform.position - transform.position;
        direction.Normalize();
        FaceToPlayer(direction);
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    private void FaceToPlayer(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + AngleOffset;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
