using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    public float speed = 2;
    private Animator animator; // Add this line
    private bool facingRight = true;
    private float beginTransformx;
    private bool isWalking = false;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Add this line
        beginTransformx = transform.localScale.x;
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

            Vector2 direction = (Vector2)position - (Vector2)transform.position;
            if (direction.x >= 0.01f)
            {
                facingRight = true;
                //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                //animator.SetTrigger("walk");
            }
            else if (direction.x <= -0.01f)
            {
                facingRight = false;
                //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                //animator.SetTrigger("walk");
            }
            //else
            //{
            //    animator.SetTrigger("idle");
            //}
            if (!isWalking)
            {
                isWalking = true;
                animator.SetTrigger("walk");
            }    
                
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        else
        {
            isWalking = false;
            animator.SetTrigger("idle");
        }
        Turn();
    }

    private void Turn()
    {
        if (facingRight)
          transform.localScale = new Vector3(beginTransformx, transform.localScale.y, transform.localScale.z);
        else
          transform.localScale = new Vector3(-beginTransformx, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            animator.SetTrigger("death");
        }
    }
}
