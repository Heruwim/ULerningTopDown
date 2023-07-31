using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] protected bool _destroyOnHit;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryDoDamage(collision) && _destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    protected bool TryDoDamage(Collider2D collision)
    {
        bool hasHealht = collision.TryGetComponent<Character>(out var character);
        bool otherHealth = !collision.CompareTag(tag);
        if (hasHealht && otherHealth)
        {
            character.TakeDamage(_damage);
            return true;
        }

        return false;
    }
}
