using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    //// Character Stats

    // Name
    [SerializeField]
    [Tooltip("Name of Character")]
    private string characterName; // Character Name

    // TODO: Nametag

    // Health
    [SerializeField]
    [Tooltip("Current Health Points")]
    public int healthPoints = 100; // Current Health

    [SerializeField]
    [Tooltip("The character is dead")]
    public bool dead = false;

    // Weapon
    [SerializeField]
    [Tooltip("Weapon prefab held by character")]
    private Weapon weaponHeld;

    //// Behavior
    // Combat Status
    private bool combatStatus = false; // Behavior Mode
        // False: Out of combat. No target is available, move and search for a target.
        // True: In combat. Attack target with weapon as often as possible.

    // All Targets
    private List<GameObject> targetsAll = new List<GameObject>(); // List of all targets

    // Targets within range
    private List<GameObject> targetsInRange = new List<GameObject>(); // List of targets within weaponRange

    // Combat Target
    private GameObject combatTarget; // Chosen target enemy for combat

    // Weapon
    private int weaponRange = 7; // Meters range from Weapon
    private int weaponSpeed; // Milliseconds warm up from Weapon

    // TODO: Angry face

    // Navigation
	UnityEngine.AI.NavMeshAgent navigationAgent; // Navigation Agent
    private Transform characterPosition; // Character Position
    private Transform navigationTarget; // Navigation target for walking


    void Start() {
        // Initialize Navigation
        navigationAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        characterPosition = GetComponent<Transform>();

        // Intialize Targets
        foreach(GameObject character in GameObject.FindGameObjectsWithTag("Character")) {
            targetsAll.Add(character);
        }

        // Instantiate Weapon


        // TODO: Check for unique name
    }

    void Update() {
        // Check for death if health is 0 or lower.
        if (healthPoints <= 0) {
            dead = true;
            // TODO: Look dead
        } else {
            if (combatStatus) {
                InCombat();
            } else {
                OutOfCombat();
            }
        }
    }

    void OutOfCombat() {
        // Check for all enemies within range
        UpdateTargetsInRange();
        // Target must be in range and not dead
        // Randomly choose random target in range

        // Move
    }

    void InCombat() {
        // Check if target is still within range
        if(IsTargetInRange(combatTarget.transform)) {
        };
        // Fire as often as possible

        // Move evasively
    }

    void UpdateTargetsInRange() {
        targetsInRange.Clear();

        Vector3 position = transform.position;
        foreach (GameObject target in targetsAll) {
            Vector3 diff = target.transform.position - position;
            float targetDistance = diff.sqrMagnitude;
            float range = weaponRange * weaponRange; // Squared for efficiency
            if (targetDistance < range) {
                targetsInRange.Add(target);
            }
        }
        // Remove self from List
        targetsInRange.Remove(this.gameObject);
    }

    Transform ChooseTarget() {
        return null;
    }

    bool IsTargetInRange (Transform target) {
        return false;
    }

    void ReceiveDamage(int damage) {
        healthPoints =- damage;
    }
}
