using UnityEngine;

public class Gun : MonoBehaviour
{
    private enum GunType
    {
        Pistol, Revolver, CombatRifle, Shotgun, SubmachineGun, SniperRifle, RocketLauncher, GrenadeLauncher
    }

    [SerializeField]
    private string gunName;

    [SerializeField]
    private GunType type;

    [SerializeField]
    private int damage;

    [SerializeField]
    [Range(0, 100)]
    private float accuracy;

    [SerializeField]
    [Range(0.5F, 20)]
    private float fireRate;

    [SerializeField]
    [Range(0, 5)]
    private float reloadTime;
}
