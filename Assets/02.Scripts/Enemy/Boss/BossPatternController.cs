using System.Collections.Generic;
using UnityEngine;

public class BossPatternController : MonoBehaviour
{
    public Transform FirePoint;
    
    private int _index = 0;
    private List<IBossPattern> _bossPatterns = new List<IBossPattern>();
    private IBossPattern _currentPattern;
    
    [Header("반복 설정")]
    private float _fireTimer = 0f;
    private float _patternTimer = 0f;
    private float _restTimer = 0f;
    private enum State {Pattern, Rest}
    private State _state = State.Pattern;
    
    private void Awake()
    {
        _bossPatterns.Add(new StraightPattern());
        _bossPatterns.Add(new WavePattern());
        _bossPatterns.Add(new CirclePattern());
    }
    private void Start()
    {
        _currentPattern = _bossPatterns[_index];
        EnterPatternState();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Pattern:
                RunPatternState();
                break;
            case State.Rest:
                RunRestState();
                break;
        }
    }

    private void RunPatternState()
    {
        _patternTimer += Time.deltaTime;

        // 발사 간격 체크
        _fireTimer += Time.deltaTime;
        if (_fireTimer >= _currentPattern.FireInterval)
        {
            _currentPattern.Execute(FirePoint);
            _fireTimer = 0f;
        }

        // 패턴 지속 시간 종료 → 휴식으로
        if (_patternTimer >= _currentPattern.PatternDuration)
        {
            EnterRestState();
        }
    }

    private void RunRestState()
    {
        _restTimer += Time.deltaTime;

        if (_restTimer >= _currentPattern.RestTime)
        {
            NextPattern();
            EnterPatternState();
        }
    }

    private void EnterPatternState()
    {
        _state = State.Pattern;
        _patternTimer = 0f;
        _fireTimer = 0f;
    }

    private void EnterRestState()
    {
        _state = State.Rest;
        _restTimer = 0f;
    }

    private void NextPattern()
    {
        _index++;
        if (_index >= _bossPatterns.Count)
            _index = 0;

        _currentPattern = _bossPatterns[_index];
    }
}
