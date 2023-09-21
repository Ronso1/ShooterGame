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
    private int _enemyHealth;

    private void Update()
    {
        
    }


}
