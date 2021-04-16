using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    //// Weapon Specifications
    // Attack warm up speed
    [SerializeField]
    [Tooltip("Attack warm up time in milliseconds before each attack")]
    private int attackSpeed = 500; // milliseconds attack warmup speed

    // Attack range
    [SerializeField]
    [Tooltip("Attack range in meters")]
    private int attackRange = 5; // meters attack range

    // Projectile Type
    [SerializeField]
    [Tooltip("Projectile prefab to be spawned with each attack")]
    private Bullet bulletPrefab;

    void Start() {
        
    }

    void Update() {
        
    }


}
