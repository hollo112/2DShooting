using System.Collections;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
    [Header("기본 설정")]
    public float Duration = 0.5f;          // 흔들리는 시간
    public float Magnitude = 0.2f;         // 흔들림 세기
    public AnimationCurve ShakeCurve = AnimationCurve.Linear(0, 1, 1, 0); 
    private Camera _mainCamera;

    private Vector3 _originalPos = new Vector3(0, 0, -10);
    private Coroutine _shakeRoutine;

    private void Start()
    {
        _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Shake();
    }
    public void Shake()
    {
        if (_shakeRoutine != null)
        {
            StopCoroutine(_shakeRoutine);
            _mainCamera.transform.localPosition = _originalPos;
        }
        _shakeRoutine = StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        float elapsed = 0f;

        while (elapsed < Duration)
        {
            elapsed += Time.deltaTime;
            float strength = ShakeCurve.Evaluate(elapsed / Duration); // 시간 비율에 따라 세기 줄이기
            float offsetX = Random.Range(-1f, 1f) * Magnitude * strength;
            float offsetY = Random.Range(-1f, 1f) * Magnitude * strength;

            _mainCamera.transform.localPosition = _originalPos + new Vector3(offsetX, offsetY, 0);
            yield return null;
        }

        _mainCamera.transform.localPosition = _originalPos;
    }
}
