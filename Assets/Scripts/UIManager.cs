using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // UserInterface
    [SerializeField] private TextMeshProUGUI CurrentScore;
    [SerializeField] private GameObject HighScore,HighscoreText,Score,ScoreText;
    // Panels
    [Header("GameOverPanel")]
    [SerializeField] private GameObject GameOverPanel,GamePanel;

    [SerializeField] private GameObject Restart;
    private int ScoreManager,BestScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        GamePanel.SetActive(true);
        BestScoreManager = PlayerPrefs.GetInt("best");
    }
    public void UpdateScore()
    {
        ScoreManager++;
        if (ScoreManager > BestScoreManager)
            PlayerPrefs.SetInt("best", ScoreManager);

        CurrentScore.text = ScoreManager.ToString();
    }
    public void OnGameOver()
    {
        Restart.transform.DOPunchScale(Vector3.one * 0.1f, 0.25f,5, 1).SetLoops(-1);
        GameOverPanel.SetActive(true);
        GamePanel.SetActive(false);

        var Best = HighScore.GetComponent<TextMeshProUGUI>();
        var bestScore = PlayerPrefs.GetInt("best");
        Best.text = bestScore.ToString();

        var Current = Score.GetComponent<TextMeshProUGUI>();
        var currentScore = ScoreManager;
        Current.text = currentScore.ToString();
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(0);
    }
}
