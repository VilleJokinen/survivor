using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnInterval = 2f;

    private float nextSpawnTime;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = EnemyPoolManager.Instance.GetEnemy();
        enemy.transform.position = transform.position;
    }
}
