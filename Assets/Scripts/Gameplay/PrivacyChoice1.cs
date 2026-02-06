using UnityEngine;

public class PrivacyChoice : MonoBehaviour
{
    public GameObject privacyPanel;
    public GameObject phonePanel;
    public GameObject goodPanel;
    public GameObject badPanel;

    public void Agree()
    {
        privacyPanel.SetActive(false);
        phonePanel.SetActive(false);
        badPanel.SetActive(true);
    }

    public void Disagree()
    {
        privacyPanel.SetActive(false);
        phonePanel.SetActive(false);
        goodPanel.SetActive(true);
    }
}
