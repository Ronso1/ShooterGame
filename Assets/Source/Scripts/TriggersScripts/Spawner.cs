using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _maxEnemy;
    [SerializeField] private float _timeSpawn = 2f;
    [SerializeField] private float _timeSpawnDelay = 10f;
    private bool _isSpawning = true;
    private int _countEnemy = 0;
    private void Update()
    {
        if (_isSpawning) StartCoroutine(EnemySpawn());
    }
    private IEnumerator EnemySpawn()
    {
        var timeForWait = new WaitForSeconds(_timeSpawn);
        _isSpawning = false;
        Instantiate(_enemyPrefab, transform.position, transform.rotation);
        _countEnemy++;
        yield return timeForWait;
        if (_countEnemy == _maxEnemy)
            StartCoroutine(RestartSpawn());
        else
            _isSpawning = true;
    }

    private IEnumerator RestartSpawn()
    {
        var timeForWait = new WaitForSeconds(_timeSpawnDelay);
        _countEnemy = 0;
        yield return timeForWait;
        _isSpawning = true;
    }
}