using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGameController : MonoBehaviour
{
    public GameObject blockPrefab;
    
    //private bool startGame;
    // Start is called before the first frame update
    void Start()
    {
        //startGame = true;
        StartCoroutine(SpawnBlock());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (startGame)
    //    {
    //        InvokeRepeating(nameof(SpawnBlock), 1, 2);
    //        startGame = false;
    //    }
    //}

    IEnumerator SpawnBlock()
    {
        while (true)
        {
            var block = Instantiate(blockPrefab, transform.position, Quaternion.identity);
            Destroy(block, 5);
            float randomSecond = Random.Range(2, 5);
            yield return new WaitForSeconds(randomSecond);
        }
    }    

    //void SpawnBlock()
    //{
    //    var block = Instantiate(blockPrefab, transform.position, Quaternion.identity);
    //    Destroy(block, 5);
    //}
}
