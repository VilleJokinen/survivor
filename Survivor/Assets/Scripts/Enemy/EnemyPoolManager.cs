using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{

    public static EnemyPoolManager Instance;

    public GameObject enemyPrefab;
    public int poolSize = 20;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.SetActive(false);
            enemyPool.Enqueue(newEnemy);
        }

    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject newBullet = Instantiate(enemyPrefab);
            newBullet.SetActive(true);
            return newBullet;
        }

    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
