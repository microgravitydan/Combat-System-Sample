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

    // Body Parts
    [SerializeField]
    [Tooltip("Transform hand for holding things")]
    private Transform characterHand;

    [SerializeField]
    [Tooltip("GameObject face for showing things")]
    private GameObject characterFace;

    // Weapon
    [SerializeField]
    [Tooltip("Weapon prefab character starts with")]
    private Weapon weaponStarting;

    private Weapon weaponHeld;

    private int weaponRange; // Meters range from Weapon
    private float weaponSpeed; // Seconds warm up from Weapon
    private float weaponSpeedCurrent; // Seconds count up before each firing

    //// Behavior
    // Combat Status
    private bool combatActive = false; // Behavior Mode
        // False: Out of combat. No target is available, move and search for a target.
        // True: In combat. Attack target with weapon as often as possible.

    // All Targets
    private List<GameObject> targetsAll = new List<GameObject>(); // List of all targets

    // Targets within range
    private List<GameObject> targetsInRange = new List<GameObject>(); // List of targets within weaponRange

    // Combat Target
    private GameObject combatTarget; // Chosen target enemy for combat

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

        // Initialize Weapon
        prepareWeapon(weaponStarting);

        // TODO: Check for unique name
    }

    void Update() {
        // Check for death if health is 0 or lower.
        if (healthPoints <= 0 || dead) {
            dead = true;
            // TODO: Look dead
        } else {
            if (combatActive) {
                InCombat();
            } else {
                OutOfCombat();
            }
        }
    }

    void OutOfCombat() {
        // Check for all enemies within range
        UpdateTargetsInRange();
        if (targetsInRange.Count > 0) {
            ChooseTarget();
            combatActive = true;
        }
        // Target must be in range and not dead
        // Randomly choose random target in range

        // Move
    }

    void prepareWeapon(Weapon weapon) {
        if (weaponHeld == null){ // Only with empty hands
            weaponHeld = Instantiate(weapon) as Weapon;
            weaponHeld.transform.SetParent (characterHand);
            weaponHeld.transform.position = characterHand.transform.position;
            weaponHeld.transform.rotation = characterHand.transform.rotation;

            // Set Range
            if (weaponHeld.GetComponent<Weapon>().weaponRange > 0) {
                weaponRange = weaponHeld.GetComponent<Weapon>().weaponRange;
            } else {
                weaponRange = 5; // Default fallback
            }

            // Set Speed
            if (weaponHeld.GetComponent<Weapon>().weaponSpeed > 0) {
                weaponSpeed = weaponHeld.GetComponent<Weapon>().weaponSpeed;
            } else {
                weaponSpeed = 450; // Default fallback
            }
        }
    }

    void InCombat() {
        // Check if target is still within range
        if(IsTargetInRange(combatTarget.transform)) {
            // Aim
            this.transform.LookAt(combatTarget.transform);
            // Fire
            weaponSpeedCurrent += Time.deltaTime;
            if (weaponSpeedCurrent >= weaponSpeed) {
                // Call FireWeapon from Held Weapon
                weaponHeld.GetComponent<Weapon>().FireWeapon();
                weaponSpeedCurrent = 0; // Reset timer
            }
        } else {
            // Exit Combat
            combatTarget = null;
            combatActive = false;
            weaponSpeedCurrent = 0;
        }
        // Move evasively
    }

    void UpdateTargetsInRange() {
        targetsInRange.Clear(); // Start with a blank state

        Vector3 position = transform.position; // Set position for distance caclulation
        foreach (GameObject target in targetsAll) { // Check every character target
            Vector3 diff = target.transform.position - position;
            float targetDistance = diff.sqrMagnitude; // Squared for efficiency

            // Check if within range
            if (targetDistance < weaponRange * weaponRange) { // Squared for efficiency
                
                // Check if dead
                if (target.GetComponent<Character>().dead == false) {
                    
                    // Add to list
                    targetsInRange.Add(target);
                }
            }
        }
        // Remove self from List
        targetsInRange.Remove(this.gameObject);
    }

    void ChooseTarget() {
        combatTarget = targetsInRange[Random.Range(0,targetsInRange.Count)];
    }

    bool IsTargetInRange (Transform target) {
        Vector3 position = transform.position; // Set position for distance caclulation
        Vector3 diff = target.transform.position - position;
        float targetDistance = diff.sqrMagnitude; // Squared for efficiency
        if (targetDistance < weaponRange * weaponRange) {
            return true;
        } else {
            return false;
        }
    }

    public void ReceiveDamage(int damage) {
        Debug.Log("Hit by bullet!");
        healthPoints -= damage;
    }
}
