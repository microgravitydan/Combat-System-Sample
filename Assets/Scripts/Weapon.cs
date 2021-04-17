// Weapon.cs
// This script provides weapon specifications that can be called from parent character, and a Fire Weapon script that can be called.
// Must be attached to a weapon GameObject with: muzzle transform.
// Must set: weaponBullet, weaponMuzzle
// Should set: weaponSpeed, weaponRange, 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    //// Weapon Specifications
    // Attack warm up speed
    // Should be set in inspector
    [SerializeField]
    [Tooltip("Attack warm up time in seconds before each attack")]
    public float weaponSpeed = 0.5f; // Seconds attack warmup speed

    // Attack range
    // Should be set in inspector
    [SerializeField]
    [Tooltip("Attack range in meters")]
    public int weaponRange = 5; // meters attack range

    // Projectile Type
    // Must be prefab. Should be Bullet. Must be assigned in inspector
    [SerializeField]
    [Tooltip("Projectile prefab to be spawned with each attack")]
    private Bullet weaponBullet;

    // Muzzle Transform
    // Must be transform. Must be assigned in inspector.
    // Projectiles are instantiated at this location
    [SerializeField]
    [Tooltip("Location on weapon to spawn projectiles")]
    private Transform weaponMuzzle;

    // Fire Weapon is called from the character that is holding it once it has determined it is ready to fire.
    public void FireWeapon() {
        if (weaponBullet == null) {
            Debug.LogError("Weapon does not have bullet assigned.");
        } else if (weaponMuzzle == null) {
            Debug.LogError("Weapon does not have muzzle assigned.");
        } else {
            // Instantiate bullet at muzzle, then release from parent.
            Bullet projectile = Instantiate(weaponBullet) as Bullet;
            projectile.transform.SetParent (weaponMuzzle);
            projectile.transform.position = weaponMuzzle.transform.position;
            projectile.transform.rotation = weaponMuzzle.transform.rotation;
            projectile.transform.SetParent (null);
        }
    }
}
