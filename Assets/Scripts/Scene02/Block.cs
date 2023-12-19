using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject upBlock;
    public GameObject downBlock;
    private AudioSource audioSource;
    public AudioClip tingSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var blockPosition = transform.position;
        transform.position = new Vector2(transform.position.x, Random.Range(-1, 1));
        upBlock.transform.position = new Vector2(upBlock.transform.position.x, Random.Range(4, 6));
        downBlock.transform.position = new Vector2(downBlock.transform.position.x, Random.Range(-4, -6));
        audioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            ScoreManager.Instance.IncreaseScore();
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(tingSound);
            Debug.Log(gameObject.name);
        }
    }
}
