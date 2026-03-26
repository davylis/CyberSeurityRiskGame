using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        bool isCorrect = selectedChoice == correctChoiceIndex;

        if (isCorrect)
            totalScore += 5;

        Debug.Log(isCorrect ? "Correct choice" : "Wrong choice");
        Debug.Log("Score: " + totalScore);

        Finish();
    }

    void Finish()
    {
        finished = true;

        HideAllPopups();
        choiceScreen.SetActive(false);
        reportScreen.SetActive(true);

        PlayerPrefs.SetInt("C10Score", totalScore);
    }

    void HideAllPopups()
    {
        firewallPopUp.SetActive(false);
        serverScale.SetActive(false);
        rateLimit.SetActive(false);
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}