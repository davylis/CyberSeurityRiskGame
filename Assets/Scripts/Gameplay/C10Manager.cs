using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C10Manager : MonoBehaviour
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

        bool isCorrect = selectedIndex == correctAnswerIndex;

        if (isCorrect)
            totalScore += 5;

        Debug.Log("Selected: " + selectedIndex);
        Debug.Log("Correct: " + correctAnswerIndex);
        Debug.Log("Answer: " + (isCorrect ? "Correct" : "Wrong"));
        Debug.Log("Final score: " + totalScore);

        FinishQuiz();

        }
    private void FinishQuiz()
    {
        if (summaryScreen != null) summaryScreen.SetActive(false);
        if (logsScreen != null) logsScreen.SetActive(false);
        if (choiceScreen != null) choiceScreen.SetActive(false);

        if (reportScreen != null)
            reportScreen.SetActive(true);

        PlayerPrefs.SetInt("C9Score", totalScore);
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}