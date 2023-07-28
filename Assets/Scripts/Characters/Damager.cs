using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _destroyOnHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasHealht = collision.TryGetComponent<Character>(out var character);
        bool otherHealth = !collision.CompareTag(tag);
        if (hasHealht && otherHealth)
        {
            character.TakeDamage(_damage);
            if (_destroyOnHit )
            {
                Destroy(gameObject);
            }
        }
    }
}
