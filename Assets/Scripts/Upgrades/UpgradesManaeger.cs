using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradesManaeger : MonoBehaviour
{
    [SerializeField] private UpgradeUIManager _uiManager;
    [SerializeField] private Upgrade[] _upgrades;
    [SerializeField] private PlayerController _player;
    
    private List<Upgrade> _availableUpgrades;

    private void Awake()
    {
        _availableUpgrades = _upgrades.ToList();
    }

    public void Suggest()
    {
        if (_availableUpgrades.Count > 0)
        {
            Time.timeScale = 0f;
            _uiManager.Show(_availableUpgrades, _player);
        }
    }

    public void OnUpggradeApplied(Upgrade appliedUpgrade)
    {
        _uiManager.Hide();
        _availableUpgrades.Remove(appliedUpgrade);
        Time.timeScale = 1f;
    }
}
