using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private GameObject _gameOverPanel;


    private void Update()
    {
        if (_playerController.IsDead)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.enabled = false;
            }

            _gameOverPanel.SetActive(true);
        }
    }
}
