using UnityEngine;

public class Enemy : Character 
{
    [SerializeField] private ExperiencePickup _experiencePickup;

    protected Transform _target;

    protected virtual void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform;
    }

    protected virtual void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }

    protected override void OnDead()
    {
        Instantiate(_experiencePickup, transform.position, Quaternion.identity);
    }
}
