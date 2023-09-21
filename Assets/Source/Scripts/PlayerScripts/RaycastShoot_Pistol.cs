using UnityEngine;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;

public class RaycastShoot_Pistol : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private TMP_Text _healthEnemyTopPrint;
    [SerializeField] private int _damage = 15;
    [SerializeField] private LayerMask _layerMask;
    private int enemyHealth;

    private void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Mouse0)) ShootByRayCast();
    }

    private void ShootByRayCast()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy -= _damage;
                enemyHealth = hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy;
                _healthEnemyTopPrint.gameObject.SetActive(true);
                _healthEnemyTopPrint.text = $"Enemy health: {enemyHealth}";
                if (enemyHealth == 0) _healthEnemyTopPrint.gameObject.SetActive(false);
                print($"Health enemy: {enemyHealth}");
            }
        }
    }
 
}