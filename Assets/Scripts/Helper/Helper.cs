using System.Collections;
using UnityEngine;

    public static class Helper
    {
        public static Enemy FindClosestEnemy(EnemySpawner spawner, Transform source)
        {
            Enemy closestEnemy = null;

            float minDistance = float.MaxValue;

            foreach (var enemy in spawner.SpawnedEnemies)
            {
                float distance = (enemy.transform.position - source.position).magnitude;
                if (distance < minDistance)
                {
                    closestEnemy = enemy;
                    minDistance = distance;
                }
            }
            return closestEnemy;
        }
    }