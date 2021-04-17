using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Scorekeeper : MonoBehaviour {
    UnityEvent m_Score;

    private int characterDeaths;
    private float gameTimer;
    private string deathName;
    private string winnerName;

    private List<string> finalScores = new List<string>();

    void Start() {
        // Start Score Listener
        if (m_Score == null)
            m_Score = new UnityEvent();
        
        m_Score.AddListener(delegate{RecordDeath(deathName);});
        m_Score.AddListener(delegate{AnnounceWinner(winnerName);});
        
        // Hide UI
        //this.gameObject.SetActive(false);
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "";

        // Start timer
        gameTimer = 0;
    }

    void Update() {
        // Check for win condition
        if (characterDeaths >= 9) {
            // Pause
            Time.timeScale = 0;

            // Get character that is not dead
            // TODO: This

            // Display Final Scores
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Conclusion!";
            this.gameObject.SetActive(true);
        }
        gameTimer += Time.deltaTime;
    }

    public void RecordDeath(string name) {
        string scoreEntry = name + " - " + gameTimer.ToString("#.00") + " seconds\n";
        Debug.Log(scoreEntry);
        characterDeaths += 1;
        finalScores.Add(scoreEntry);
    }

    public void AnnounceWinner(string name) {
        winnerName = name;
    }
}
