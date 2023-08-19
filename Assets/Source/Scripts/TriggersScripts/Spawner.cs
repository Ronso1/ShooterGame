using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _maxEnemy;
    [SerializeField] private float _timeSpawn = 2f;
    public List<GameObject> enemyList;
    private float _timer;
    private void Start() => _timer = Time.time;
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _timeSpawn;
            if (enemyList.Count < _maxEnemy)
            {
                Instantiate(_enemyPrefab, transform.position, transform.rotation);
                enemyList.Add(_enemyPrefab);
            }
        }
    }
}
