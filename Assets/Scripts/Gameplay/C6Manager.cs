using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C6Manager : MonoBehaviour
{
        public AccessToggle[] accessToggles;
        public GameObject taskDescription;
        public GameObject gameReport;
        public TMP_Text reportText;
        public TMP_Text scoreText;
        private bool scoreSaved = false;
    public void CheckAnswers()
    {
        if (scoreSaved) return;
        
        int correct = 0;
        List<int> playerChoices = new List<int>();

        foreach (AccessToggle access in accessToggles)
        {
            int value = access.toggle.isOn ? 1 : 0;
            playerChoices.Add(value);

            if (access.isSuspicious && access.toggle.isOn)
            {
                correct++;
            }
        }

        int points = correct;

        Debug.Log("Suspicious found: " + correct);
        Debug.Log("Points: " + points);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveCase6Choices(playerChoices);
            GameManager.Instance.AddCase6Points(points);

            Debug.Log("Saved Case 6 points: " + points);
            Debug.Log("Case 6 total: " + GameManager.Instance.case6Score);
            Debug.Log("Total score: " + GameManager.Instance.score);
        }
        else
        {
            Debug.LogError("GameManager is NULL!");
        }
        if (reportText != null)
        {
            if (correct == 5)
                reportText.text = "You correctly identified all suspicious login attempts.";
            else if (correct >= 3)
                reportText.text = "You identified some suspicious activity, but missed \n\na few risks.";
            else
                reportText.text = "You missed many suspicious login attempts. Be \n\nmore careful.";
        }

        if (scoreText != null)
        {
            scoreText.text = "Score : " + correct + " / 5";
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