using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C11Manager : MonoBehaviour
{
        public GameObject firewallPopUp;
        public GameObject serverScale;
        public GameObject rateLimit;
        public GameObject choiceScreen;
        public GameObject reportScreen;
        public GameObject taskDescription;

        public int correctChoiceIndex;
        public int totalScore = 0;
        private bool finished = false;
        private int selectedChoice = -1;
        private bool resultsSaved = false;
        private List<int> selectedAnswers = new List<int>();

        public TMP_Text reportText;
        public TMP_Text scoreText;

    public void SelectChoice(int index)
    {
        if (finished) return;

        selectedChoice = index;

        choiceScreen.SetActive(false);
        HideAllPopups();

        if (index == 0) serverScale.SetActive(true);
        if (index == 1) rateLimit.SetActive(true);
        if (index == 2) firewallPopUp.SetActive(true);
    }
    public void BackToChoices()
    {
        if (finished) return;

        HideAllPopups();
        choiceScreen.SetActive(true);
    }
    public void ConfirmAdd()
    {
        if (finished) return;
        if (selectedChoice == -1) return;

        selectedAnswers.Add(selectedChoice);

        bool isCorrect = selectedChoice == correctChoiceIndex;

        if (isCorrect)
            totalScore = 5;
        else
            totalScore = 0;

        Debug.Log(isCorrect ? "Correct choice" : "Wrong choice");
        Debug.Log("Score: " + totalScore);

        Finish();
    }

    void Finish()
    {
        finished = true;

        SaveToGameManager();
        UpdateReportUI();

        HideAllPopups();

        if (choiceScreen != null)
            choiceScreen.SetActive(false);

        if (reportScreen != null)
            reportScreen.SetActive(true);

        PlayerPrefs.SetInt("C11Score", totalScore);
    }

    void SaveToGameManager()
    {
        if (resultsSaved) return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveCase11Choices(selectedAnswers);
            GameManager.Instance.AddCase11Points(totalScore);

            Debug.Log("Saved Case 11 score: " + totalScore);
            Debug.Log("Case 11 total: " + GameManager.Instance.case11Score);
            Debug.Log("Game total score: " + GameManager.Instance.score);

            resultsSaved = true;
        }
        else
        {
            Debug.LogError("GameManager.Instance is NULL!");
        }
    }

    void UpdateReportUI()
    {
        if (scoreText != null)
        {
            scoreText.text = totalScore + " / 5";
        }

        if (reportText != null)
        {
            if (totalScore == 5)
            {
                reportText.text = "You chose the most effective response!";
            }
            else
            {
                reportText.text = "This was not the most effective immediate response.";
            }
        }
    }


    void HideAllPopups()
    {
        firewallPopUp.SetActive(false);
        serverScale.SetActive(false);
        rateLimit.SetActive(false);
    }
    public void SwitchScreen()
{
    Debug.Log("Start button clicked");

    if (taskDescription != null)
        taskDescription.SetActive(false);

    if (choiceScreen != null)
        choiceScreen.SetActive(true);
}
}