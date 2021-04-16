using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    //// Weapon Specifications
    // Attack warm up speed
    [SerializeField]
    [Tooltip("Attack warm up time in seconds before each attack")]
    public float weaponSpeed = 0.5f; // Seconds attack warmup speed

    // Attack range
    [SerializeField]
    [Tooltip("Attack range in meters")]
    public int weaponRange = 5; // meters attack range

    // Projectile Type
    [SerializeField]
    [Tooltip("Projectile prefab to be spawned with each attack")]
    private Bullet weaponBullet;

    void Start() {
        
    }

    void Update() {
        
    }

    public void FireWeapon() {
        Debug.Log("Weapon Bang!");
    }

}
