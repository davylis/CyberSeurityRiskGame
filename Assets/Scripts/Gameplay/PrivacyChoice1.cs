using UnityEngine;

public class PrivacyChoice : MonoBehaviour
{
    public GameObject privacyPanel;
    public GameObject phonePanel;
    public GameObject goodPanel;
    public GameObject badPanel;
    public GameObject confirmPopup;
    private bool pendingAgree;
    public GameObject taskDescription;  
    public GameObject playScreen;

    public void Agree()
    {
        GameManager.Instance.AddPoints(0);
        Debug.Log("Current Score: " + GameManager.Instance.score);
        privacyPanel.SetActive(false);
        phonePanel.SetActive(false);
        badPanel.SetActive(true);
    }

    public void Disagree()
    {
        GameManager.Instance.AddPoints(10);
        Debug.Log("Current Score: " + GameManager.Instance.score);
        privacyPanel.SetActive(false);
        phonePanel.SetActive(false);
        goodPanel.SetActive(true);
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}
