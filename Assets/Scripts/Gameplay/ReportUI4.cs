using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportUI4 : MonoBehaviour
{
    public TextMeshProUGUI reportText;
    public TextMeshProUGUI scoreText;
    public GameObject GameRaport;
    private bool scoreSaved = false;

    public void ShowReport()
    {
        int items = C4GManager.Instance.collectedItems;
        int points = items;

        if (items == 5)
            reportText.text = "Strong Security Awareness";
        else if (items >= 3)
        {
            reportText.text = "Partial Security Awareness";
            reportText.color = Color.yellow;
        }
        else
        {
            reportText.text = "Low Security Awareness";
            reportText.color = Color.red;
        }

        scoreText.text = "Items cleaned : " + items + " / 5\n\n";

        if (!scoreSaved)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCase4Points(points);

                Debug.Log("Case 4 points added: " + points);
                Debug.Log("Case 4 total: " + GameManager.Instance.case4Score);
                Debug.Log("Game total score: " + GameManager.Instance.score);

                scoreSaved = true;
            }
            else
            {
                Debug.LogError("GameManager is NULL!");
            }
        }
        GameRaport.SetActive(true);
    }
}