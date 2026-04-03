using UnityEngine;

public class PrivacyChoice : MonoBehaviour
{
    public GameObject taskDescription;
    public GameObject phonePanel;
    public GameObject privacyPanel;
    public GameObject goodPanel;
    public GameObject badPanel;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log( GameManager.Instance.playerName + GameManager.Instance.playerDegree + GameManager.Instance.age);
            Debug.Log("PrivacyChoice Start: GameManager found. Current score = " + GameManager.Instance.score);
        }
    }
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);

        if (phonePanel != null)
            phonePanel.SetActive(true);
    }

    public void Agree()
    {
        GameManager.Instance.AddPoints(0);
        Debug.Log("Current Score: " + GameManager.Instance.score);

        if (privacyPanel != null)
            privacyPanel.SetActive(false);

        if (phonePanel != null)
            phonePanel.SetActive(false);

        if (badPanel != null)
            badPanel.SetActive(true);
    }

    public void Disagree()
    {
        GameManager.Instance.AddPoints(2);
        Debug.Log("Current Score: " + GameManager.Instance.score);

        if (privacyPanel != null)
            privacyPanel.SetActive(false);

        if (phonePanel != null)
            phonePanel.SetActive(false);

        if (goodPanel != null)
            goodPanel.SetActive(true);
    }
}