using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] private UpgradeUI _upgradeUIPrefab;
    [SerializeField] private UpgradesManaeger _upgradesManager;
    
    public void Show(List<Upgrade> upgrades)
    {
        gameObject.SetActive(true);

        foreach (var upgrade in upgrades)
        {
            var ui = Instantiate(_upgradeUIPrefab);
            ui.Setup(upgrade.Title, upgrade.Icon, () => OnClickApply(upgrade));
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void OnClickApply(Upgrade upgrade)
    {
        upgrade.Apply();
        _upgradesManager.OnUpggradeApplied(upgrade);
    }
}
