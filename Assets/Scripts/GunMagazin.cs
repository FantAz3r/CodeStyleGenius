using UnityEngine;

public class GunMagazin : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _gunMagazin;

    private float _targetError = 0.1f;
    private Transform[] _bullets;
    private int _bulletIndex;

    void Start()
    {
        _bullets = new Transform[_gunMagazin.childCount];

        for (int i = 0; i < _gunMagazin.childCount; i++)
        {
            _bullets[i] = _gunMagazin.GetChild(i);
        }
    }

    void Update()
    {
        MoveTowardsCurrentPlace();
    }

    private void MoveTowardsCurrentPlace()
    {
        Transform targetPoint = _bullets[_bulletIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < _targetError)
        {
            NextBullet();
        }
    }

    private void NextBullet()
    {
        _bulletIndex++;

        if (_bulletIndex >= _bullets.Length)
        {
            _bulletIndex = 0;
        }

        Vector3 nextPointPosition = _bullets[_bulletIndex].position;
        transform.LookAt(nextPointPosition);
    }
}
