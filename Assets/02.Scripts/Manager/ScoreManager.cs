using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}

    [Header("Pop속성")]
    public float ScaleSize = 1.4f;
    public float ScaleTime = 0.2f;
    // 응집도를 높여라
    // 응집도 : '데이터'와 '데이터를 조작하는 로직'이 얼마나 잘 모여있나
    // 응집도를 높이고, 필요한 것만 외부에 공개하는 것을 '캡슐화'
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _highScoreTextUI;
    private int _currentScore = 0;
    private int _highScore = 0;

    private const string ScoreKey = "Score";

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
    }
    private void UpdateHighScore()
    {
        if (_currentScore > _highScore)
        {
            PopText(_highScoreTextUI);
            _highScore = _currentScore;
        }
    }
    private void PopText(Text textUI)
    {
        // 처음 크기(1)으로 돌려놓고
        textUI.transform.localScale = Vector3.one;

        // 커졌다가 다시 돌아오는 시퀀스
        textUI.transform
            .DOScale(ScaleSize, ScaleTime)      
            .SetEase(Ease.OutBack)              
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
        if (_currentScore >= _highScore)
        {
            PlayerPrefs.SetInt(ScoreKey, _currentScore);
        }     
    }

    private void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        _highScore = 0;
        Refresh();           
    }

    private void Load()
    {
        _highScore = PlayerPrefs.GetInt(ScoreKey, 0);
    }
}
