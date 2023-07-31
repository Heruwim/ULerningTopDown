using UnityEngine;

public class Rocket : Damager
{
    [SerializeField] private float _aoeRadius;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Launch(Vector3 force)
    {
        _rigidbody.AddForce(force);
        transform.up = force;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, _aoeRadius);
        bool anyDamaged = false;
        foreach (var target in targets)
        {
            anyDamaged = TryDoDamage(target);
        }

        if (anyDamaged && _destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
