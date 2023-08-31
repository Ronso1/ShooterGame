using UnityEngine;
using TMPro;
public class RaycastShoot : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private TMP_Text _healthEnemyTopPrint;
    private int enemyHealth;
    private void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Mouse0)) ShootByRayCast();
    }
    private void ShootByRayCast()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy -= 20;
                enemyHealth = hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy;
                _healthEnemyTopPrint.gameObject.SetActive(true);
                _healthEnemyTopPrint.text = $"Enemy health: {enemyHealth}";
                if (enemyHealth == 0) _healthEnemyTopPrint.gameObject.SetActive(false);
                print($"Health enemy: {enemyHealth}");
            }
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 15f, Gizmos.color = Color.green);
    }
#endif 
}