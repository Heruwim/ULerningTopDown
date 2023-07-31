using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] float _launchInterval;
    [SerializeField] Rocket _rocketPrefab;
    [SerializeField] float _launchSpeed;

    private float _launcherTimer;
    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void Update()
    {
        _launcherTimer += Time.deltaTime;
        if (_launcherTimer >= _launchInterval)
        {
            _launcherTimer = 0;

            Enemy closest = Helper.FindClosestEnemy(_enemySpawner, transform);
            if (closest != null)
            {
                Vector3 direction = (closest.transform.position - transform.position).normalized;
                Rocket rocket = Instantiate(_rocketPrefab, transform.position, Quaternion.identity);
                rocket.Launch(direction * _launchSpeed);
            }
        }
    }
}
