// Character.cs
// This script manages characters including stats, expressions, weapons, out of combat behaviors(scanning for targets, choosing targets) in combat behaviors(determining valid target, firing at targets) receiving damage, death, and calling the scoreboard at death.
// Must be attached to GameObject with: tag = "Character", Collider with "Is Trigger" = true, Rigidbody, NavMeshAgent, hand transform, eyes TextMeshPro, NameTag TextMeshPro
// Must set: characterHand, characterEyes, characterNameTag
// Should set: characterName, weaponStarting
// May set: healthPoints, dead

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour {
    // Score Keeper
    private GameObject scoreKeeper;

    //// Character Stats
    // Name
    // Should be set in inspector. Should be unique.
    [SerializeField]
    [Tooltip("Name of Character")]
    public string characterName; // Character Name

    // Health Points
    // May be set in inspector.
    [SerializeField]
    [Tooltip("Current Health Points")]
    public int healthPoints = 100; // Current Health

    // Death Status
    [Tooltip("The character is dead")]
    public bool dead = false;

    //// Body Parts
    // Hand transform. Location of held weapon.
    // Must be assigned in inspector. Must be transform.
    [SerializeField]
    [Tooltip("Transform hand for holding things")]
    private Transform characterHand;

    // Eyes TextMeshPro for expressions
    // Must be assigned in inspector. Must be TextMeshPro.
    [Tooltip("Text Mesh for top half of face emotes")]
    private TextMeshPro characterEyes;

    // Name Tag TextMeshPro
    // Must be assigned in inspector. Must be TextMeshPro.
    [Tooltip("Text Mesh for bottom half of face nametag")]
    private TextMeshPro characterNameTag;

    //// Weapon
    // Starting Weapon
    // Should be assigned in inspector. Must be prefab with weapon script.
    [SerializeField]
    [Tooltip("Weapon prefab character starts with")]
    private Weapon weaponStarting;

    // Weapon that is currently held and variables pulled from its weapon script
    private Weapon weaponHeld;
    private int weaponRange; // Meters range from Weapon
    private float weaponSpeed; // Seconds warm up from Weapon
    private float weaponSpeedCurrent; // Seconds count up before each firing

    //// Behavior
    // Combat Status determined in Update
    private bool combatActive = false; // Behavior Mode
        // False: Out of combat. No target is available, move and search for a target.
        // True: In combat. Attack target with weapon as often as possible.

    // List of All Targets generated at startup
    private List<GameObject> targetsAll = new List<GameObject>();

    // Targets within range determined by UpdateTargetsInRange
    private List<GameObject> targetsInRange = new List<GameObject>(); // List of targets within weaponRange

    // Combat Target
    private GameObject combatTarget; // Chosen target enemy for combat

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

        // Initialize face
        characterEyes = this.transform.Find("Face/Eyes").GetComponent<TextMeshPro>();
        if (characterEyes == null) {
            Debug.LogError(characterName + " could not find eyes.");
        }
        characterNameTag = this.transform.Find("Face/Tag").GetComponent<TextMeshPro>();
        if (characterNameTag != null) {
            characterNameTag.text = characterName;
        } else {
            Debug.LogError(characterName + " could not find name tag.");
        }

        // Find Score Keeper
        scoreKeeper = GameObject.FindWithTag("Score");
        if (scoreKeeper == null) {
            Debug.LogError(characterName + " could not find scorekeeper.");
        }
    }

    // Prepare Weapon is called from Start
    void prepareWeapon(Weapon weapon) {
        if (weaponStarting = null) { // Check for starting weapon
            Debug.LogError(characterName + " cannot find a weapon.");
        } else if (weaponHeld == null){ // Only with empty hands
            // Instantiate weapon
            weaponHeld = Instantiate(weapon) as Weapon;
            weaponHeld.transform.SetParent (characterHand);
            weaponHeld.transform.position = characterHand.transform.position;
            weaponHeld.transform.rotation = characterHand.transform.rotation;

            // Set Range
            if (weaponHeld.GetComponent<Weapon>().weaponRange > 0) {
                weaponRange = weaponHeld.GetComponent<Weapon>().weaponRange;
            } else {
                Debug.LogError(characterName + " has a weapon range issue. Defaults used.");
                weaponRange = 5; // Default fallback
            }

            // Set Speed
            if (weaponHeld.GetComponent<Weapon>().weaponSpeed > 0) {
                weaponSpeed = weaponHeld.GetComponent<Weapon>().weaponSpeed;
            } else {
                Debug.LogError(characterName + " has a weapon range issue. Defaults used.");
                weaponSpeed = 450; // Default fallback
            }
        } else {
            Debug.LogError(characterName + " already has a weapon.");
        }
    }

    void Update() {
        // Check for death if health is 0 or lower.
        if (dead) {
            // Stay dead
        } else if (healthPoints <= 0) { 
            // Die
            dead = true;

            // Look dead
            // Disable NavMeshAgent
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            characterEyes.text = "x x"; // Dead eyes

            // Call scorekeeper to record death
            if (scoreKeeper != null) {
                scoreKeeper.GetComponent<Scorekeeper>().RecordDeath(characterName);
            } else {
                Debug.LogError(characterName + " could not find scorekeeper on death.");
            }
        } else {
            // Act
            if (combatActive) {
                // Call combat script
                InCombat();
            } else {
                // Call out of combat script
                OutOfCombat();
            }
        }
    }

    //// In Combat
    // In Combat is called from Update
    void InCombat() {
        // Check if target is still within range
        if(IsTargetInRange(combatTarget.transform)) {
            // Aim
            this.transform.LookAt(combatTarget.transform);

            // Weapon warmup
            weaponSpeedCurrent += Time.deltaTime;
            // Fire
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
            characterEyes.text = "o o";
        }
    }

    // IsTargetInRange is called from InCombat
    bool IsTargetInRange (Transform target) {
        Vector3 position = transform.position; // Set position for distance caclulation
        Vector3 diff = target.transform.position - position;
        float targetDistance = diff.sqrMagnitude; // Squared for efficiency
        if (targetDistance < weaponRange * weaponRange) {
            // Check if dead
            if (target.GetComponent<Character>().dead == false) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    //// Out of Combat
    // OutOfCombat is called from Update
    void OutOfCombat() {
        // Check for all enemies within range
        UpdateTargetsInRange();
        // Enter combat if target in range
        if (targetsInRange.Count > 0) {
            ChooseTarget();
            combatActive = true;
            characterEyes.text = ". .";
        }
    }

    // UpdateTargetsInRange is called from OutOfCombat
    void UpdateTargetsInRange() {
        // Start with a blank state
        targetsInRange.Clear();

        // Set starting location
        Vector3 position = transform.position;

        // Check distance to all targets and compare to range and dead
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

    // ChooseTarget is called from OutOfCombat
    void ChooseTarget() {
        // Randomly choose target from targetsInRange
        combatTarget = targetsInRange[Random.Range(0,targetsInRange.Count)];
    }

    //// External
    // Called externally from Bullet
    public void ReceiveDamage(int damage) {
        // Subtract damage from healthPoints
        healthPoints -= damage;
    }
}
