using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    [Header("속성")]
    public float MoveSpeed = 3f;        // 전체 이동 속도
    public float UpdateCurveInterval = 0.5f; // 경로 갱신 주기
    public float WaitTime = 2f;
    private GameObject _player;

    private Vector2 _startPos;
    private Vector2 _controlPos;
    private Vector2 _endPos;
    private float _waitTimer;
    private float _timer;
    private float _curveTimer;
    private bool _isStartedMoving = false;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!_isStartedMoving)
        {
            WaitTimer();
            return;
        }

        _curveTimer += Time.deltaTime;
        _timer += Time.deltaTime * MoveSpeed;

        Vector2 newPos = Bezier(_startPos, _controlPos, _endPos, _timer);
        transform.position = newPos;

        if (_curveTimer >= UpdateCurveInterval)
        {
            _curveTimer = 0f;
            _timer = 0f;
            ChangePoint();
        }
    }

    private void WaitTimer()
    {
        _waitTimer += Time.deltaTime;
        if (_waitTimer >= WaitTime)
        {
            _isStartedMoving = true;
            _startPos = transform.position;
            _endPos = _player.transform.position;
            _controlPos = _startPos + Random.insideUnitCircle * 1.5f;
            _waitTimer = 0f; 
        }
    }

    private void ChangePoint()
    {
        _startPos = transform.position;
        _controlPos = _endPos;
        _endPos = _player.transform.position;
    }

    private Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        return Mathf.Pow(1 - t, 2) * p0 +
               2 * (1 - t) * t * p1 +
               Mathf.Pow(t, 2) * p2;
    }
}
