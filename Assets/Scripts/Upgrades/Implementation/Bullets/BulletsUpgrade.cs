using UnityEngine;

public class BulletsUpgrade : Upgrade
{
    [SerializeField] private int _increment;
    public override void Apply(PlayerController player)
    {
        player.BulletCount += _increment;
    }
}
