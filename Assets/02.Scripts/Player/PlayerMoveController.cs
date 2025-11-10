using UnityEngine;

public enum EControlMode
{
    Manual,
    Auto,
}

public class PlayerMoveController : MonoBehaviour
{
    private PlayerMove _move;
    private PlayerManualMove _manual;
    private PlayerAutoMove _auto;
    private EControlMode _mode = EControlMode.Manual;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _manual = GetComponent<PlayerManualMove>();
        _auto = GetComponent<PlayerAutoMove>();
    }

    void Update()
    {
        HandleModeSwitch();

        if (_mode == EControlMode.Manual)
            _manual.HandleManualMove();
        else if (_mode == EControlMode.Auto) 
            _auto.HandleAutoMove();
    }
    private void HandleModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _mode = EControlMode.Auto;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _mode = EControlMode.Manual;
    }
}
