using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    //// Variables

    // Name
    [SerializeField]
    [Tooltip("Name of Character")]
    private string characterName; // Character Name

    // TODO: Nametag

    // Health
    [SerializeField]
    [Tooltip("Maximum Health Points")]
    private int healthPointsMax = 100; // Maximum Health

    [SerializeField]
    [Tooltip("Current Health Points")]
    public int healthPoints = 100; // Current Health

    [SerializeField]
    [Tooltip("The character is dead")]
    public bool dead = false;

    // Behavior Mode
    private bool combatStatus = false; // Behavior Mode
        // False: Out of combat. No target is available, move and search for a target.
        // True: In combat. Attack target with weapon as often as possible.

    // TODO: Angry face

    // Navigation
	UnityEngine.AI.NavMeshAgent navigationAgent; // Navigation Agent
    private Transform characterPosition; // Character Position



    void Start() {
        // Initialize Navigation
        navigationAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        characterPosition = GetComponent<Transform>();

        // TODO: Check for unique name
    }

    void Update() {
        // Check for death if health is 0 or lower.
        if (healthPoints < 1) {
            dead = true;
            // TODO: Look dead

        } else {
            // TODO: if combatStatus ...
            if (combatStatus) {
                InCombat();
            } else {
                OutOfCombat();
            }
        }
    }

    void OutOfCombat() {
        // Move

        // Search for Target

        // Randomly choose random target in range
    }

    void InCombat() {
        // Maybe move

        // Fire as often as possible
    }

    void ReceiveDamage() {

    }
}
