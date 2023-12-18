using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public TextMeshProUGUI score;
    public float point = 0;
    AudioSource audioSource;
    [SerializeField] AudioClip santaLaugh;
    void Start()
    {
        score.text = point.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            InscreasePoint();
            //if (!audioSource.isPlaying)
            //{
            audioSource.PlayOneShot(santaLaugh);
            //}
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
