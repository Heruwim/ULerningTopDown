using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] protected float _moveSpeed = 1f;

    public float Health { get; private set; }

    public bool IsDead => Health <= 0;

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, _maxHealth);
        print("health changed: " + damage + " health: " +  Health + ", " + name);

        if (IsDead )
        {
            gameObject.SetActive(false);
            OnDead();
        }
    }

    protected virtual void OnDead()
    {

    }
}
