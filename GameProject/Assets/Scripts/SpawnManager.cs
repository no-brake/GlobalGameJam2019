using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy Watcher;
    public Enemy DeceasedPhantom;
    public Enemy Oriax;
    public List<Spawner> spawners = new List<Spawner>();

    public float timeToSpawn;
    float currentTimeToSpawn;

    private GameState gameState;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();
        isRunning = true;
        this.currentTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning)
        {
            return;
        }
        int spawnerId = (int)Random.Range(0f, (float)spawners.Count);

        Spawner selectedSpawner = spawners[spawnerId];
        GameObject target = selectedSpawner.target;

        currentTimeToSpawn -= Time.deltaTime;
        if (currentTimeToSpawn <= 0)
        {
            gameState.spawnCount++;

            if (gameState.spawnCount >= 50)
            {
                selectedSpawner.SpawnEnemy(Oriax, 0.04f, 1000, 5f, 100f);
                isRunning = false;
            } else
            {
                float randomSpawnChance = Random.Range(0f, 1f);
                if (randomSpawnChance < 0.80)
                {
                    selectedSpawner.SpawnEnemy(Watcher, 0.1f, 100, 2f, 1f);
                }
                else
                {
                    selectedSpawner.SpawnEnemy(DeceasedPhantom, 0.08f, 500, 3f, 5f);
                }
            }

            currentTimeToSpawn = timeToSpawn + Random.Range(-1.5f, 1.5f);
        }
    }
}
