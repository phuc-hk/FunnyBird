using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GroundDetect scoreManager;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI score;
    //[SerializeField] ScoreManager ScoreManager;
    public UnityEvent OnRestart;

    public static UIManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        if (gameController!=null)
            gameController.playing = true;
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
        score.text = scoreManager.point.ToString();
    }

    public void EndPanel()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
        score.text = ScoreManager.Instance.point.ToString();
        //ScoreManager.Instance.IncreaseScore();
    }

    public void RestartGame()
    { 
        scoreManager.SetPoint(0);
        endPanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        endPanel.SetActive(false);
        OnRestart?.Invoke();
    }
}
