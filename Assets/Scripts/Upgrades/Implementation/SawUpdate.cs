using UnityEngine;

public class SawUpdate : Upgrade
{
    [SerializeField] private Saw _sowPrefab;

    public override void Apply(PlayerController player)
    {
        var saw = Instantiate(_sowPrefab, player.transform.position, Quaternion.identity);
        saw.transform.SetParent(player.transform, true);
    }
}
