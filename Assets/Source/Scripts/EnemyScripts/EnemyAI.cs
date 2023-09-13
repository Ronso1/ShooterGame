using EvolveGames;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemy;
    private GameObject _player;
    public int HealthEnemy = 100;
    private void Awake()
    {
        _enemy.updateRotation = false;
    }
    private void Start() => _player = FindObjectOfType<PlayerController>().gameObject;
    private void Update()
    {
        if (HealthEnemy <= 0)
        {
            HealthEnemy = 100;
            gameObject.SetActive(false);
            return;
        }

        /*var targetPosition = _enemy.pathEndPosition;
        var targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        var _direction = (targetPoint - transform.position).normalized;
        var _lookRotation = Quaternion.LookRotation(_direction*);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), 180);*/
        _enemy.SetDestination(_player.transform.position);
    }
}
