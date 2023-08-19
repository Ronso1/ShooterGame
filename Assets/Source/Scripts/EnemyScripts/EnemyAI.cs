using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private NavMeshAgent _enemy;
    private void Start() => _enemy = GetComponent<NavMeshAgent>();
    private void Update() => _enemy.SetDestination(_player.transform.position);
}
