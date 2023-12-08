using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGameController : MonoBehaviour
{
    public GameObject blockPrefab;
    private bool startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            InvokeRepeating(nameof(SpawnBlock), 1, 2);
            startGame = false;
        }
    }

    void SpawnBlock()
    {
        var block = Instantiate(blockPrefab, transform.position, Quaternion.identity);
        Destroy(block, 5);
    }
}
