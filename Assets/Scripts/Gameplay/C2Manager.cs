using UnityEngine;

public class C2Manager : MonoBehaviour
{
    public GameObject searchPanel;
    public GameObject resultsPanel;

    public GameObject jobkedinPanel;
    public GameObject daybookPanel;
    public GameObject capturegramPanel;
    public GameObject findPanel;
    public GameObject taskDescription;  
    private GameObject currentPanel;

    void Start()
    {
        OpenPanel(searchPanel);
    }

    void OpenPanel(GameObject panel)
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        currentPanel = panel;
        currentPanel.SetActive(true);
    }
    public void ShowResults()
    {
        OpenPanel(resultsPanel);
    }

    public void BackToSearch()
    {
        OpenPanel(searchPanel);
    }
    public void OpenJobkedin()
    {
        OpenPanel(jobkedinPanel);
    }

    public void OpenDaybook()
    {
        OpenPanel(daybookPanel);
    }

    public void OpenCapturegram()
    {
        OpenPanel(capturegramPanel);
    }

    public void OpenFind()
    {
        OpenPanel(findPanel);
    }
    public void BackToResults()
    {
        OpenPanel(resultsPanel);
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}