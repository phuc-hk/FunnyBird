using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int point;
    public TextMeshProUGUI scoreText;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        point = 0;
    }
    // Start is called before the first frame update
    public void IncreaseScore()
    {
        point += 1;
        scoreText.text = point.ToString();
    }

    public void ResetScore()
    {
        point = 0;
        scoreText.text = point.ToString();
    }
}
