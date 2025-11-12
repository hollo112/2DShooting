using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 응집도를 높여라
    // 응집도 : '데이터'와 '데이터를 조작하는 로직'이 얼마나 잘 모여있나
    // 응집도를 높이고, 필요한 것만 외부에 공개하는 것을 '캡슐화'
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _higestScoreTextUI;
    private int _currentScore = 0;
    private int _higestScore = 0; 

    private const string ScoreKey = "Score";

    private void Start()
    {
        Load();

        Refresh();
    }

    // 하나의 메서드는 한 가지 일만 잘 하면된다 -> AddScore는 점수 올리기만. 나머지는 다른 함수로
    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        Refresh();

        Save();
    }

    private void Refresh()
    {
        _higestScoreTextUI.text = $"최고 점수: {_higestScore:N0}";
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
        }

    }
   
    private void Save()
    {
        if (_currentScore > _higestScore)
        {
            PlayerPrefs.SetInt(ScoreKey, _currentScore);
        }     
    }

    private void Load()
    {
        _higestScore = PlayerPrefs.GetInt(ScoreKey, 0);
    }
}
