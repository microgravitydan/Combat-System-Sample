// Bullet.cs
// This script controls a bullet after it has been instantiated. It moves forward until it contacts a collider, or a timer runs out. If collision is a Character, it calls a damage script with damage to be dealt.
// Must be attached to a bullet gameobject with: a collider
// Should set: projectileSpeed, projectileDamage, attackRange

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //// Projectile Specifications
    // Initial speed
    // Should be set in inspector
    [SerializeField]
    [Tooltip("Speed of the Projectile at time of spawn in undetermined units")]
    private int projectileSpeed = 10; // Initial speed of projectile when it is spawned

    // Damage
    // Should be set in inspector
    [SerializeField]
    [Tooltip("Amount of damage dealt to target")]
    private int projectileDamage = 30; // Damage dealt to health points

    // Range
    // Should be set in inspector
    [SerializeField]
    [Tooltip("Range in seconds")]
    private float attackRange = 2; // Seconds range for projectile despawn. Prevents projectile from travelling forever if it fails to impact anything

    private float attackRangeCurrent; // Current timer before despawn

    void Update() {
        // Move forward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);

        // Destroy self if attackRange timer runs out
        if (attackRangeCurrent >= attackRange) {
            Destroy(this.gameObject);
        }
        attackRangeCurrent += Time.deltaTime; // Advance attack range timer
    }

    // Called on collision with other collider
    void OnTriggerEnter(Collider collidedObject) {
        // If collided with Character, call damage script with damage amount.
        if (collidedObject.gameObject.CompareTag("Character")) {
            collidedObject.GetComponent<Character>().ReceiveDamage(projectileDamage);
        }

        // Destroy self on any collision
        Destroy(this.gameObject);
    }
}
