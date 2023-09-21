using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private TMP_Text _healthEnemyTopPrint;
    [SerializeField] private int _damage = 15;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private List<GameObject> _weaponsList;
    private bool _isShoot = true;
    private float _timeDelay;
    private int _enemyHealth;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _isShoot)
        {
            GetTimeDelayAndDamage();
            print(_timeDelay);
            StartCoroutine(ShootByRayCast());
        }

    }

    private IEnumerator ShootByRayCast()
    {
        _isShoot = false;
        var timeForWait = new WaitForSeconds(_timeDelay);
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
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

    private void GetTimeDelayAndDamage()
    {
        string gunName = null;
        foreach (var weapon in _weaponsList)
        {
            if (weapon.activeSelf) gunName = weapon.name;
        }

        if (gunName == "FullPistol") SetDamageAndTImeDelay(0.3f, 20);
        if (gunName == "AssaultRifle") SetDamageAndTImeDelay(0.1f, 30);
       
    }

    private void SetDamageAndTImeDelay(float timeDelay, int damage)
    {
        _timeDelay = timeDelay;
        _damage = damage;
    }

}
