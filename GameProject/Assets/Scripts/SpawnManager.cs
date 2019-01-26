using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy Watcher;
    public Enemy DeceasedPhantom;
    public Enemy Oriax;
    public List<Spawner> spawners = new List<Spawner>();

    float timeToSpawn;
    float hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention = Random.Range(0f, 3f);
        timeToSpawn = 5F + hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention;

        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        int spawnerId = (int)Random.Range(0f, (float)spawners.Count);

        Spawner selectedSpawner = spawners[spawnerId];
        GameObject target = selectedSpawner.target;

        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            gameState.spawnCount++;

            if (gameState.spawnCount >= 50)
            {
                selectedSpawner.SpawnEnemy(Oriax, 0.04f, 1000);
            } else
            {
                float randomSpawnChance = Random.Range(0f, 1f);
                if (randomSpawnChance < 0.80)
                {
                    selectedSpawner.SpawnEnemy(Watcher, 0.1f, 100);
                }
                else
                {
                    selectedSpawner.SpawnEnemy(DeceasedPhantom, 0.08f, 500);
                }
            }

            timeToSpawn = 3f;
        }
    }
}
