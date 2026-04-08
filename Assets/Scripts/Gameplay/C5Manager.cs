using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C5Manager : MonoBehaviour
{
        public EmailToggle[] emailToggles;
        public GameObject taskDescription;
        public GameObject gameReport;
        public TMP_Text reportText;
        public TMP_Text scoreText;
        private bool scoreSaved = false;

    public void CheckAnswers()
    {
        if (scoreSaved) return;

       int suspiciousFound = 0;

        List<int> playerChoices = new List<int>();

        foreach (EmailToggle email in emailToggles)
        {
            int selectedValue = email.toggle.isOn ? 1 : 0;
            playerChoices.Add(selectedValue);

            if (email.isSuspicious && email.toggle.isOn)
            {
                suspiciousFound++;
            }
        }

        int points = suspiciousFound;

        Debug.Log("Suspicious found: " + suspiciousFound + " / 5");
        Debug.Log("Points to save: " + points);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCase5Points(points);
            GameManager.Instance.SaveCase5Choices(playerChoices);

            Debug.Log("Saved Case 5 points: " + points);
            Debug.Log("Case 5 total: " + GameManager.Instance.case5Score);
            Debug.Log("Game total score: " + GameManager.Instance.score);
        }
        else
        {
            Debug.LogError("GameManager.Instance is NULL!");
        }

       if (reportText != null)
        {
            if (suspiciousFound == 5)
                reportText.text = "You identified all phishing emails correctly.";
            else if (suspiciousFound >= 3)
            {
                reportText.text = "You identified some phishing emails, but missed a \n\nfew.";
                reportText.color = Color.yellow;
            }
            else
            {
                reportText.text = "You missed many phishing emails. Be more careful \n\nwith suspicious messages.";
                reportText.color = Color.red;
            }
        }

        if (scoreText != null)
        {
            scoreText.text = "Correct : " + suspiciousFound + " / 5";
        }

        if (gameReport != null)
            gameReport.SetActive(true);

        scoreSaved = true;
            
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}