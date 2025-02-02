using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private Rigidbody _bulletRigidbody;
    private BulletPool _bulletPool;

    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        _bulletRigidbody.velocity = Vector3.forward * _bulletSpeed; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        _bulletPool.ReleaseBullet(this); 
    }
}