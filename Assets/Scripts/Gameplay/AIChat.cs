using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChat : MonoBehaviour
{
   public GameObject[] prompts;
   public GameObject GameRaport;
   private int currentQuestion = 0;
   private int score = 0;
   public bool[] correctAnswers;
   
   void Start()
    {
        ShowPrompt(0);
    }

    void ShowPrompt(int index)
    {
        for (int i = 0; i < prompts.Length; i++)
            prompts[i].SetActive(i == index);
    }

    public void OnAnswerSelected(bool isSafe)
    {
        if (isSafe == correctAnswers[currentQuestion])
        {
            score++;
        }

        currentQuestion++;

        if (currentQuestion < prompts.Length)
        {
            ShowPrompt(currentQuestion);
        }
        else
        {
            ShowReport();
        }
    }
    void ShowReport()
    {
        foreach (GameObject p in prompts)
        {
            p.SetActive(false);
        }

        GameRaport.SetActive(true);

        PlayerPrefs.SetInt("AIChatScore", score);

        Debug.Log("Final Score: " + score + " / " + prompts.Length);
    }

}
