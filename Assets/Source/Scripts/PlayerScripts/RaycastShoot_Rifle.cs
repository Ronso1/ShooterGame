using System.Collections;
using TMPro;
using UnityEngine;

public class RaycastShoot_Rifle : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private TMP_Text _healthEnemyTopPrint;
    [SerializeField] private int _damage = 25;
    private int _enemyHealth;
    private bool _isShoot = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _isShoot) ShootByRayCastRifle();
    }

    private IEnumerator ShootByRayCastRifle()
    {
        _isShoot = false;
        var timeForWait = new WaitForSeconds(0.5f);
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy -= _damage;
                _enemyHealth = hitInfo.collider.gameObject.GetComponent<EnemyAI>().HealthEnemy;
                _healthEnemyTopPrint.gameObject.SetActive(true);
                _healthEnemyTopPrint.text = $"Enemy health: {_enemyHealth}";
                if (_enemyHealth == 0) _healthEnemyTopPrint.gameObject.SetActive(false);
                print($"Health enemy: {_enemyHealth}");
            }
        }
        yield return timeForWait;
        _isShoot = true;
    }
}
