using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportUI4 : MonoBehaviour
{
    public TextMeshProUGUI reportText;
     public GameObject GameRaport;
     private bool scoreSaved = false;

    public void ShowReport()
    {
        int items = C4GManager.Instance.collectedItems;
        int points = items * 2;

        string message = "";

        if (items == 5)
            message = "Strong Security Awareness";
        else if (items >= 3)
            message = "Partial Security Awareness";
        else
            message = "Low Security Awareness";

        reportText.text =
            message +
            "\n\n\n\nItems cleaned : " + items + " / 5\n\n";

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