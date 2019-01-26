using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy Enemy;
    public List<Spawner> spawner = new List<Spawner>();

    float timeToSpawn;
    float hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention;

    // Start is called before the first frame update
    void Start()
    {
        hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention = Random.Range(0f, 3f);
        timeToSpawn = 5F + hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention;
    }

    // Update is called once per frame
    void Update()
    {
        Spawner selectedSpawner = spawner[0];
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            float scale = Mathf.Max(transform.localScale.x, transform.localScale.z);
            float ran = Random.Range(-1.0F, 1.0F);
            Vector3 pos = transform.position + ran * new Vector3(0, 0, scale * 5);
            Vector3 dir = -(pos + new Vector3(0, 1, 0)) + selectedSpawner.target.transform.position;
            Enemy enemy = Instantiate(Enemy, pos + new Vector3(0, 1, 0), Quaternion.LookRotation(dir, new Vector3(0, 1, 0)));
            enemy.target = selectedSpawner.target.transform.position;
            enemy.speed = 0.1F;
            enemy.health = 100;

            timeToSpawn = 5F + hardcodedRandomGeneratedFactorForSimultanousSpawnPrevention;
        }
    }
}
