using UnityEngine;

public class C2Manager : MonoBehaviour
{
    public GameObject searchPanel;
    public GameObject resultsPanel;
    public GameObject arrow;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject jobkedinPanel;
    public GameObject daybookPanel;
    public GameObject capturegramPanel;
    public GameObject findPanel;

    public GameObject taskDescription;  
    private GameObject currentPanel;

    private int pointsCollected = 0;
    private int maxPoints = 7;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log( GameManager.Instance.playerName + GameManager.Instance.playerDegree + GameManager.Instance.age);
            Debug.Log("PrivacyChoice Start: GameManager found. Current score = " + GameManager.Instance.score);
        }

        OpenPanel(searchPanel);
    }

    void OpenPanel(GameObject panel)
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        currentPanel = panel;
        currentPanel.SetActive(true);
    }
    void AddPoint(string source)
    {
        pointsCollected++;

        Debug.Log("Point gained from: " + source);
        Debug.Log("Case 2 points: " + pointsCollected + " / " + maxPoints);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddPoints(1);
            Debug.Log("Total GameManager score: " + GameManager.Instance.score);
        }
    }
    public void ShowResults()
    {
        OpenPanel(resultsPanel);
        if (arrow != null) arrow.SetActive(false);
    }

    public void BackToSearch()
    {
        OpenPanel(searchPanel);
    }
    public void OpenJobkedin()
    {
        OpenPanel(jobkedinPanel);
        if (arrow3 != null) arrow3.SetActive(false);
    }

    public void OpenDaybook()
    {
        OpenPanel(daybookPanel);
        if (arrow5 != null) arrow5.SetActive(false);
    }

    public void OpenCapturegram()
    {
        OpenPanel(capturegramPanel);
        if (arrow4 != null) arrow4.SetActive(false);
    }

    public void OpenFind()
    {
        OpenPanel(findPanel);
        if (arrow6 != null) arrow6.SetActive(false);
    }
    public void BackToResults()
    {
        OpenPanel(resultsPanel);;
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}