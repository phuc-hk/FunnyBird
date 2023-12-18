using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public TextMeshProUGUI score;
    public float point = 0;
    void Start()
    {
        score.text = point.ToString();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            InscreasePoint();
        }    
    }

    private void InscreasePoint()
    {
        point += 1;
        score.text = point.ToString();
    }

    public void SetPoint(int point)
    {
        this.point = point;
        score.text = point.ToString();
    }
}
