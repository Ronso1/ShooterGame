using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _enemy;
    public int HealthEnemy = 100;
    private void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (HealthEnemy <= 0)
        {
            Destroy(gameObject);
            return;
        }
        _enemy.SetDestination(_player.transform.position);
    }
}
