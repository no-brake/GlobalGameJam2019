using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
     
    public void SpawnEnemy(Enemy enemy, float speed, int health)
    {
        float ran = Random.Range(-1.0F, 1.0F);
        float scale = Mathf.Max(transform.localScale.x, transform.localScale.z);
        Vector3 pos = transform.position + ran * new Vector3(0, 0, scale * 5);
        Vector3 dir = -(pos + new Vector3(0, 1, 0)) + target.transform.position;

        Enemy spawnedEnemy = Instantiate(enemy, pos + new Vector3(0, 1, 0), Quaternion.LookRotation(dir, new Vector3(0, 1, 0)));
        spawnedEnemy.target = target.transform.position;
        spawnedEnemy.speed = speed;
        spawnedEnemy.health = health;
    }
}
