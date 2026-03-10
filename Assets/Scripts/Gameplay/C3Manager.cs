using UnityEngine;

public class C3Manager : MonoBehaviour
{
    public GameObject weakReport;
    public GameObject mediumReport;
    public GameObject strongReport;
    public GameObject veryStrongReport;
    public GameObject veryVeryStrongReport;
    public GameObject superStrongReport;
    public GameObject taskDescription;

    public void ShowReport(string strength)
    {
        // Turn everything off first
        weakReport.SetActive(false);
        mediumReport.SetActive(false);
        strongReport.SetActive(false);
        veryStrongReport.SetActive(false);
        veryVeryStrongReport.SetActive(false);
        superStrongReport.SetActive(false);

        switch (strength.ToLower())
        {
            case "weak":
                weakReport.SetActive(true);
                break;
            case "medium":
                mediumReport.SetActive(true);
                break;
            case "strong":
                strongReport.SetActive(true);
                break;
            case "verystrong":
                veryStrongReport.SetActive(true);
                break;
            case "veryverystrong":
                veryVeryStrongReport.SetActive(true);
                break;
            case "superstrong":
                superStrongReport.SetActive(true);
                break;
            default:
                Debug.LogWarning("Unknown password strength: " + strength);
                weakReport.SetActive(true);
                break;
        }
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}