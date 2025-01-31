using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootDelay;

    public Transform _target;

    private void Start()
    {
        StartCoroutine(ShootingCoroutine());
    }

    private IEnumerator ShootingCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_shootDelay);

            if (_target != null)
            {
                Vector3 shootDirection = (_target.position - transform.position).normalized;
                GameObject newBullet = Instantiate(_bulletPrefab, transform.position + shootDirection, Quaternion.identity);
                Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = shootDirection * _bulletSpeed;
            }
        }
    }
}

