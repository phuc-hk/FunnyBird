using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject upBlock;
    public GameObject downBlock;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var blockPosition = transform.position;
        transform.position = new Vector2(transform.position.x, Random.Range(-3, 6));
        upBlock.transform.position = new Vector2(upBlock.transform.position.x, Random.Range(8, 12));
        downBlock.transform.position = new Vector2(downBlock.transform.position.x, Random.Range(-4, -8));
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, 0);
    }
}
