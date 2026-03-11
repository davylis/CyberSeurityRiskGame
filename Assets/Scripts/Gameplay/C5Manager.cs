using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5Manager : MonoBehaviour
{
        public EmailToggle[] emailToggles;

    public void CheckAnswers()
    {
        int correct = 0;

        foreach (EmailToggle email in emailToggles)
        {
            if (email.IsCorrect())
                correct++;
        }

        Debug.Log("Correct answers: " + correct + " / " + emailToggles.Length);
    }
}