using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _center;

    [Serializable]
    class Wawe
    {
        public float SpawnTime;
        public Enemy EnemyPrefab;
        public int CountMin, CountMax;
    }

    [SerializeField] private Wawe[] _wawes;

    private int _waveIndex;
    
    private Wawe CurrentWawe => _wawes[_waveIndex];
    private bool HasWaves => _waveIndex < _wawes.Length;

    public List<Enemy> SpawnedEnemies { get; } = new List<Enemy>();

    private void Update()
    {
        if(HasWaves && Time.timeSinceLevelLoad > CurrentWawe.SpawnTime)
        {
            Spawn();
            _waveIndex++;
        }
    }

    private void Spawn()
    {
        int count = UnityEngine.Random.Range(CurrentWawe.CountMin, CurrentWawe.CountMax + 1);
        for (int i = 0; i < count; i++)
        {
            var position = _center.position + (Vector3) UnityEngine.Random.insideUnitCircle * _spawnRadius;
            var enemy = Instantiate(CurrentWawe.EnemyPrefab, position, Quaternion.identity);
            SpawnedEnemies.Add(enemy);
        }
    }

    public void OnEnemyDead(Enemy enemy)
    {
        SpawnedEnemies.Remove(enemy);
    }
}
