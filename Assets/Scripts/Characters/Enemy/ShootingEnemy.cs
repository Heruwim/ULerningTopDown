using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] float _shootInterval;
    [SerializeField] float _shootSpeed;

    [SerializeField] GameObject _bulletPrefab;

    private float _shootTimer;

    protected override void Update()
    {
        base.Update();
        Shoot();
    }

    private void Shoot()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _shootInterval)
        {
            _shootTimer = 0;

            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
            Vector3 direction = (_target.position - transform.position).normalized;
            bulletRigidbody2D.AddForce(direction * _shootSpeed);
        }
    }
}
