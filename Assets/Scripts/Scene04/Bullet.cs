using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Hit enemy");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
