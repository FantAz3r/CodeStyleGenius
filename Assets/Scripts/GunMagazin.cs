using System.Collections;
using UnityEngine;

public class GunMagazin : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _gunMagazin;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _poolMaxSize = 30;

    private BulletPool _bulletPool;
    private Transform[] _bullets;

    private void Awake()
    {
        _bullets = new Transform[_gunMagazin.childCount];

        for (int i = 0; i < _gunMagazin.childCount; i++)
        {
            _bullets[i] = _gunMagazin.GetChild(i);
        }

        _bulletPool = new BulletPool(_bulletPrefab, _bullets.Length, _poolMaxSize);
    }

    void Start()
    {
        StartCoroutine(ShootingCoroutine());
    }

    private IEnumerator ShootingCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_fireRate);

            Bullet bullet = _bulletPool.GetBullet();
            bullet.Fire( );
        }
    }
}