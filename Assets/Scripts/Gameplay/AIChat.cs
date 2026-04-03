using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIChat : MonoBehaviour
{
   public GameObject[] prompts;
   public GameObject gameRaport;

   public TMP_Text reportText;
    public TMP_Text scoreText;
   public bool[] correctAnswers;
   private int currentQuestion = 0;
   private int score = 0;
   private bool resultsSaved = false;
   private List<int> playerChoices = new List<int>();
   
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
        playerChoices.Add(isSafe ? 1 : 0);

        if (isSafe == correctAnswers[currentQuestion])
        {
            score++;
        }

        Debug.Log("Q" + currentQuestion +
                  " | Player: " + (isSafe ? "SAFE" : "NOT SAFE") +
                  " | Correct: " + (correctAnswers[currentQuestion] ? "SAFE" : "NOT SAFE"));

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

        if (!resultsSaved)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SaveCase7Choices(playerChoices);

                GameManager.Instance.AddCase7Points(score);

                Debug.Log("Saved Case 7 score: " + score);
                Debug.Log("Game total score: " + GameManager.Instance.score);
            }
            else
            {
                Debug.LogError("GameManager.Instance is NULL!");
            }

            resultsSaved = true;
        }
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score + " / 2";
        }

        if (reportText != null)
        {
            if (score == prompts.Length)
            {
                reportText.text = "You correctly identified all unsafe prompts and avoided \n\nsharing sensitive data.";
            }
            else if (score >= prompts.Length / 2)
            {
                reportText.text = "You identified some unsafe prompts, but missed a few.";
            }
            else
            {
                reportText.text = "Avoid sharing personal or confidential information \n\nwith AI tools.";
            }
        }

        if (gameRaport != null)
        {
            gameRaport.SetActive(true);
        }

        Debug.Log("Final Score: " + score + " / " + prompts.Length);
    }

}
