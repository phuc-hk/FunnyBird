using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snowball : MonoBehaviour
{
    private Animator animator; // Add this line
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("boom");
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Time.timeScale = 0;
            StartCoroutine(ReLoadScene());
        }

        Destroy(gameObject, 0.6f);
    }

    IEnumerator ReLoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Scene01");
    }
}
