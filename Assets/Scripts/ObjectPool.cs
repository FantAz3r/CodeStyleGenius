using UnityEngine;
using UnityEngine.Pool;

public class BulletPool
{
    private ObjectPool<Bullet> _pool;

    public BulletPool(Bullet prefab, int poolCapacity, int poolMaxSize)
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: () => Object.Instantiate(prefab),
            actionOnGet: (unit) => ActionOnGet(unit),
            actionOnRelease: (unit) => ActionOnRelease(unit),
            actionOnDestroy: (unit) => Object.Destroy(unit),
            collectionCheck: true,
            defaultCapacity: poolCapacity,
            maxSize: poolMaxSize);
    }

    public Bullet GetBullet()
    {
        return _pool.Get();
    }

    public void ReleaseBullet(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    private void ActionOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector3.zero;
    }
}
