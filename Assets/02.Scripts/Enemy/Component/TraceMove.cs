using UnityEngine;

public class TraceMove : Movement
{
    private GameObject _playerObject;
    private const float AngleOffset = 90f;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");    
    }
    protected override void Move()
    {
        if (_playerObject == null) return;

        Vector2 direction = _playerObject.transform.position - transform.position;
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
