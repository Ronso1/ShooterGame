using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLife = 3;
    public Spawner countList;

    private void Awake()
    {
        Destroy(gameObject, _bulletLife);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //countList.enemyList.Remove(other.gameObject);
            Destroy(other.gameObject);           
        }
        Destroy(gameObject);
    }

}