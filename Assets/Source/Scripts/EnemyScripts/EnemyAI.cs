using EvolveGames;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemy;
    private GameObject _player;
    public int HealthEnemy = 100;
    private void Start() => _player = FindObjectOfType<PlayerController>().gameObject;
    private void Update()
    {
        if (HealthEnemy <= 0)
        {
            HealthEnemy = 100;
            gameObject.SetActive(false);          
            return;
        }
       _enemy.SetDestination(_player.transform.position);
    }
}
