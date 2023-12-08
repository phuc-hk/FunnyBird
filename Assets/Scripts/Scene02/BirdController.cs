using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GamePanel gamePanel;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

   public void FixedUpdate()
   {
        rb.velocity = new Vector2(0, gamePanel.speed);
   }
   
}
