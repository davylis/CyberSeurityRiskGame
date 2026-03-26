using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6Manager : MonoBehaviour
{
        public AccessToggle[] accessToggles;
        public GameObject taskDescription;

    public void CheckAnswers()
    {
        int correct = 0;

        foreach (AccessToggle access in accessToggles)
        {
            if (access.IsCorrect())
                correct++;
        }

        Debug.Log("Correct answers: " + correct + " / " + accessToggles.Length);
    }

    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}