using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C8Manager : MonoBehaviour
{
        public GameObject[] choiceScreens;
        public int[] correctAnswers;
        public GameObject taskDescription;
        public GameObject reportScreen;
        public int totalScore = 0;
         public TMP_Text reportText;
        public TMP_Text scoreText;
        public GameObject gameReport;
        private List<int> selectedAnswers = new List<int>();
        private int currentQuestionIndex = 0;
        private bool answered = false;
        private bool resultsSaved = false;

    public void SelectAnswer(int selectedIndex)
    {
        if (answered) return;

        answered = true;

        selectedAnswers.Add(selectedIndex);

        bool isCorrect = selectedIndex == correctAnswers[currentQuestionIndex];

        if (isCorrect)
            totalScore++;

        Debug.Log("Q" + currentQuestionIndex +
                  " | Selected: " + selectedIndex +
                  " | Correct: " + correctAnswers[currentQuestionIndex]);

        currentQuestionIndex++;
        answered = false;

        if (currentQuestionIndex >= choiceScreens.Length)
        {
            HideAllScreens();

            SaveToGameManager();
            UpdateReportUI();

            if (reportScreen != null)
                reportScreen.SetActive(true);

            return;
        }

        ShowOnlyCurrentScreen();
    }

    private void ShowOnlyCurrentScreen()
    {
        for (int i = 0; i < choiceScreens.Length; i++)
        {
            choiceScreens[i].SetActive(i == currentQuestionIndex);
        }
    }
    private void HideAllScreens()
    {
        for (int i = 0; i < choiceScreens.Length; i++)
        {
            choiceScreens[i].SetActive(false);
        }
    }
    private void SaveToGameManager()
    {
        if (resultsSaved) return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveCase8Choices(selectedAnswers);
            GameManager.Instance.AddCase8Points(totalScore);

            Debug.Log("Saved Case 8 score: " + totalScore);
            Debug.Log("Total score: " + GameManager.Instance.score);

            resultsSaved = true;
        }
        else
        {
            Debug.LogError("GameManager is NULL!");
        }
    }
    private void UpdateReportUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Correct : " + totalScore + " / " + choiceScreens.Length;
        }

        if (reportText != null)
        {
            if (totalScore == choiceScreens.Length)
            {
                reportText.text = "You made responsible decisions and followed GDPR \n\nprinciples correctly.";
            }
            else if (totalScore >= choiceScreens.Length / 2)
            {
                reportText.text = "You understood some GDPR rules, but missed a few \n\nimportant points.";
                reportText.color = Color.yellow;
            }
            else
            {
                reportText.text = "You made several incorrect decisions. Be more \n\ncareful when handling personal data.";
                reportText.color = Color.red;
            }
        }
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
    public void CheckAnswers()
{

    if (currentQuestionIndex < choiceScreens.Length)
    {
        HideAllScreens();

        SaveToGameManager();
        UpdateReportUI();

        if (reportScreen != null)
            reportScreen.SetActive(true);
    }
}
}