using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GroundDetect scoreManager;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI score;

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
    }

    public void StartGame()
    {
        gameController.playing = true;
        startPanel.gameObject.SetActive(false);
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

    public void RestartGame()
    {
        scoreManager.SetPoint(0);
        endPanel.SetActive(false);
    }
}
