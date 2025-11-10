using UnityEngine;

public class PlayerManualMove : MonoBehaviour
{
    private PlayerMove _move;
    private bool _isBoosting = false;
    private Vector2 _direction;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
    }

    public void HandleManualMove()
    {
        HandleSpeedInput();
        MoveByInput();
    }

    private void HandleSpeedInput()
    {
        // 속도 증가/감소
        if (Input.GetKeyDown(KeyCode.Q))
            _move.ChangeSpeedUp(true);
        else if (Input.GetKeyDown(KeyCode.E))
            _move.ChangeSpeedUp(false);

        // Shift 부스트
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isBoosting)
        {
            _isBoosting = true;
            _move.BoostSpeed(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && _isBoosting)
        {
            _isBoosting = false;
            _move.BoostSpeed(false);
        }
    }

    private void MoveByInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(h, v).normalized;
        ReturnToOrigin();
        _move.MovePlayer(_direction);
    }

    private void ReturnToOrigin()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _move.TurnOnMovingOrigin(true);
        }
        else
        {
            _move.TurnOnMovingOrigin(false);
        }
    }
}
