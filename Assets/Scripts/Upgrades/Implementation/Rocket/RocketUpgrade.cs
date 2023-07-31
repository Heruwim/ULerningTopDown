using UnityEngine;

public class RocketUpgrade : Upgrade
{
    [SerializeField] RocketLauncher _launcherPrefab;
    
    public override void Apply( PlayerController player)
    {
        var launcher = Instantiate(_launcherPrefab, player.transform.position, Quaternion.identity);
        launcher.transform.SetParent(player.transform, true);
    }
}
