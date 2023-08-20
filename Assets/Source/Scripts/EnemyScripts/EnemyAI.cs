using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _enemy;
    private void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() => _enemy.SetDestination(_player.transform.position);
}
