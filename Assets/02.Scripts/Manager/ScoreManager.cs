using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}

    [Header("Pop속성")]
    public float ScaleSize = 1.4f;
    public float ScaleTime = 0.2f;
    [Header("UI")]
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _highScoreTextUI;
    private int _currentScore = 0;
    private int _highScore = 0;
    private const string ScoreKey = "Score";

    public static event Action<int> OnScoreChanged;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Load();

        Refresh();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ResetHighScore();
        }
    }

    // 하나의 메서드는 한 가지 일만 잘 하면된다 -> AddScore는 점수 올리기만. 나머지는 다른 함수로
    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;
        UpdateHighScore();
        PopText(_currentScoreTextUI);
        Refresh();
        
        OnScoreChanged?.Invoke(_currentScore);
    }
    private void UpdateHighScore()
    {
        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            UserDataManager.Data.Score = _highScore;
            PopText(_highScoreTextUI);
        }
    }
    private void PopText(Text textUI)
    {
        textUI.transform.localScale = Vector3.one;

        textUI.transform.DOScale(ScaleSize, ScaleTime).SetEase(Ease.OutBack)              
            .OnComplete(() =>                   
            {
                textUI.transform.DOScale(1.0f, 0.2f)
                    .SetEase(Ease.InOutBack);   
            });
    }

    private void Refresh()
    {
        _highScoreTextUI.text = $"최고 점수: {_highScore:N0}";
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
    }

   
    private void Save()
    {
        UserDataManager.Save();
    }

    private void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        _highScore = 0;
        Refresh();           
    }

    private void Load()
    {
        UserDataManager.Load();
        _highScore = UserDataManager.Data.Score;
    }
}
