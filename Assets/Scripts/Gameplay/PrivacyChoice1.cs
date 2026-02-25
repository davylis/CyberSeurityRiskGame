using UnityEngine;

public class PrivacyChoice : MonoBehaviour
{
    public GameObject privacyPanel;
    public GameObject phonePanel;
    public GameObject goodPanel;
    public GameObject badPanel;

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
        GameManager.Instance.AddPoints(1);
        Debug.Log("Current Score: " + GameManager.Instance.score);
        privacyPanel.SetActive(false);
        phonePanel.SetActive(false);
        goodPanel.SetActive(true);
    }
}
