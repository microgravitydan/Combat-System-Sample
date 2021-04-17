// Scorekeeper.cs
// This script runs a timer and logs incoming calls to record character deaths. When the win condition of 9 deaths is triggered, it searches for the final living character and displays a scoreboard with the winner at the top.
// Must be attached to Finalscore TextMeshProUGUI GameObject with: Canvas parent, "Score" tag, enabled.
// No variables must be set

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour {
    // Score tracking
    private int characterDeaths; // Count number of deaths received
    private float gameTimer; // Time since things actually start moving
    private string winnerName;
    private bool gameWon;

    // Score Board string that is amended as scores come in
    private string scoreBoard;

    void Start() {
        // Clear the UI
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "";

        // Start timer
        gameTimer = 0;
    }

    void Update() {
        // Check for new win condition of 9 deaths
        if (gameWon == false && characterDeaths >= 9) {
            gameWon = true; // Stop checking for win
            Time.timeScale = 0.1f; // Slow time for effect
            DetermineWinner(); // Get character that is not dead

            // Display Final Scores
            this.gameObject.GetComponent<TextMeshProUGUI>().text = scoreBoard;
        }
        gameTimer += Time.deltaTime; // Advance timer
    }

    // Record Death is called externally from Characters as they die
    public void RecordDeath(string name) {
        // Concatenate score string
        string scoreEntry = name + " - " + gameTimer.ToString("#.00") + " seconds\n";
        Debug.Log(scoreEntry);
        scoreBoard = scoreEntry + scoreBoard; // Amend to top of Score Board
        characterDeaths += 1; // advance death counter
    }

    // Determine winner called from Update when win conditions are met
    public void DetermineWinner() {
        // Check each character object for dead == false
        foreach(GameObject character in GameObject.FindGameObjectsWithTag("Character")) {
            if (character.GetComponent<Character>().dead == false) {
                // Assign winner name
                winnerName = character.GetComponent<Character>().characterName;
            }
        }
        
        Debug.Log("The winner is " + winnerName + " in " + gameTimer.ToString("#.00") + " seconds!");
        // Amend Score Board with winner announcement
        scoreBoard = "The winner is " + winnerName + " in " + gameTimer.ToString("#.00") + " seconds!\n" + scoreBoard;
    }
}
