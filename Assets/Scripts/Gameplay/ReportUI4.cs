using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportUI4 : MonoBehaviour
{
    public TextMeshProUGUI reportText;
     public GameObject GameRaport;

    public void ShowReport()
    {
        int items = C4GManager.Instance.collectedItems;
        int points = items * 2;

        string message = "";

        if (items == 5)
            message = "Excellent work!";
        else if (items >= 3)
            message = "Good job!";
        else
            message = "Workspace needs more cleaning.";

        reportText.text =
            "Items cleaned: " + items + "/5\n\n" +
            "Points earned: " + points + "\n\n" +
            message;

            GameRaport.SetActive(true);
    }
}