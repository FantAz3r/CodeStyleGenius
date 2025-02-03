using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab; 
    [SerializeField] private float _shootDelay;

    private WaitForSeconds _wait;
    public Transform target;

    private void Awake()
    {
        _wait = new WaitForSeconds(_shootDelay);
    }

    void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        while (enabled)
        {
            yield return _wait;

            Vector3 shootDirection = (target.position - transform.position).normalized;
            Bullet bullet = Instantiate(bulletPrefab, transform.position + shootDirection, Quaternion.identity);
            bullet.Move(shootDirection);
        }
    }
}

