using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] private UpgradeUI _upgradeUIPrefab;
    [SerializeField] private UpgradesManaeger _upgradesManager;
    
    public void Show(List<Upgrade> upgrades, PlayerController player)
    {
        gameObject.SetActive(true);

        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var upgrade in upgrades)
        {
            var ui = Instantiate(_upgradeUIPrefab, transform);
            ui.Setup(upgrade.Title, upgrade.Icon, () => OnClickApply(upgrade, player));
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void OnClickApply(Upgrade upgrade, PlayerController player)
    {
        upgrade.Apply(player);
        _upgradesManager.OnUpggradeApplied(upgrade);
    }
}
