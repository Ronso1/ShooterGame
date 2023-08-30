using UnityEngine;
public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _shootForce, _spread;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
    private void Shoot()
    {
        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else targetPoint = ray.GetPoint(75);
        Vector3 dirWithoutSpread = targetPoint - _spawnBullet.position;
        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);
        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);
        GameObject currentBullet = Instantiate(_bullet, _spawnBullet.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * _shootForce, ForceMode.Impulse);
    }
}
