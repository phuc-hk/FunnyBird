using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public GameObject bulletPrefab;
    public Transform firingPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.joystickVec != Vector2.zero)
        {
            // Calculate the angle in degrees
            float angle = Mathf.Atan2(joystick.joystickVec.y, joystick.joystickVec.x) * Mathf.Rad2Deg;
            // Set the rotation of the player
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }

    private void FixedUpdate()
    {
        if (joystick.joystickVec != Vector2.zero)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void FireBullet()
    {
        // Instantiate the bullet
        Instantiate(bulletPrefab, firingPos.position, transform.rotation);
        //Debug.Log("Firing");
    }
}
