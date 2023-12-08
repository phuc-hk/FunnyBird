using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    private float speed = 5;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the screen is touched
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            var position = Camera.main.ScreenToWorldPoint(touch.position);

            position.y = transform.position.y;
            position.z = 0f;

            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            //Time.timeScale = 0;
            SceneManager.LoadScene(0);        
        }
    }
}
