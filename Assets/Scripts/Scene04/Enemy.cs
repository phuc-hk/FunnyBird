using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        //health = 3;
        // Find the player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) Destroy(gameObject);
        // Calculate the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the enemy
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
