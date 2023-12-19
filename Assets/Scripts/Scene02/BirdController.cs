using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GamePanel gamePanel;
    Rigidbody2D rb;
    //[SerializeField] float speed;
    private Vector2 originPos;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originPos = transform.position;
        UIManager.Instance.OnRestart.AddListener(ReturnOrigin);
    }

    void Update()
    {
        
    }

   public void FixedUpdate()
   {
        rb.velocity = new Vector2(0, gamePanel.speed);
   }

    public void ReturnOrigin()
    {
        transform.position = originPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            UIManager.Instance.EndPanel();
        }
    }
}
