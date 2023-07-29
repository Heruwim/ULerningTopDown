using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    [SerializeField] float _collisionOffset = 0.05f;
    [SerializeField] float _shootInterval;
    [SerializeField] float _shootSpeed;
    [SerializeField] ContactFilter2D _movementFilter;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] EnemySpawner _enemySpawner;
    [SerializeField] int[] _experiencesLevels;
    [SerializeField] UpgradesManaeger _upgradesManaeger;
 
    private Vector2 _movementInput;
    private Rigidbody2D _playerRigidbody;
    private List<RaycastHit2D> _castCollision = new List<RaycastHit2D>();
    private float _shootTimer;
    private int _currentLevel;
    private int _experience;


    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_movementInput != Vector2.zero)
        {
            bool success = TryMove(_movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(_movementInput.x, 0));

                if (!success) 
                    success = TryMove(new Vector2(0, _movementInput.y));
            }
        }
        Shoot();
    }

    private bool TryMove(Vector2 direction)
    {
        int count = _playerRigidbody.Cast(
                direction,
                _movementFilter,
                _castCollision,
                _moveSpeed * Time.fixedDeltaTime + _collisionOffset);

        if (count == 0)
        {
            _playerRigidbody.MovePosition(_playerRigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
            return false;
    }

    private void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    private void Shoot()
    {
        _shootTimer += Time.fixedDeltaTime;
        if (_shootTimer >= _shootInterval)
        {
            _shootTimer = 0;

            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
            Enemy closest = FindClosestEnemy();
            if (closest != null)
            {
            Vector3 direction = (closest.transform.position - transform.position).normalized;
            bulletRigidbody2D.AddForce(direction * _shootSpeed);
            }
        }
    }

    private Enemy FindClosestEnemy()
    {
        Enemy closestEnemy = null;

        float minDistance = float.MaxValue;

        foreach(var enemy in _enemySpawner.SpawnedEnemys)
        {                       
            float distance = (enemy.transform.position - transform.position).magnitude;
            if (distance < minDistance)
            {
                closestEnemy = enemy;
                minDistance = distance;
            }
        }
        return closestEnemy;
    }

    public void AddExperience(int value)
    {
        _experience += value;
        var newLevel = Array.FindLastIndex(_experiencesLevels, e => _experience >= e);
        Debug.Log("Level: " + _currentLevel + ", Exp: " + _experience);

        if(newLevel >= _currentLevel)
        {
            _upgradesManaeger.Suggest();
            _currentLevel = newLevel;
        }
    }

    [ContextMenu("AddExperience")]

    private void AddExperience()
    {
        AddExperience(5);
    }

    [ContextMenu("ResetExperience")]
    private void ResetExperience()
    {
        _currentLevel = _experience = 0;
    }
}
