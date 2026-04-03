using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C9Manager : MonoBehaviour
{
        public GameObject summaryScreen;
        public GameObject logsScreen;
        public GameObject choiceScreen;
        public GameObject reportScreen;
        public GameObject taskDescription;

        public GameObject arrow;
        public GameObject openLogsButton;
        public GameObject answerQuestionButton;

        public int correctAnswerIndex;
        public int totalScore = 0;
        private bool answered = false;
        private bool logsReviewed = false;
        private bool resultsSaved = false;
        private List<int> selectedAnswers = new List<int>();

        public TMP_Text reportText;
        public TMP_Text scoreText;


    private void ShowReviewedSummary()
    {
        if (summaryScreen != null) summaryScreen.SetActive(true);
        if (logsScreen != null) logsScreen.SetActive(false);
        if (choiceScreen != null) choiceScreen.SetActive(false);
        if (reportScreen != null) reportScreen.SetActive(false);

        if (arrow != null) arrow.SetActive(false);
        if (openLogsButton != null) openLogsButton.SetActive(true);
        if (answerQuestionButton != null) answerQuestionButton.SetActive(true);
    }
    public void OpenLogs()
    {
        if (summaryScreen != null) summaryScreen.SetActive(false);
        if (logsScreen != null) logsScreen.SetActive(true);

    }
    public void BackFromLogs()
    {
        logsReviewed = true;
        ShowReviewedSummary();
    }
    public void OpenChoices()
    {
        if (!logsReviewed)
            return;

        if (summaryScreen != null) summaryScreen.SetActive(false);
        if (logsScreen != null) logsScreen.SetActive(false);
        if (choiceScreen != null) choiceScreen.SetActive(true);
        if (reportScreen != null) reportScreen.SetActive(false);
    }
    public void BackFromChoices()
    {
        ShowReviewedSummary();
    }

    public void SelectAnswer(int selectedIndex)
    {
        if (answered) return;

        answered = true;

        selectedAnswers.Add(selectedIndex);

        bool isCorrect = selectedIndex == correctAnswerIndex;

        if (isCorrect)
            totalScore += 5;
        else
            totalScore = 0;

        Debug.Log("Selected: " + selectedIndex);
        Debug.Log("Correct: " + correctAnswerIndex);
        Debug.Log("Answer: " + (isCorrect ? "Correct" : "Wrong"));
        Debug.Log("Final score: " + totalScore);

        FinishQuiz();

        }
    private void FinishQuiz()
    {
        if (!resultsSaved)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SaveCase9Choices(selectedAnswers);
                GameManager.Instance.AddCase9Points(totalScore);

                Debug.Log("Saved Case 9 points: " + totalScore);
                Debug.Log("Case 9 total: " + GameManager.Instance.case9Score);
                Debug.Log("Game total score: " + GameManager.Instance.score);
            }
            else
            {
                Debug.LogError("GameManager.Instance is NULL!");
            }

            resultsSaved = true;
        }
        UpdateReportUI();
        if (reportScreen != null)
            reportScreen.SetActive(true);

        
    }
    private void UpdateReportUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + totalScore + " / 5";
        }

        if (reportText != null)
        {
            if (totalScore == 5)
            {
                reportText.text = "You correctly identified the attack!";
            }
            else
            {
                reportText.text = "You selected the wrong attack type.";
            }
        }
    }


    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}