using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour {

    private int characterDeaths;
    private float gameTimer;
    private string deathName;
    private string winnerName;
    private bool gameWon;

    private List<string> finalScores = new List<string>();
    private string scoreBoard;

    void Start() {
        // Empty UI
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "";

        // Start timer
        gameTimer = 0;
    }

    void Update() {
        // Check for win condition
        if (gameWon == false && characterDeaths >= 9) {
            // Stop checking for win
            gameWon = true;

            // Slow time for effect
            Time.timeScale = 0.1f;

            // Get character that is not dead
            DetermineWinner();

            // Display Final Scores
            Debug.Log(scoreBoard);
            this.gameObject.GetComponent<TextMeshProUGUI>().text = scoreBoard;
        }
        gameTimer += Time.deltaTime;
    }

    public void RecordDeath(string name) {
        string scoreEntry = name + " - " + gameTimer.ToString("#.00") + " seconds\n";
        Debug.Log(scoreEntry);
        scoreBoard = scoreEntry + scoreBoard;
        characterDeaths += 1;
        finalScores.Add(scoreEntry);
    }

    public void DetermineWinner() {
        foreach(GameObject character in GameObject.FindGameObjectsWithTag("Character")) {
            if (character.GetComponent<Character>().dead == false) {
                winnerName = character.GetComponent<Character>().characterName;
            }
        }
        scoreBoard = "The winner is " + winnerName + " in " + gameTimer.ToString("#.00") + " seconds!\n" + scoreBoard;
        Debug.Log("The winner is " + winnerName + " in " + gameTimer.ToString("#.00") + " seconds!");
    }
}
