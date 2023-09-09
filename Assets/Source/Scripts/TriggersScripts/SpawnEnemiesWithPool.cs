using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesWithPool : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private EnemyAI _enemy;
    [SerializeField] private Transform[] _spawnPoints;

    private Coroutine _spawning;
    private PoolSpawner<EnemyAI> _pool;

    private void Awake()
    {
        StartSpawn();
    }
    private void StartSpawn()
    {
        _pool = new PoolSpawner<EnemyAI>(_enemy, transform, 15);
        _spawning = StartCoroutine(Spawning());
    }

    private void Spawn()
    {
        EnemyAI enemy = _pool.GetFreeElement();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
    }


    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            Spawn();
        }
    }
}
