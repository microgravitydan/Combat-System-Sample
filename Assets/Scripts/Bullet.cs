using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //// Projectile Specifications
    // Initial speed
    [SerializeField]
    [Tooltip("Speed of the Projectile at time of spawn in undetermined units")]
    private int projectileSpeed = 50; // Initial speed of projectile when it is spawned

    // Damage
    [SerializeField]
    [Tooltip("Amount of damage dealt to target")]
    private int projectileDamage = 30; // Damage dealt to health points

    // Range
    [SerializeField]
    [Tooltip("Range in meters")]
    private int attackRange = 100; // Meters range for projectile despawn. Prevents projectile from travelling forever if it fails to impact anything


    void Start() {
        
    }

    void Update() {
        
    }
}
