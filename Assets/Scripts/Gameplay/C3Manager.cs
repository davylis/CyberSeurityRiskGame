using UnityEngine;

public class C3Manager : MonoBehaviour
{
    public GameObject weakReport;
    public GameObject mediumReport;
    public GameObject strongReport;
    public GameObject veryStrongReport;
    public GameObject superStrongReport;
    public GameObject taskDescription;
    public GameManager gameManager;

    private bool scoreSaved = false;
    public void ShowReport(string strength)
    {
        // Turn everything off first
        weakReport.SetActive(false);
        mediumReport.SetActive(false);
        strongReport.SetActive(false);
        veryStrongReport.SetActive(false);

        int points = 0;

        switch (strength.ToLower())
        {
            case "weak":
                weakReport.SetActive(true);
                points = 0;
                break;
            case "medium":
                mediumReport.SetActive(true);
                points = 1;
                break;
            case "strong":
                strongReport.SetActive(true);
                points = 2;
                break;
            case "verystrong":
                veryStrongReport.SetActive(true);
                points = 3;
                break;
            case "superstrong":
                superStrongReport.SetActive(true);
                points = 4;
                break;
            default:
                Debug.LogWarning("Unknown password strength: " + strength);
                points = 0;
                weakReport.SetActive(true);
                break;
        }
        if (!scoreSaved)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCase3Points(points);
                Debug.Log("Case 3 points added: " + points);
                Debug.Log("Case 3 total: " + GameManager.Instance.case3Score);
                Debug.Log("Game total score: " + GameManager.Instance.score);
                scoreSaved = true;
            }
            else
            {
                Debug.LogError("GameManager.Instance is NULL!");
            }
        }
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}