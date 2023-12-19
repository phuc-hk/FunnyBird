using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public int waveNumber = 1;
    public TextMeshProUGUI waveText;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            // Generate a random position within a circle
            Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;

            // Instantiate the enemy at the random position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        waveText.text = waveNumber.ToString();

        // Increase the wave number for the next wave
        waveNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        // If there are no enemies left, spawn the next wave
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnWave();
        }
    }
}
