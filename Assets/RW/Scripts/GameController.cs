using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    public GameObject sheepPrefab;
    public GameObject fastSheepPrefab;
    
    public Transform[] spawnPoints;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
    // Chance of spawning a fast sheep (0.0 to 1.0)
    public float fastSheepChance = 0.3f;
    
    void Start()
    {
        StartCoroutine(SpawnSheep());
        UpdateScoreDisplay();
    }
    
    IEnumerator SpawnSheep()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
            
            // Choose a random spawn point
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            
            // Decide whether to spawn a regular or fast sheep
            bool spawnFastSheep = Random.value < fastSheepChance;
            GameObject prefabToSpawn = spawnFastSheep ? fastSheepPrefab : sheepPrefab;
            
            // Spawn the sheep
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }
    
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
} 