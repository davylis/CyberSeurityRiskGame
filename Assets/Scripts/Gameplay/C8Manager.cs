using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C8Manager : MonoBehaviour
{
        public GameObject[] choiceScreens;
        public int[] correctAnswers;
        public GameObject taskDescription;
        public GameObject reportScreen;
        public int totalScore = 0;
        public List<bool> gdprAnswers = new List<bool>();
        private int currentQuestionIndex = 0;
        private bool answered = false;

    public void SelectAnswer(int selectedIndex)
    {
        if (answered) return;

        answered = true;

        bool isCorrect = selectedIndex == correctAnswers[currentQuestionIndex];
        gdprAnswers.Add(isCorrect);

        if (isCorrect)
            totalScore++;

        Debug.Log("Question " + currentQuestionIndex + ": " + (isCorrect ? "Correct" : "Wrong"));

        currentQuestionIndex++;
        answered = false;

    if (currentQuestionIndex >= choiceScreens.Length)
        {
            HideAllScreens();

            Debug.Log("Finished! Correct answers: " + CountCorrectAnswers() + " / " + gdprAnswers.Count);
            Debug.Log("Total score: " + totalScore);

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

    private int CountCorrectAnswers()
    {
        int count = 0;

        foreach (bool answer in gdprAnswers)
        {
            if (answer) count++;
        }

        return count;
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}